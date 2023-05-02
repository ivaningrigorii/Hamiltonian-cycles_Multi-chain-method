using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursWork_Ivanin_MainFile_CSharp
{
    interface IOperationMachine
    {
        IMathElement graph { get; set; }
        bool mainAction();
    }
}
