using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursWork_Ivanin_MainFile_CSharp
{
    interface IBugFinder
    {
        IMathElement graph { get; set; }
        bool PresenceOfReadyRowsCowsAbsence();
        bool PresenceOfErrorRowsCowsAbsence();
        bool PresenceOfNotBigCyclesRowsCowsAbsence();
    }
}
