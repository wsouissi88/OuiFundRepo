using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using OuiFund.Domain.Model;

namespace OuiFund.Common.Pdf
{
    public class AnalyseFirstSurveyPdfFacade : AbstractPdfFacade
    {
        private readonly Questionnaire _questionnaire;
        public AnalyseFirstSurveyPdfFacade(Questionnaire questionnaire) : base(PageSize.A4.Rotate())
        {
            _questionnaire = questionnaire;
        }

        protected override void AddHeaderFooter(PdfWriter writer)
        {
            var pdfHeaderFooter = new PdfHeaderFooter ();
            writer.PageEvent = pdfHeaderFooter;
        }

        protected override void CreateDocumentBody(iTextSharp.text.Document document)
        {
            document.Add(new Phrase("Points Forts", FontFs));
            document.Add(new Phrase(_questionnaire.AnalysePointForts, FontFs));
        }


        }
}
