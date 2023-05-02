using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CoursWork_Ivanin_MainFile_CSharp
{
    class GraphCycle : Orgraph, IMathElement
    {
        public override void show(Graphics g)
        {
            int diam = 28;
            if (LengthGrathRowsAndCows < 5)
                diam = 40;
            CreatorGraficElements graficElementsForGraph = new CreatorGraficElements(this, diam);
            for (int i = 0; i < graficElementsForGraph.lines.Count; i++)
            {
                graficElementsForGraph.lines[i].draw(g, Color.Aquamarine, 2);
            }
            for (int i = 0; i < this.LengthGrathRowsAndCows; i++)
            {
                graficElementsForGraph.stringDraw[i].draw(g, Color.Green, 1);
                graficElementsForGraph.nodes[i].draw(g, Color.Gray, 1);
            }
        }

        public override string showStringMap()
        {
            string s ="";
            int count = this.LengthGrathRowsAndCows;
            int i = 0;
            while (count>0)
            {
                for (int j = 0; j < LengthGrathRowsAndCows; j++)
                {
                    if (adjacencyMatrix[i, j] == 1)
                    {
                        i = j;
                        s += $"{(j + 1) } ";
                        break;
                    }
                }
                count--;
            }
            return s;
        }
    }
}
