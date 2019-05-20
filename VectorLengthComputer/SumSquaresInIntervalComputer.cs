using System;
using System.Collections.Generic;

namespace VectorLengthComputer
{
    class SumSquaresInIntervalComputer : IVectorLengthComputer
    {
        private int numberOfThreads = 1000;

        public int ComputeLength(int[] a)
        {
            List<Future<int>> sumSquaresList = new List<Future<int>>();

            int partLength = a.Length / numberOfThreads;

            Future<int> tmpFuture = null; 
            for (int i = 0; i < numberOfThreads - 1; ++i)
            {
                int k = i;
                tmpFuture = new Future<int>(new Func<int>(() => SumSquaresInInterval(a, k * partLength, partLength * (1 + k))));
                sumSquaresList.Add(tmpFuture);
            }

            tmpFuture = new Future<int>(new Func<int>(() => SumSquaresInInterval(a, (numberOfThreads - 1) * partLength, a.Length)));
            sumSquaresList.Add(tmpFuture);

            long sum = 0;
            foreach (var t in sumSquaresList)
            {
                sum += t.Result;
            }
            return Convert.ToInt32(Math.Sqrt(sum));
        }

        private int SumSquaresInInterval(int[] a, int firstInd, int secondInd)
        {
            int result = 0;
            for (int i = firstInd; i < secondInd; ++i)
            {
                result += a[i] * a[i];
            }
            return result;
        }
    }
}
