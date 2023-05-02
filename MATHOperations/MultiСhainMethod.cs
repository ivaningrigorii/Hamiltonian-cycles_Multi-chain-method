using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursWork_Ivanin_MainFile_CSharp
{
    class MultiСhainMethod
    {
        readonly private IMathElement orGraph;

        public MultiСhainMethod(int[,] adjacencyMatrix, int Length)
        {
            orGraph = new Orgraph { LengthGrathRowsAndCows = Length, adjacencyMatrix = adjacencyMatrix };
        }

        private bool WorkWihtGraph(IOperationMachine process)
        {
            return process.mainAction();
        }

        private bool RightCycle(IBugFinder examination)
        {
            bool ok = false;
            ok = (examination.PresenceOfReadyRowsCowsAbsence() && !examination.PresenceOfErrorRowsCowsAbsence());
            if (ok)
            {
                ok = !examination.PresenceOfNotBigCyclesRowsCowsAbsence();
            }

            return ok;
        }

        public List<IMathElement> CreateCyclesFromMainGraph()
        {
            List<IMathElement> listCycle = new List<IMathElement>();
            IOperationMachine processMath = new MathOperationsMachine { graph = orGraph };
            IOperationMachine processIntel = new IntelligentOperationsMachine { graph = orGraph };

            bool availabilityOfBranches = true;
            while (availabilityOfBranches)
            {
                availabilityOfBranches = WorkWihtGraph(processMath);
                IBugFinder examination = processIntel as IBugFinder;
                if (!availabilityOfBranches)
                {
                    if (RightCycle(examination))
                    {
                        listCycle.Add(new GraphCycle { LengthGrathRowsAndCows = orGraph.LengthGrathRowsAndCows, adjacencyMatrix = (int[,])orGraph.adjacencyMatrix.Clone() });
                    }
                    availabilityOfBranches = WorkWihtGraph(processIntel);
                }
            }

            return listCycle;
        }
    }
}
