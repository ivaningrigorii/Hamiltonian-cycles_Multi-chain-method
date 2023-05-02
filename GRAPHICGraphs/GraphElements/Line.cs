using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace CoursWork_Ivanin_MainFile_CSharp
{
    class Line : IDrawGraphElements
    {
        public PointGraph point1 { get; set; }
        public PointGraph point2 { get; set; }
        public int diameter { get; set; }

        private GraphicsPath Path(PointF start, PointF end, float h, float l)
        {
            GraphicsPath gp = new GraphicsPath();

            PointF Vector = new PointF(end.X - start.X, end.Y - start.Y);
            float d = (float)Math.Sqrt(Math.Pow(Vector.X, 2) + Math.Pow(Vector.Y, 2));
            PointF normalizedVector = new PointF(Vector.X / d, Vector.Y / d);
            //середина отрезка
            PointF mid = new PointF(end.X, end.Y);

            PointF indentForArrow = new PointF(mid.X - l * normalizedVector.X, mid.Y - l * normalizedVector.Y);
            //Нормали для раствора стрелки
            PointF StandArrowSol1 = new PointF(-normalizedVector.Y * h / 2 + indentForArrow.X, normalizedVector.X * h / 2 + indentForArrow.Y);
            PointF StandArrowSol2 = new PointF(normalizedVector.Y * h / 2 + indentForArrow.X, -normalizedVector.X * h / 2 + indentForArrow.Y);

            gp.AddLine(StandArrowSol1, end);
            gp.AddLine(StandArrowSol2, end);
            return gp;
        }

        private PointGraph shiftPoints(PointGraph point1, PointGraph point2)
        {
            PointGraph pointTmp = point1.Clone();
            double d = Math.Sqrt(Math.Pow(point1.x - point2.x, 2) + Math.Pow(point1.y - point2.y, 2));
            double ameg = Math.Abs((double)(diameter) / (d - diameter));

            pointTmp.x = (int)(((double)point1.x + (double)point2.x * ameg) / (1 + ameg));
            pointTmp.y = (int)(((double)point1.y + (double)point2.y * ameg) / (1 + ameg));

            return pointTmp.Clone();
        }

        private void center()
        {
            double shift = diameter / 2d;
            diameter = diameter / 2;
            point1.x += (int)shift;
            point2.y += (int)shift;
            point1.y += (int)shift;
            point2.x += (int)shift;
        }

        public void draw(Graphics g, Color color, int sizeLine)
        {
            center();

            PointGraph pointTmp = shiftPoints(point1.Clone(), point2.Clone());
            point1.x = pointTmp.x;
            point1.y = pointTmp.y;
            pointTmp = shiftPoints(point2.Clone(), point1.Clone());
            point2.x = pointTmp.x;
            point2.y = pointTmp.y;

            Pen pen = new Pen(color, sizeLine);
            PointF point1F = new PointF { X = (float)point1.x, Y = (float)point1.y };
            PointF point2F = new PointF { X = (float)point2.x, Y = (float)point2.y };

            g.DrawPath(pen, Path(point1F, point2F, 5, 10));
            g.DrawLine(pen, point1.x, point1.y, point2.x, point2.y);
        }
    }
}
