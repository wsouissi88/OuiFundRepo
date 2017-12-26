using OuiFund.Helper;
using OuiFund.Models;
using OuiFund.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OuiFund.Controllers
{
    public class ListQuestionnaireController : Controller
    {
        private IQuestionnaireService _questionnaireService;
        private IPdfService _pdfService;
        public ListQuestionnaireController(IQuestionnaireService questionnaireService, IPdfService pdfService)
        {
            _questionnaireService = questionnaireService;
            _pdfService = pdfService;
        }
        // GET: ListQuestionnaire
        public ActionResult Index()
        {
            var list = _questionnaireService.getAll();
            var model = new ListQuestionnairesVm { Questionnaires = list };
            return View(model);
        }

        public ActionResult AnalysePdf(int id)
        {
            var questionnaire = _questionnaireService.getQuestionnaireById(id);
            var pdfBytes = _pdfService.GetPdfAnalyseFirstSurvey(questionnaire);
            var pdfResult = new PdfResult(pdfBytes, "analyse");
            return pdfResult;
        }
    }
}