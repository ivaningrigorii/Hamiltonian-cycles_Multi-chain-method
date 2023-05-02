using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursWork_Ivanin_MainFile_CSharp
{
    class MathOperationsMachine : IOperationMachine
    {
        public IMathElement graph { get; set; }

        private void RemovingExtraEdges(int jIndex, int iIndex)
        {
            for (int i = 0; i < graph.LengthGrathRowsAndCows; i++)
            {
                if (i != iIndex) graph.adjacencyMatrix[jIndex, i] = 0;
            }
        }

        private int SumRow(int i)
        {
            int sum = 0;
            for (int j = 0; j < graph.LengthGrathRowsAndCows; j++)
            {
                sum += graph.adjacencyMatrix[i, j];
            }
            return sum;
        }

        public bool mainAction()
        {
            bool makeSecondStep = false;
            for (int i = 0; i < graph.LengthGrathRowsAndCows; i++)
            {
                int sumCow = 0, indexJ = 0;
                //поиск стобца, в котором одна единица
                for (int j = 0; j < graph.LengthGrathRowsAndCows; j++)
                {
                    sumCow += graph.adjacencyMatrix[j, i];
                    if (graph.adjacencyMatrix[j, i] == 1) indexJ = j;
                }

                if ((sumCow == 1) && (SumRow(indexJ) != 1))
                {
                    RemovingExtraEdges(indexJ, i);

                    makeSecondStep = true;
                }

            }
            return makeSecondStep;
        }
    }
}

