using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursWork_Ivanin_MainFile_CSharp
{
    class IntelligentOperationsMachine : BugFinder, IOperationMachine
    {
        private List<SaveForBranching> saveList = new List<SaveForBranching>();

        //Work with Branches
        private int FindBranches()
        {
            int indexValue = 0;

            for (int i = 0; i < graph.LengthGrathRowsAndCows; i++)
            {
                int sum = 0;
                for (int j = 0; j < graph.LengthGrathRowsAndCows; j++)
                {
                    sum += graph.adjacencyMatrix[i, j];
                }

                if (sum > 1)
                {
                    indexValue = i;
                    break;
                }
                else
                {
                    sum = 0;
                }
            }

            return indexValue;
        }
        private void AddListBranches()
        {
            int Index = FindBranches();

            for (int j = 0; j < graph.LengthGrathRowsAndCows; j++)
            {
                if (graph.adjacencyMatrix[Index, j] == 1)
                {
                    saveList.Add(new SaveForBranching { row = Index, cow = j, adjacencyMatrix = (int[,])graph.adjacencyMatrix.Clone() });
                }
            }
        }
        private void Nuller(int indexI, int indexJ)
        {
            for (int j = 0; j < graph.LengthGrathRowsAndCows; j++)
                graph.adjacencyMatrix[indexI, j] = 0;

            graph.adjacencyMatrix[indexI, indexJ] = 1;
        }
        private void PickFromListBranches()
        {
            int ixLGr = saveList.Count - 1;
            int i = saveList[ixLGr].row, j = saveList[ixLGr].cow;
            graph.adjacencyMatrix = (int[,])saveList[ixLGr].adjacencyMatrix.Clone();

            saveList.RemoveAt(ixLGr);

            Nuller(i, j);
        }

        public bool mainAction()
        {
            bool availabilityOfBranches = false;

            if ((!PresenceOfErrorRowsCowsAbsence()) && (!PresenceOfReadyRowsCowsAbsence() && (!PresenceOfNotBigCyclesRowsCowsAbsence())))
            {
                AddListBranches();
            }

            if (saveList.Count > 0)
            {
                availabilityOfBranches = true;
                PickFromListBranches();
            }

            return availabilityOfBranches;
        }
    }
}
