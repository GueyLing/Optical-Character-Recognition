using System;
using System.IO;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Windows.Forms.PdfViewer;
using System.Drawing;
using System.Drawing.Imaging;

namespace pdfToImage
{
    class Program
    {
        static void convertpdf()
        {
            //Initialize the PdfViewer Control
            PdfViewerControl pdfViewer = new PdfViewerControl();

            //Load the input PDF file
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument(@"C:\Users\Guey Ling\source\repos\Latest\Latest\bin\pg5.pdf");

            pdfViewer.Load(loadedDocument);

            //Export the particular PDF page as image at the page index of 0
            Bitmap image = pdfViewer.ExportAsImage(0);

            // Save the image.
            image.Save(@"C:\Users\Guey Ling\source\repos\Latest\Latest\bin\actual.png", ImageFormat.Png);
        }
        static void Main(string[] args)
        {
            convertpdf();
        }
    }
}