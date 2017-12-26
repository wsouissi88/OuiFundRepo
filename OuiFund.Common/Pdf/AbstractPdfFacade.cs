using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;

namespace OuiFund.Common.Pdf
{
    public abstract class AbstractPdfFacade
    {
        protected static readonly BaseFont BfH = BaseFont.CreateFont(
                    BaseFont.TIMES_BOLD,
                    BaseFont.CP1252,
                    BaseFont.EMBEDDED);
        protected static readonly BaseFont BfT = BaseFont.CreateFont(
                        BaseFont.TIMES_BOLD,
                        BaseFont.CP1252,
                        BaseFont.EMBEDDED);
        protected static readonly BaseFont Bf = BaseFont.CreateFont(
                BaseFont.TIMES_ROMAN,
                BaseFont.CP1252,
                BaseFont.EMBEDDED);
        protected static readonly BaseFont BfFs = BaseFont.CreateFont(
                    BaseFont.TIMES_BOLD,
                    BaseFont.CP1252,
                    BaseFont.EMBEDDED);

        protected static readonly Font FontH = new Font(BfH, 18);
        protected static readonly Font FontT = new Font(BfT, 11);
        protected static readonly Font Font = new Font(Bf, 11);
        protected static readonly Font FontUnderline = new Font(Bf, 11, Font.UNDERLINE);
        protected static readonly Font FontSmall = new Font(Bf, 8);
        protected static readonly Font FontItalic = new Font(Bf, 11, Font.ITALIC);
        protected static readonly Font FontFs = new Font(BfFs, 16);
        protected static readonly Font FontEv = new Font(BfFs, 12);
        private readonly Rectangle _pageSize;

        protected AbstractPdfFacade(Rectangle pageSize)
        {
            _pageSize = pageSize;
        }

        protected static readonly NumberFormatInfo Nfi = new NumberFormatInfo
        {
            NumberGroupSeparator = " ",
            NumberDecimalSeparator = ","
        };
        protected static readonly LineSeparator Separator = new LineSeparator { LineWidth = 1f, Percentage = 100f };
        protected abstract void CreateDocumentBody(Document document);
        protected abstract void AddHeaderFooter(PdfWriter writer);
        public byte[] GetPdf()
        {
            byte[] pdfBytes;
            var document = new Document(_pageSize, 50f, 50f, 20f, 30f);
            using (var mem = new MemoryStream())
            {
                var writer = PdfWriter.GetInstance(document, mem);
                AddHeaderFooter(writer);
                document.Open();//Open Document to write
                CreateDocumentBody(document);
                document.Close();
                pdfBytes = mem.ToArray();
                mem.Close();
            }
            return pdfBytes;


        }

    }
}
