using OuiFund.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OuiFund.Common.Pdf;
using OuiFund.Domain.Model;

namespace OuiFund.Services.Services
{
    public class PdfService : IPdfService
    {
        public byte[] GetPdfAnalyseFirstSurvey(Questionnaire q)
        {
            var facade = new AnalyseFirstSurveyPdfFacade(q);
            return facade.GetPdf();
        }
    }
}
