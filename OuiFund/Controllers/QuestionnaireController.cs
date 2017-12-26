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
    public class QuestionnaireController : BaseController
    {
        private IQuestionnaireService _questionnaireService;
        private IQuestionService questionService;
        private ICategorieService categorieService;
        private IReponseService _reponseService;
        private IAnalyseService analyseService;
        private IUserService userService;
        private IEmailService _emailService;

        public QuestionnaireController(IQuestionnaireService questionnaireService, IReponseService reponse, IQuestionService quest, ICategorieService categ,
                                    IAnalyseService analyse, IUserService user, IEmailService emailService)
        {
            _questionnaireService = questionnaireService;
            _reponseService = reponse;
            questionService = quest;
            categorieService = categ;
            analyseService = analyse;
            userService = user;
            _emailService = emailService;
        }
        // GET: Questionnaire
        public ActionResult Index(int? id)
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
        public ActionResult Index(QuestionnaireVm model)
        {
           // _emailService.SendAcountCredentiel(new Domain.Model.User { AdresseEmail = "wsouissi88@gmail.com", Password = "" });
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
                //Anayse
                var anlysePointsForts = string.Empty;
                foreach (var q in questions)
                {
                    if (q.ReponseSelected > 0)
                    {
                        var rep = _reponseService.getReponseById(q.ReponseSelected);
                        anlysePointsForts = anlysePointsForts + rep.AnalyseReponsePointsForts;
                    }
                }
                questionnaire.AnalysePointForts = anlysePointsForts;
                _questionnaireService.Create(questionnaire);
            }
            else
            {
                questionnaire = _questionnaireService.getQuestionnaireById(model.QuestionnaireId);
                _questionnaireService.DeleteQuestionReponseByQuestionnaireId(model.QuestionnaireId);
                questionnaire.Questions = questions;
                questionnaire.UserId = SecurityHelper.GetCurrentUserId();
                //Anayse
                var anlysePointsForts = string.Empty;
                foreach (var q in questions)
                {                  
                    if (q.ReponseSelected > 0) {
                        var rep = _reponseService.getReponseById(q.ReponseSelected);
                        anlysePointsForts = anlysePointsForts + rep.AnalyseReponsePointsForts;
                    }                    
                }
                questionnaire.AnalysePointForts = anlysePointsForts;
                _questionnaireService.Update(questionnaire);
            }
            var categories = categorieService.getCategories();
            model = new QuestionnaireVm(categories, questionnaire);
            // return View(model);
            return RedirectToAction("ListQuestionnaire");
        }
    }
}