using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab8
{
    public partial class Form1 : Form
    {
        const string images_path = @"C:\Users\ja-v-\OneDrive\5 семестр\Лабы\Визуальное программирование\lab8\lab8\images";
        Size cell_size = new Size();
        Size columnsAndRows = new Size();
        Size space_size = new Size();
        Point space_border = new Point();
        int text_height;
        Bitmap bitmap;
        List<ColorEntry> colors_memory;
        public Form1()
        {
            InitializeComponent();
            Bitmap RAL_1_bitmap = new Bitmap(images_path + @"\RAL_1.gif");
            Bitmap RAL_2_bitmap = new Bitmap(images_path + @"\RAL_2.gif");
            Bitmap RAL_3_bitmap = new Bitmap(images_path + @"\RAL_3.gif");
            Grid RAL_1_grid = new Grid(new Point(7, 71), new Size(104, 45), new Size(12, 29), 5, 3, 13);
            Grid RAL_2_grid = new Grid(new Point(7, 44), new Size(65, 47), new Size(7, 25), 8, 10, 80);
            Grid RAL_3_grid = new Grid(new Point(6, 3), new Size(65, 46), new Size(8, 27), 8, 14, 107);
            List<Color> RAL_1_colors = ImageProcessor.GetImageColors(RAL_1_bitmap, RAL_1_grid);
            List<Color> RAL_2_colors = ImageProcessor.GetImageColors(RAL_2_bitmap, RAL_2_grid);
            List<Color> RAL_3_colors = ImageProcessor.GetImageColors(RAL_3_bitmap, RAL_3_grid);
            List<int> RAL_1_ids = ImageProcessor.GetIds(RAL_1_bitmap, RAL_1_grid);
            List<int> RAL_2_ids = ImageProcessor.GetIds(RAL_2_bitmap, RAL_2_grid);
            List<int> RAL_3_ids = ImageProcessor.GetIds(RAL_3_bitmap, RAL_3_grid);

            List<ColorEntry> colors = new List<ColorEntry>();
            for (int i = 0; i < RAL_1_ids.Count; i++)
            {
                colors.Add(new ColorEntry(RAL_1_colors[i], RAL_1_ids[i]));
            }
            for (int i = 0; i < RAL_2_ids.Count; i++)
            {
                colors.Add(new ColorEntry(RAL_2_colors[i], RAL_2_ids[i]));
            }
            for (int i = 0; i < RAL_3_ids.Count; i++)
            {
                colors.Add(new ColorEntry(RAL_3_colors[i], RAL_3_ids[i]));
            }
            XMLProcessor.SaveXML(colors, @"C:\Users\ja-v-\OneDrive\5 семестр\Лабы\Визуальное программирование\lab8\lab8\out\out.xml");
            colors_memory = XMLProcessor.LoadXML(@"C:\Users\ja-v-\OneDrive\5 семестр\Лабы\Визуальное программирование\lab8\lab8\out\out.xml");
            this.UpdateBitmap(colors_memory);
        }
        public void UpdateBitmap(List<ColorEntry> colors)
        {
            cell_size.Width = (int)numericUpDown1.Value;
            cell_size.Height = (int)numericUpDown2.Value;
            columnsAndRows.Width = (int)numericUpDown9.Value;
            columnsAndRows.Height = (int)numericUpDown8.Value;
            space_size.Width = (int)numericUpDown4.Value;
            space_size.Height = (int)numericUpDown3.Value;
            space_border.X = (int)numericUpDown7.Value;
            space_border.Y = (int)numericUpDown6.Value;
            text_height = (int)numericUpDown5.Value;
            Grid new_grid = new Grid(space_border, cell_size, space_size, columnsAndRows.Height, columnsAndRows.Width, colors.Count);
            bitmap = ImageProcessor.Generator(colors, new_grid, text_height);
            pictureBox1.Image = bitmap;
        }
        public void SaveBitmap()
        {
            bitmap.Save(@"C:\Users\ja-v-\OneDrive\5 семестр\Лабы\Визуальное программирование\lab8\lab8\out\out.png");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            colors_memory = XMLProcessor.LoadXML(@"C:\Users\ja-v-\OneDrive\5 семестр\Лабы\Визуальное программирование\lab8\lab8\out\out.xml");
            this.UpdateBitmap(colors_memory);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bitmap.Save(@"C:\Users\ja-v-\OneDrive\5 семестр\Лабы\Визуальное программирование\lab8\lab8\out\out.png");
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            this.UpdateBitmap(colors_memory);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            this.UpdateBitmap(colors_memory);
        }

        private void numericUpDown9_ValueChanged(object sender, EventArgs e)
        {
            this.UpdateBitmap(colors_memory);
        }

        private void numericUpDown8_ValueChanged(object sender, EventArgs e)
        {
            this.UpdateBitmap(colors_memory);
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            this.UpdateBitmap(colors_memory);
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            this.UpdateBitmap(colors_memory);
        }

        private void numericUpDown7_ValueChanged(object sender, EventArgs e)
        {
            this.UpdateBitmap(colors_memory);
        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            this.UpdateBitmap(colors_memory);
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            this.UpdateBitmap(colors_memory);
        }
    }
}
