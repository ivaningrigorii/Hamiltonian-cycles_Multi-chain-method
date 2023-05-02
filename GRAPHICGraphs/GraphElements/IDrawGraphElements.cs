using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CoursWork_Ivanin_MainFile_CSharp
{
    interface IDrawGraphElements
    {
        void draw(Graphics g, Color color, int sizeLine);
    }
}
