using iText.IO.Image;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CarRental_DBFirst
{
    public class PDFGenerate
    {
        private static PDFGenerate Instance;
        public string pdfPath;

        private PDFGenerate() { }

        public static PDFGenerate getInstance()
        {
            if(Instance == null)
                Instance = new PDFGenerate();

            return Instance;
        }

        public void GeneratePDFRent(string pdfPath, Rent rent)
        {
            if (String.IsNullOrEmpty(pdfPath)) return ;

            PdfWriter writer = new PdfWriter(pdfPath);
            PdfDocument pdfDoc = new PdfDocument(writer);
            pdfDoc.SetDefaultPageSize(PageSize.A4);
            Document document = new Document(pdfDoc);

            Paragraph header = new Paragraph("Car Rental Contact")
                                    .SetTextAlignment(TextAlignment.CENTER)
                                    .SetFontSize(20).SetBold();

            Paragraph subheader = new Paragraph("Please make sure to verify our contact information carefully before leaving our company")
                                   .SetTextAlignment(TextAlignment.CENTER)
                                   .SetFontSize(13);

            LineSeparator ls = new LineSeparator(new SolidLine());

            string projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string imagePath = @"./Resources/HeroContactCarRental.jpg";
            string filePath = System.IO.Path.Combine(projectPath, imagePath);
            Image image = new Image(ImageDataFactory.Create(filePath))
                                                    .SetHeight(200)
                                                    .SetMarginTop(20)
                                                    ;
            //.SetTextAlignment(TextAlignment.CENTER)

            document.Add(header);
            document.Add(subheader);
            document.Add(ls);
            document.Add(image).SetTextAlignment(TextAlignment.CENTER);

            //PropertyInfo[] properties = typeof(Rent).GetProperties();
            //foreach (PropertyInfo property in properties)
            //{
            //    Paragraph para = new Paragraph()
            //                    .Add(new Text(property.Name + ": ").SetBold())
            //                    .Add(new Text(property?.GetValue(rent)?.ToString()).SetFontSize(12))
            //                    .SetTextAlignment(TextAlignment.LEFT);
            //    document.Add(para);
            //}

            document.Close();
            pdfDoc.Close();
        }
    }
}
