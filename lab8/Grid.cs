using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8
{
    struct Grid
    {
        public Point left_up;
        public Size cell_size;
        public Size space_size;
        public int columns;
        public int rows;
        public int count_cell;
        public Grid(Point left_up, Size cell_size, Size space_size, int columns, int rows, int count_cell)
        {
            this.left_up = left_up;
            this.cell_size = cell_size;
            this.space_size = space_size;
            this.columns = columns;
            this.rows = rows;
            this.count_cell = count_cell;
        }
        public Point GetCellCenter(int number_cell)
        {
            Point center = new Point();
            int row = number_cell / columns;
            int column = number_cell % columns;
            Point left_up = new Point(
                                      this.left_up.X + column * (cell_size.Width + space_size.Width),
                                      this.left_up.Y + row * (cell_size.Height + space_size.Height)
                                      );
            Point right_down = new Point(left_up.X + cell_size.Width, left_up.Y + cell_size.Height);
            center.X = (left_up.X + right_down.X) / 2;
            center.Y = (left_up.Y + right_down.Y) / 2;
            return center;
        }
        public Rectangle GetDescRect(int number_cell)
        {
            int row = number_cell / columns;
            int column = number_cell % columns;
            int x = left_up.X + (column * (cell_size.Width + space_size.Width));
            int y = left_up.Y + row * (cell_size.Height + space_size.Height) + cell_size.Height;
            Rectangle rectangle = new Rectangle(x, y, cell_size.Width, space_size.Height);
            return rectangle;
        }
        public Rectangle GetColorRect(int number_cell)
        {
            int row = number_cell / columns;
            int column = number_cell % columns;
            Rectangle rect = new Rectangle(new Point((cell_size.Width + space_size.Width) * column + left_up.X, (cell_size.Height + space_size.Height) * row + left_up.Y), cell_size);
            return rect;
        }
    }
}
