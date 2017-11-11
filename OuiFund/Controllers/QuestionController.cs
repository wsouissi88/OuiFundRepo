using OuiFund.Data;
using OuiFund.Domain.Model;
using OuiFund.Infrastructure.Mvc;
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
        private IQuestionService questionService;
        private ICategorieService categorieService;
        private IReponseService reponseService;

        public QuestionController(IReponseService reponse, IQuestionService quest, ICategorieService categ)
        {
            reponseService = reponse;
            questionService = quest;
            categorieService = categ;
        }

        // GET: Question
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Categories()
        {
            var categories = categorieService.getCategories();
            return View(categories);
        }
        public ActionResult Questions()
        {   // All Questions
            var questions = questionService.getListQuestions();

            // Libre Question
            //var questions = questionService.getQuestionsByType(TypeQuestion.Libre_Question);

            // Random 2 Questions QCM
            //var questions = questionService.RandomQuestions(TypeQuestion.QCM_Question, 2);
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

        public JsonResult Questionnaires()
        {
            List<string> quests = new List<string>();
            List<Reponse> rep = new List<Reponse>();
            List<Question> questions = questionService.RandomQuestions(TypeQuestion.QCM_Question, 5);
            foreach (Question q in questions)
            {
                rep = reponseService.getReponsesQuestion(q.QuestionID);
                string reponses = "";
                foreach(Reponse r in rep)
                {
                    reponses += ":" + r.TextReponse;
                }
                quests.Add(q.QuestionID+":"+q.DescriptionQuest+""+reponses);
            }
            return Json(quests, JsonRequestBehavior.AllowGet);
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

        public ActionResult Questionnaire()
        {
            return View();
        }

        public ActionResult Reponses()
        {
            var reponses = new List<Reponse>();

            //if (questID != 0)
            //{
            //    reponses = reponseService.getReponsesQuestion(questID);
            //}
            //else
            //{
                reponses = reponseService.getListReponses();
            //}
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
                List<string> listReponses = model.reponse.Split(',').ToList<string>();
                for(int i=0; i < listReponses.Count; i++)
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