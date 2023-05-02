using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursWork_Ivanin_MainFile_CSharp
{
    class CreatorGraficElements : CreatorPointsGraph
    {
        public List<IDrawGraphElements> nodes { get; set; }
        public List<IDrawGraphElements> lines { get; set; }
        public List<IDrawGraphElements> stringDraw { get; set; }

        private void createNodes(int diamElements, IMathElement graf)
        {
            for (int i = 0; i < graf.LengthGrathRowsAndCows; i++)
            {
                nodes.Add(new Nodes { point = points[i].Clone(), radiusEllipse = diamElements });
            }
        }
        private void createStringDraws(int diamElements, IMathElement graf)
        {
            for (int i = 0; i < graf.LengthGrathRowsAndCows; i++)
            {
                stringDraw.Add(new StringDraw { point = points[i].Clone() });
            }
        }
        private void createLines(IMathElement graf, int r)
        {
            for (int i = 0; i < graf.LengthGrathRowsAndCows; i++)
            {
                for (int j = 0; j < graf.LengthGrathRowsAndCows; j++)
                {
                    if (graf.adjacencyMatrix[i, j] == 1)
                    {
                        lines.Add(new Line { point1 = points[i].Clone(), point2 = points[j].Clone(), diameter = r });
                    }
                }
            }
        }

        public CreatorGraficElements(IMathElement graf, int radiusEl) : base(graf.LengthGrathRowsAndCows, radiusEl)
        {
            int diamElements = radiusEl;
            nodes = new List<IDrawGraphElements>();
            lines = new List<IDrawGraphElements>();
            stringDraw = new List<IDrawGraphElements>();

            createNodes(diamElements, graf);
            createStringDraws(diamElements, graf);
            createLines(graf, diamElements);
        }
    }
}
