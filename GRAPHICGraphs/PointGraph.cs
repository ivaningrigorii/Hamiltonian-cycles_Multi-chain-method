using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursWork_Ivanin_MainFile_CSharp
{
    class PointGraph
    {
        public int x { get; set; }
        public int y { get; set; }

        public int numberOfPoint { get; set; }

        public PointGraph Clone()
        {
            return (new PointGraph { x = this.x, y = this.y, numberOfPoint = this.numberOfPoint });
        }
    }
}
