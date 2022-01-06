using ImageMagick;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Windows.Forms.PdfViewer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract;

namespace NewForm
{
    class Program
    {
        
        //A function to remove the background lines
        static void removeBackground()
        {
            using (var image = new MagickImage(@"C:\Users\Guey Ling\source\repos\NewForm\NewForm\bin\Debug\final.jpg"))
            {
                image.Deskew((Percentage)50);
                // -alpha off ) ^
                image.Alpha(AlphaOption.Off);

                using (var images = new MagickImageCollection())
                {
                    // ( -clone 0
                    var tmp1 = image.Clone();

                    // -morphology close rectangle:1x50
                    tmp1.Morphology(MorphologyMethod.Close, "rectangle:1x10");

                    // -negate
                    tmp1.Negate();

                    // +write tmp1.png ) ^
                    tmp1.Write(@"C:\Users\Guey Ling\source\repos\NewForm\NewForm\bin\tmp1.png");

                    images.Add(tmp1);

                    // ( -clone 0
                    var tmp2 = image.Clone();

                    // -morphology close rectangle:50x1
                    tmp2.Morphology(MorphologyMethod.Close, "rectangle:20x1");

                    // -negate
                    tmp2.Negate();

                    // +write tmp2.png ) ^
                    tmp2.Write(@"C:\Users\Guey Ling\source\repos\NewForm\NewForm\bin\tmp2.png");

                    images.Add(tmp2);

                    // -evaluate-sequence add
                    using (var tmp3 = images.Evaluate(EvaluateOperator.Add))
                    {
                        // +write tmp3.png ) ^
                        tmp3.Write(@"C:\Users\Guey Ling\source\repos\NewForm\NewForm\bin\tmp3.png");

                        // -compose plus -composite ^
                        image.Composite(tmp3, CompositeOperator.Plus);

                        // result.png
                        image.Write(@"C:\Users\Guey Ling\source\repos\NewForm\NewForm\bin\result.png");
                    }
                }
            }
        }

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
            using (MagickImage image = new MagickImage(@"C:\Users\Guey Ling\source\repos\NewForm\NewForm\bin\Debug\hello.jpg"))
            {

                image.Sharpen();
                image.BrightnessContrast((Percentage)10, (Percentage)10);

                image.Write(@"C:\Users\Guey Ling\source\repos\NewForm\NewForm\bin\Debug\edited.png");
            }
        }

        static void imageProcessing2()
        {
            using (MagickImage image = new MagickImage(@"C:\Users\Guey Ling\source\repos\NewForm\NewForm\bin\Debug\hello.jpg"))
            {

                image.Threshold((Percentage)85);
                image.Write(@"C:\Users\Guey Ling\source\repos\NewForm\NewForm\bin\Debug\edited.png");
            }
        }


        static void imageProcessing3()
        {
            using (MagickImage image = new MagickImage(@"C:\Users\Guey Ling\source\repos\NewForm\NewForm\bin\Debug\hello.jpg"))
            {
                image.Scale(200, 200);
                image.Threshold((Percentage)92);
                //  image.BrightnessContrast((Percentage)10, (Percentage)10);

                // image.Sharpen();
                //    image.Morphology(MorphologyMethod.Erode, Kernel.Square, "1");
                //  image.Threshold((Percentage)75);
                image.Write(@"C:\Users\Guey Ling\source\repos\NewForm\NewForm\bin\Debug\edited.png");
            }
        }
        static void cropImage(int x, int y, int width, int height)
        {

            Bitmap source = new Bitmap(@"C:\Users\Guey Ling\source\repos\NewForm\NewForm\bin\Debug\final.jpg");
            Bitmap CroppedImage = source.Clone(new System.Drawing.Rectangle(x, y, width, height), source.PixelFormat);
            CroppedImage.Save(@"C:\Users\Guey Ling\source\repos\NewForm\NewForm\bin\Debug\hello.jpg");
        }
        static void cropImage2(int x, int y, int width, int height)
        {

            Bitmap source = new Bitmap(@"C:\Users\Guey Ling\source\repos\NewForm\NewForm\bin\result.png");
            Bitmap CroppedImage = source.Clone(new System.Drawing.Rectangle(x, y, width, height), source.PixelFormat);
            CroppedImage.Save(@"C:\Users\Guey Ling\source\repos\NewForm\NewForm\bin\Debug\hello.jpg");
        }

        static void Main(string[] args)
        {            

            //remove the background lines
            removeBackground();

            //crop the image and perform OCR (perform image processing when necessary)
            cropImage(500, 102, 228, 35);
            ocrProcess("C:/Users/Guey Ling/source/repos/NewForm/NewForm/bin/hello.jpg", "Code");

            cropImage(510, 140, 180, 70);
            ocrProcess("C:/Users/Guey Ling/source/repos/NewForm/NewForm/bin/hello.jpg", "Station");

            cropImage(430, 125, 180, 20);
            ocrProcess("C:/Users/Guey Ling/source/repos/NewForm/NewForm/bin/hello.jpg", "Date");

            cropImage(520, 375, 120, 20);
            imageProcessing();
            ocrProcess("C:/Users/Guey Ling/source/repos/NewForm/NewForm/bin/edited.png", "CIF Value");

            cropImage(115, 615, 80, 20);
            imageProcessing2();
            ocrProcess("C:/Users/Guey Ling/source/repos/NewForm/NewForm/bin/edited.png", "Invoice No.");

            cropImage2(680, 164, 70, 20);
            imageProcessing3();
            ocrProcess("C:/Users/Guey Ling/source/repos/NewForm/NewForm/bin/edited.png", "Area Code");

        }//end main
    }//end program
}//end namespace



