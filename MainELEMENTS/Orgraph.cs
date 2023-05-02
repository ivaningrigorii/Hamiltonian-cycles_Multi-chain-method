using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CoursWork_Ivanin_MainFile_CSharp
{
    class Orgraph : IMathElement
    {
        public int LengthGrathRowsAndCows { get; set; }
        public int[,] adjacencyMatrix { get; set; }

        public virtual void show(Graphics g) 
        {
            int diam = 28;
            if (LengthGrathRowsAndCows < 5)
                diam = 29;
            else if (LengthGrathRowsAndCows > 14)
                diam = 12;
            CreatorGraficElements graficElementsForGraph = new CreatorGraficElements(this, diam);
            for (int i = 0; i < graficElementsForGraph.lines.Count; i++)
            {
                graficElementsForGraph.lines[i].draw(g, Color.Black, 2);
            }
            for (int i = 0; i < this.LengthGrathRowsAndCows; i++)
            {
                graficElementsForGraph.stringDraw[i].draw(g, Color.Black, 1);
                graficElementsForGraph.nodes[i].draw(g, Color.Red, 1);
            }
        }

        public virtual string showStringMap()
        {
            return "------";
        }
    }
}
