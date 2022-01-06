using ImageMagick;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract;

namespace deletesoon
{
    class Program
    {

        static void ocrProcess(string pathname, string name)
        {

            var path = @"C:\Users\Guey Ling\source\repos\ConvertPdf\packages\Tesseract.Net.SDK.4.1.411\content\tessdata";
            //your sample image location
            var sourceFilePath = pathname;
            using (var engine = new TesseractEngine(path, "eng"))
            {
                engine.SetVariable("user_defined_dpi", "70"); //set dpi for supressing warning
                using (var img = Pix.LoadFromFile(sourceFilePath))
                {
                    using (var page = engine.Process(img))
                    {
                        var text = page.GetText();

                        StreamWriter writer = new StreamWriter("data.txt", true);
                        writer.WriteLine(name + "\n" + text);
                        writer.WriteLine("\n");
                        writer.Close();
                    }
                }
            }
        }



        static void imageProcessing()
        {
            using (MagickImage image = new MagickImage(@"C:\Users\Guey Ling\source\repos\deletesoon\deletesoon\bin\Debug\hello.png"))
            {

                image.Grayscale();
                image.Sharpen();
                image.Scale(203, 100);

                image.Write(@"C:\Users\Guey Ling\source\repos\deletesoon\deletesoon\bin\Debug\edited.png");
            }
        }

        static void cropImage(int x, int y, int width, int height)
        {

            Bitmap source = new Bitmap(@"C:\Users\Guey Ling\source\repos\deletesoon\deletesoon\bin\Debug\actual.png");
            Bitmap CroppedImage = source.Clone(new System.Drawing.Rectangle(x, y, width, height), source.PixelFormat);
            CroppedImage.Save(@"C:\Users\Guey Ling\source\repos\deletesoon\deletesoon\bin\Debug\hello.png");
        }



        static void Main(string[] args)
        {
            cropImage(500, 20, 280, 120);
            ocrProcess("C:/Users/Guey Ling/source/repos/deletesoon/deletesoon/bin/Debug/hello.png", "Code");

            cropImage(500, 155, 280, 120);
            ocrProcess("C:/Users/Guey Ling/source/repos/deletesoon/deletesoon/bin/Debug/hello.png", "Area");

            cropImage(450, 125, 95, 80);
            ocrProcess("C:/Users/Guey Ling/source/repos/deletesoon/deletesoon/bin/Debug/hello.png", "Date");

            cropImage(500, 385, 180, 40);
            ocrProcess("C:/Users/Guey Ling/source/repos/deletesoon/deletesoon/bin/Debug/hello.png", "Price");

            cropImage(60, 665, 70, 30);
            imageProcessing();
            ocrProcess("C:/Users/Guey Ling/source/repos/deletesoon/deletesoon/bin/Debug/edited.png", "Inv No.");




        }
    }
}



