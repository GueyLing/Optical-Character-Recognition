using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;
using iTextSharp.text.pdf;
using System.Collections;
using System.Diagnostics;
using iTextSharp.text.pdf.parser;
using IronOcr;

namespace PDFExtraction
{
    class Program
    {
        // A function to extract data from predefined bounds
        static void extractRegion(float x1, float y1, float x2, float y2, string title)
        {
            List<string> linestringlist = new List<string>();
            PdfReader reader = new PdfReader(@"C:\Users\Guey Ling\source\repos\PDFExtraction\PDFExtraction\bin\Debug\output.pdf");
            iTextSharp.text.Rectangle rect = new iTextSharp.text.Rectangle(x1, y1, x2, y2);
            RenderFilter[] renderFilter = new RenderFilter[1];
            renderFilter[0] = new RegionTextRenderFilter(rect);
            ITextExtractionStrategy textExtractionStrategy = new FilteredTextRenderListener(new LocationTextExtractionStrategy(), renderFilter);
            string text = PdfTextExtractor.GetTextFromPage(reader, 1, textExtractionStrategy);
            StreamWriter writer = new StreamWriter("data.txt");//, true
            writer.WriteLine(title + ":\n" + text);
            writer.WriteLine("\n");
            writer.Close();
        }


        // A function to convert the scanned pdf to searchable pdf
        static void convertPdf()
        {
            var Ocr = new IronTesseract();

            using (var Input = new OcrInput())
            {
                // OCR entire document
                Input.AddPdf("K2.pdf", "password");
                // Image Resolution Optimization
                //Input.MinimumDPI = 300;
                //Input.TargetDPI = 600;

                // Performance Tuning
                //Input.Binarize();
                //Input.Contrast();
                //Input.Deskew();
                //Input.DeNoise();

                var Result = Ocr.Read(Input);
                Ocr.Language = OcrLanguage.English;
                Ocr.Language = OcrLanguage.Malay;

                Console.WriteLine(Result.Text);

                // Output a searchable PDF
                Result.SaveAsSearchablePdf("output.pdf");
            }
        }

        static void Main(string[] args)
        {
            // call the function to convert scanned pdf to searchable pdf
            convertPdf();

            // extract the data from specific region of the pdf by determining the coordinates of the rectangle
            extractRegion(0, 600, 9823, 420, "Data");


        }//end main
    }//end class
}//end namespace

