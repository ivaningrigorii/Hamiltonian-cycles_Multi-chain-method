using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursWork_Ivanin_MainFile_CSharp
{
    class BugFinder : IBugFinder
    {
        public IMathElement graph { get; set; }
        public bool PresenceOfNotBigCyclesRowsCowsAbsence()
        {
            bool error = false;
            int[,] matrix = (int[,])graph.adjacencyMatrix.Clone();
            int count = graph.LengthGrathRowsAndCows;
            int i = 0, index = 0;

            while (!error && (count > 0))
            {
                int sum = 0;
                for (int j = 0; j < graph.LengthGrathRowsAndCows; j++)
                {
                    if (matrix[i, j] == 1)
                    {
                        matrix[i, j] = 0;
                        count--;
                        index = j;
                        sum++;
                    }
                }
                if (sum != 0)
                {
                    sum = 0;
                    i = index;
                }
                else
                {
                    error = true;
                }
            }
            return error;
        }
        public bool PresenceOfErrorRowsCowsAbsence()
        {
            bool result = false;
            int sumI = 0, sumJ = 0;
            for (int i = 0; i < graph.LengthGrathRowsAndCows; i++)
            {
                for (int j = 0; j < graph.LengthGrathRowsAndCows; j++)
                {
                    sumI += graph.adjacencyMatrix[i, j];
                    sumJ += graph.adjacencyMatrix[j, i];
                }
                if (sumJ == 0 || sumI == 0)
                {
                    result = true;
                    break;
                }
                sumI = 0; sumJ = 0;
            }
            return result;
        }
        public bool PresenceOfReadyRowsCowsAbsence()
        {
            bool result = true;
            int countNode = 0;
            for (int i = 0; i < graph.LengthGrathRowsAndCows; i++)
            {
                for (int j = 0; j < graph.LengthGrathRowsAndCows; j++)
                {
                    if (graph.adjacencyMatrix[i, j] == 1) countNode++;
                }
                if (countNode != 1)
                {
                    result = false;
                    break;
                }
                else
                {
                    countNode = 0;
                }
            }
            return result;
        }
    }
}
