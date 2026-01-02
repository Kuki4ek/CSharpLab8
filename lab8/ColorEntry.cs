using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8
{
    public struct ColorEntry
    {
        public Color color;
        public int id;
        public ColorEntry(Color color, int id)
        {
            this.color = color;
            this.id = id;
        }
    }
}
