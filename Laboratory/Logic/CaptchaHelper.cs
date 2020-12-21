using System;
using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;

namespace Logic
{
    /// <summary>
    /// Класс для создания captcha
    /// </summary>
    public class CaptchaHelper
    {
        public string captchaText { set; get; }
        public BitmapImage captchaImage { set; get; }

        /// <summary>
        /// Метод, генерирующий текст captcha
        /// </summary>
        /// <returns>Возвращает string</returns>
        private void CaptchaGenerator()
        {
            captchaText = string.Empty;
            Random rand = new Random();

            string alphabet = "1234567890QWERTYUIOPASDFGHJKLZXCVBNMabcdefghijklmnopqrstuvwxyz";
            for (int i = 0; i < rand.Next(4, 9); ++i)
                captchaText += alphabet[rand.Next(alphabet.Length)];
        }

        /// <summary>
        /// Метод для создания изображения captcha
        /// </summary>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        /// <returns>Возвращает объект типа Bitmap</returns>
        public Bitmap CreateImage(int Width, int Height)
        {
            Random rand = new Random();
            Bitmap result = new Bitmap(Width, Height);
            CaptchaGenerator();

            int Xpos = rand.Next(0, Width - captchaText.Length * 25);
            int Ypos = rand.Next(2, Height - 40);

            Brush[] colors = { Brushes.Black,
                     Brushes.Red,
                     Brushes.Blue,
                     Brushes.Green,
                     Brushes.Yellow,
                     Brushes.Purple
            };

            Graphics g = Graphics.FromImage(result);
            g.Clear(Color.FromArgb(100, 73, 140, 81));
            g.DrawString(captchaText,
                         new Font("Comic Sans MS", 20),
                         colors[rand.Next(colors.Length)],
                         new PointF(Xpos, Ypos));

            g.DrawLine(Pens.Black,
                       new Point(0, 0),
                       new Point(Width - 1, Height - 1));
            g.DrawLine(Pens.Black,
                       new Point(0, Height - 1),
                       new Point(Width - 1, 0));

            for (int i = 0; i < Width; ++i)
                for (int j = 0; j < Height; ++j)
                    if (rand.Next() % 20 == 0)
                        result.SetPixel(i, j, Color.FromArgb(100, 118, 227, 131));

            return result;
        }

        /// <summary>
        /// Метод для конвертирования изображения в объект BitmapImage
        /// </summary>
        /// <param name="bitmap"></param>
        private void ConvertImage(Bitmap bitmap)
        {
            MemoryStream ms = new MemoryStream();
            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            ms.Seek(0, SeekOrigin.Begin);
            image.StreamSource = ms;
            image.EndInit();
            captchaImage = image;
        }

        /// <summary>
        /// Метод для получения captcha
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns>Возвращает объект типа CaptchaHelper</returns>
        public CaptchaHelper GetCaptcha(int width, int height)
        {
            CaptchaGenerator();
            var bitmap = CreateImage(width, height);
            ConvertImage(bitmap);
            return this;
        }
    }
}
