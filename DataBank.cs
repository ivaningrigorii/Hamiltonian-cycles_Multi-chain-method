using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursWork_Ivanin_MainFile_CSharp
{
    static class DataBank
    {
        private static bool boolNextForm = false;

        public static bool boolNewList
        {
            get { return boolNextForm;  }
            set { boolNextForm = value; }
        }

        public static List<IMathElement> listOfCycles { get; set; }
    }
}
