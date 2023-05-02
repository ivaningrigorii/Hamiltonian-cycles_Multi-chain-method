using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursWork_Ivanin_MainFile_CSharp
{
    class CreatorPointsGraph
    {
        protected List<PointGraph> points { get; set; }

        public CreatorPointsGraph(int countPoints, double diametr)
        {
            points = new List<PointGraph>();
            for (int i = 0; i < countPoints; i++)
            {
                points.Add(coordinatesSearch(countPoints, diametr, i + 1));
            }
        }

        private int FindCenterCoord(double radius)
        {
            return (int)(radius + 0.5 * radius);
        }

        private PointGraph coordinatesSearch(int numberOfPoints, double diametr, int i)
        {
            int k = 1;
            if (diametr>28)
            {
                k = 2;
            }
            PointGraph point = new PointGraph();
            double radius = k*diametr * numberOfPoints / Math.PI;

            point.numberOfPoint = i;
            point.x = point.y = FindCenterCoord(radius);

            if ((i > 1) || ((numberOfPoints) % 2 != 0))
            {
                if (numberOfPoints % 2 == 0)
                    numberOfPoints--;
                double theta = 2d * Math.PI / numberOfPoints;
                point.x = (int)(radius * Math.Cos(theta * i) + point.x);
                point.y = (int)(radius * Math.Sin(theta * i) + point.y);
            }

            return point;
        }
    }
}
