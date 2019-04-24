using PDFiumSharp;
using System;
using System.IO;

namespace PdfToImageTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Converting pdf to image..");

            using (var doc = new PdfDocument("c:\\test.pdf"))
            {
                int i = 0;
                foreach (var page in doc.Pages)
                {
                    using (var bitmap = new PDFiumBitmap((int)page.Width, (int)page.Height, true))
                    using (var stream = new FileStream($"{i++}.bmp", FileMode.Create))
                    {
                        page.Render(bitmap);
                        bitmap.Save(stream);
                    }
                }
            }

            Console.WriteLine("Finished converting pdf to image..");

            Console.Read();
        }
    }
}