using System.Web.Mvc;

namespace OuiFund.Helper
{
    public class PdfResult : FileContentResult
    {
        public PdfResult(byte[] sourceStream, string fileName)
            : base(sourceStream, "application/pdf")
        {
            FileDownloadName = fileName + ".pdf";
        }
    }
}