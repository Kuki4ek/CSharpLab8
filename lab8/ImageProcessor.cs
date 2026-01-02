using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract;

namespace lab8
{
    internal static class ImageProcessor
    {
        public static List<Color> GetImageColors(Bitmap bitmap, Grid grid)
        {
            List<Color> colors = new List<Color>();
            int count_cell = grid.count_cell;
            for (int i = 0; i < count_cell; i++)
            {
                Point cell_center = grid.GetCellCenter(i);
                colors.Add(bitmap.GetPixel(cell_center.X, cell_center.Y));
            }
            return colors;
        }
        public static List<int> GetIds(Bitmap bitmap, Grid grid)
        {
            string tessDataPath = Path.Combine(AppContext.BaseDirectory, "tessdata");
            List<int> ids = new List<int>();
            using (var ocrEngine = new TesseractEngine(tessDataPath, "eng", EngineMode.Default))
            {
                for (int i = 0; i < grid.count_cell; i++)
                {
                    string text = string.Empty;
                    Rectangle rect = grid.GetDescRect(i);
                    using (Bitmap croppedBitmap = bitmap.Clone(rect, bitmap.PixelFormat))
                    {
                        // Создаём движок OCR

                        // Конвертируем Bitmap в Pix
                        using (var pix = PixConverter.ToPix(croppedBitmap))
                        {
                            using (var page = ocrEngine.Process(pix))
                            {
                                text = page.GetText();
                            }
                        }

                    }
                    int id = 0;
                    text = text.Replace(",", "");
                    int.TryParse(text, out id);
                    ids.Add(id);
                }
            }
            return ids;
        }
        public static Bitmap Generator(List<ColorEntry> colors, Grid grid, int text_height)
        {
            Bitmap bitmap = new Bitmap(
                                       grid.left_up.X * 2 
                                       + grid.columns * grid.cell_size.Width 
                                       + (grid.columns - 1) * grid.space_size.Width + 1, 
                                       grid.left_up.Y * 2 
                                       + grid.rows * grid.cell_size.Height 
                                       + grid.rows * grid.space_size.Height + 1
                                       );
            Graphics g = Graphics.FromImage(bitmap);
            g.Clear(Color.White);
            for(int i  = 0; i < colors.Count; i++)
            {
                Font font = new Font("Arial", text_height, FontStyle.Bold);
                using (SolidBrush brush = new SolidBrush(colors[i].color))
                {
                    g.FillRectangle(brush, grid.GetColorRect(i));
                }
                using (Pen pen = new Pen(Color.Black, 1))
                {
                    g.DrawRectangle(pen, grid.GetColorRect(i));
                }
                using (Brush brush =  new SolidBrush(Color.Black))
                {
                    g.DrawString($"{colors[i].id}", font, brush, grid.GetDescRect(i).Location);
                }
            }
            return bitmap;
        }
    }
}
