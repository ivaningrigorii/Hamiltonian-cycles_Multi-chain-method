using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CoursWork_Ivanin_MainFile_CSharp
{
    public interface IMathElement
    {
        int LengthGrathRowsAndCows { get; set; }
        int[,] adjacencyMatrix { get; set; }

        void show(Graphics g);

        string showStringMap();

    }
}
