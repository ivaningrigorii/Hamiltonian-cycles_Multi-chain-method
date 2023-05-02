using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CoursWork_Ivanin_MainFile_CSharp
{
    class Nodes : IDrawGraphElements
    {
        public PointGraph point { get; set; }

        public int radiusEllipse { get; set; }
        public void draw(Graphics g, Color color, int sizeLine)
        {
            Pen pen = new Pen(color, sizeLine);
            g.DrawEllipse(pen, point.x, point.y, radiusEllipse, radiusEllipse);
        }
    }
}
