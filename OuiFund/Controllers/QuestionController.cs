using OuiFund.Data;
using OuiFund.Domain.Model;
using OuiFund.Infrastructure.Mvc;
using OuiFund.Infrastructure.Security;
using OuiFund.Models;
using OuiFund.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OuiFund.Controllers
{
    public class QuestionController : BaseController
    {
        private IQuestionnaireService _questionnaireService;
        private IQuestionService questionService;
        private ICategorieService categorieService;
        private IReponseService reponseService;
        private IAnalyseService analyseService;
        private IUserService userService;

        public QuestionController(IQuestionnaireService questionnaireService, IReponseService reponse, IQuestionService quest, ICategorieService categ, 
                                    IAnalyseService analyse, IUserService user)
        {
            _questionnaireService = questionnaireService;
            reponseService = reponse;
            questionService = quest;
            categorieService = categ;
            analyseService = analyse;
            userService = user;
        }

        // GET: Question
        public ActionResult Index()
        {
            var categories = categorieService.getCategories();

            return View();
        }

        public ActionResult Categories()
        {
            var categories = categorieService.getCategories();
            return View(categories);
        }
        public ActionResult Questions(TypeQuestion ? type)
        {   
            var questions = new List<Question>();
            if(type == null)
            {
                questions = questionService.getListQuestions();
            }
            else
            {
                questions = questionService.getQuestionsByType((TypeQuestion)type);
            }  
            return View(questions);
        }

        public ActionResult ChangeStatus(int QuestionId)
        {
            var quest = questionService.getQuestionById(QuestionId);
            if(quest.StatusQuest == true)
            {
                quest.StatusQuest = false;
            }
            else
            {
                quest.StatusQuest = true;
            }
            questionService.modifierQuestion(quest);
            return RedirectToAction("Questions");
        }

        public JsonResult QuestionnairesQCM()
        {
            List<string> quests = new List<string>();
            List<Reponse> rep = new List<Reponse>();
            List<Question> questions = questionService.RandomQuestions(TypeQuestion.DdlQuestion, 10);
            foreach (Question q in questions)
            {
                rep = reponseService.getReponsesQuestion(q.QuestionID);
                string reponses = "";
                foreach(Reponse r in rep)
                {
                    reponses += ":" + r.ReponseID + "?" + r.TextReponse;
                }
                quests.Add(q.QuestionID+":"+q.DescriptionQuest+""+reponses);
            }
            return Json(quests, JsonRequestBehavior.AllowGet);
        }
        public JsonResult QuestionnairesNoted()
        {
            List<string> quests = new List<string>();
            List<Reponse> rep = new List<Reponse>();
            List<Question> questions = questionService.RandomQuestions(TypeQuestion.NoteQuestion, 10);
            foreach (Question q in questions)
            {                
                quests.Add(q.QuestionID + ":" + q.DescriptionQuest);
            }
            return Json(quests, JsonRequestBehavior.AllowGet);
        }
        public JsonResult QuestionnairesRedact()
        {
            List<string> quests = new List<string>();
            List<Reponse> rep = new List<Reponse>();
            List<Question> questions = questionService.RandomQuestions(TypeQuestion.TextAreaQUestion, 10);
            foreach (Question q in questions)
            {
                quests.Add(q.QuestionID + ":" + q.DescriptionQuest);
            }
            return Json(quests, JsonRequestBehavior.AllowGet);
        }
        
        // get listForResponse & check IdQuestion/IdReponse 
        // Add reponse to user in new table Result 
        public JsonResult saveResult(List<string> lst)
        {
            List<string> listreponse = new List<string>();
            User u = userService.getUserById(12);

            for (int i = 1; i < lst.Count; i++)
            {
                Analyse analyse = new Analyse
                {
                    UtilisateurId = u.UtilisateurID,
                    Utilisateur = u
                };
                if (lst[0] == "qcm")
                {
                    int idReponse = Int32.Parse(lst[i]);
                    Reponse r = reponseService.getReponseById(idReponse);
                    analyse.AnalyseModel = "QCM for User";
                    analyse.TypeAnalyse = Analyse.AnalyseType.QCM;
                    analyse.ReponseId = idReponse;
                    analyse.Reponse = r;
                }
                else
                {
                    var rsl = lst[i].Split(':');
                    int idQuestion = Int32.Parse(rsl[0]);
                    Question q = questionService.getQuestionById(idQuestion);
                    analyse.AnalyseModel = "Question for User";
                    analyse.QuestionId = idQuestion;
                    analyse.Question = q;
                    if(lst[0] == "noted")
                    {
                        analyse.NoteQuestion = Int32.Parse(rsl[1]);
                        analyse.TypeAnalyse = Analyse.AnalyseType.Notee;
                    }
                    else
                    {
                        analyse.TextQuestion = rsl[1];
                        analyse.TypeAnalyse = Analyse.AnalyseType.Ouvert;
                    }                    
                }
                analyseService.saveAnalyse(analyse);
                listreponse.Add("");
            }
            return Json(listreponse, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Reponse(int questId)
        {
            List<string> reponses = new List<string>();
            List<Reponse> rep = reponseService.getReponsesQuestion(questId);
            foreach (Reponse r in rep)
            {
                reponses.Add(r.TextReponse);
            }
            return Json(reponses, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Questionnaire(int? id)
        {
            // var userId = SecurityHelper.GetCurrentUserId();
            var questionnaire = id.HasValue ? _questionnaireService.getQuestionnaireById(id.Value) : null;//_questionnaireService.getLastQuestionnaireByUserId(userId);
            var categories = categorieService.getCategories();
            var model = new QuestionnaireVm(categories, questionnaire);
            model.QuestionnaireId = id ?? 0;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Questionnaire(QuestionnaireVm model)
        {
            Questionnaire questionnaire;
            var questions = new List<QuestionReponse>();
            foreach (var cat in model.CategorieQuestions)
            {
                foreach (var q in cat.Questions)
                {
                    var questionReponse = new QuestionReponse
                    {
                        QuestionID = q.Question.QuestionID,
                        ReponseSelected = q.ReponseSelected,
                        ReponseString = q.ReponseString
                    };

                    questions.Add(questionReponse);
                }
            }
            if (model.QuestionnaireId == 0)
            {
                 questionnaire = new Questionnaire();
                
                questionnaire.Questions = questions;
                questionnaire.UserId = SecurityHelper.GetCurrentUserId();
                questionnaire.DateCreation = DateTime.Now;
                _questionnaireService.Create(questionnaire);
            }
            else
            {
                 questionnaire = _questionnaireService.getQuestionnaireById(model.QuestionnaireId);
                _questionnaireService.DeleteQuestionReponseByQuestionnaireId(model.QuestionnaireId);
                questionnaire.Questions = questions;
                questionnaire.UserId = SecurityHelper.GetCurrentUserId();
                _questionnaireService.Update(questionnaire);
            }
            var categories = categorieService.getCategories();
             model = new QuestionnaireVm(categories, questionnaire);
            return View(model);
        }
        public ActionResult Reponses()
        {
            var reponses = reponseService.getListReponses();
            return View(reponses);
        }

        [HttpGet]
        public ActionResult AddCategorie()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCategorie(CategorieQuest categorie)
        {
            if (ModelState.IsValid)
            {
                categorieService.ajouterCategorie(categorie);
                categorie = null;
            }
            return View();
        }
        
        public ActionResult DeleteCategorie(int id)
        {
            CategorieQuest c = categorieService.getCategorieById(id);
            categorieService.supprimerCategorie(c);
            return RedirectToAction("Categories");
        }

        [HttpGet]
        public ActionResult AddQuestion()
        {
            var listCat = categorieService.getCategories();
            ViewBag.Categs = new SelectList(listCat, "CategorieID", "NomCategorie");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddQuestion(Question question)
        {
            if (ModelState.IsValid)
            {
                questionService.ajouterQuestion(question);
            }
            return View();
        }
        [HttpGet]
        public ActionResult CreateQuestion()
        {
            var listCat = categorieService.getCategories();
            ViewBag.Categs = new SelectList(listCat, "CategorieID", "NomCategorie");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateQuestion(QuestionViewModel model)
        {
            if (ModelState.IsValid)
            {
                CategorieQuest cat = categorieService.getCategorieById(model.CategorieID);                
                Question q = new Question()
                {
                    DescriptionQuest = model.DescriptionQuest,
                    ReferenceQuest = model.ReferenceQuest,
                    StatusQuest = model.StatusQuest,
                    TypeQuest = model.TypeQuest,
                    categorieId = model.CategorieID,
                    categorieQuestion = cat
                };
                switch (model.TypeQuest)
                {
                    case TypeQuestion.DdlQuestion:
                        List<string> listReponses = model.reponse.Split(',').ToList<string>();
                        for (int i = 0; i < listReponses.Count; i++)
                        {
                            List<string> reponseAnalyses = listReponses[i].Split(':').ToList<string>();
                            Reponse r = new Reponse
                            {
                                TextReponse = reponseAnalyses[0],
                                AnalyseReponse = reponseAnalyses[1],
                                ValeurReponse = i
                            };
                            q.Reponses.Add(r);
                        }
                        break;
                    case TypeQuestion.NoteQuestion:

                        break;
                    case TypeQuestion.TextAreaQUestion:

                        break;
                }
                //if(model.TypeQuest == TypeQuestion.QCM_Question)
                //{
                //    List<string> listReponses = model.reponse.Split(',').ToList<string>();
                //    for (int i = 0; i < listReponses.Count; i++)
                //    {
                //        List<string> reponseAnalyses = listReponses[i].Split(':').ToList<string>();
                //        Reponse r = new Reponse
                //        {
                //            TextReponse = reponseAnalyses[0],
                //            AnalyseReponse = reponseAnalyses[1],
                //            ValeurReponse = i
                //        };
                //        q.Reponses.Add(r);
                //    }
                //}                               
                questionService.ajouterQuestion(q);
            }
            return View();
        }

        public ActionResult DeleteQuestion(int id)
        {
            questionService.supprimerQuestion(id);
            return RedirectToAction("Questions");
        }

        [HttpGet]
        public ActionResult AddReponse()
        {
            var listQuest = questionService.getListQuestions();
            ViewBag.Questions = new SelectList(listQuest, "QuestionID", "DescriptionQuest");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddReponse(Reponse reponse)
        {
            if (ModelState.IsValid)
            {
                reponseService.ajouterReponse(reponse);
            }
            return View();
        }
        public ActionResult DeleteReponse(int id)
        {
            reponseService.supprimerReponse(id);
            return RedirectToAction("Reponses");
        }
    }
}