﻿using OuiFund.Data;
using OuiFund.Domain.Model;
using OuiFund.Models;
using OuiFund.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OuiFund.Controllers
{
    public class QuestionController : Controller
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

        public JsonResult Questionnaires()
        {
            List<int> questsId = new List<int>();
            List<string> quests = new List<string>();
            List<Question> questions = questionService.RandomQuestions(TypeQuestion.QCM_Question, 3);
            foreach (Question q in questions)
            {
                questsId.Add(q.QuestionID);
                quests.Add(q.DescriptionQuest);
            }

            return Json(questsId, JsonRequestBehavior.AllowGet);
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

        public ActionResult Reponses(int questID)
        {
            var reponses = new List<Reponse>();

            if (questID != 0)
            {
                reponses = reponseService.getReponsesQuestion(questID);
            }
            else
            {
                reponses = reponseService.getListReponses();
            }
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

            return View();
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
                Question q = new Question()
                {
                    DescriptionQuest = model.question.DescriptionQuest,
                    ReferenceQuest = model.question.ReferenceQuest,
                    StatusQuest = model.question.StatusQuest,
                    TypeQuest = model.question.TypeQuest,
                    categorieId = model.question.categorieId
                };
                q.Reponses.Add(model.reponse);
                questionService.ajouterQuestion(q);
                //Reponse r = new Reponse()
                //{
                //    TextReponse = model.reponse.TextReponse,
                //    ValeurReponse = model.reponse.ValeurReponse,
                //    AnalyseReponse = model.reponse.AnalyseReponse,
                //    questionId = q.QuestionID
                //};
                //reponseService.ajouterReponse(r);
            }
            return View();
        }

        public ActionResult DeleteQuestion(int id)
        {
            questionService.supprimerQuestion(id);
            return View();
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
            return View();
        }
    }
}