using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CoursWork_Ivanin_MainFile_CSharp
{
    class StringDraw : IDrawGraphElements
    {
        public PointGraph point { get; set; }

        public int numberPointInList { get; set; }

        public void draw(Graphics g, Color color, int sizeLine)
        {

            Font drawFont = new Font("Arial", 16);
            SolidBrush drawBrush = new SolidBrush(color);
            g.DrawString($"{point.numberOfPoint}", drawFont, drawBrush, (float)(point.x), (float)(point.y));
        }
    }
}
