using System;
using System.Collections.Generic;

namespace VectorLengthComputer
{
    class SquareAndSumComputer : IVectorLengthComputer
    {
        private int numberOfThreads = 1000;

        public int ComputeLength(int[] a)
        {
            int numberOfSquaresList = a.Length / numberOfThreads == 0 ? 1 : a.Length / numberOfThreads;

            List<Future<List<int>>> squaresList = new List<Future<List<int>>>();
            Future<List<int>> tmpListIntFuture = null;

            for (int i = 0; i < numberOfSquaresList - 1; ++i)
            {
                int k = i;
                tmpListIntFuture = new Future<List<int>>(new Func<List<int>>(() => CreateListOfSquares(a, k * numberOfThreads, numberOfThreads * (1 + k))));
                squaresList.Add(tmpListIntFuture);
            }
            tmpListIntFuture = new Future<List<int>>(new Func<List<int>>(() => CreateListOfSquares(a, (numberOfSquaresList - 1) * numberOfThreads, a.Length)));
            squaresList.Add(tmpListIntFuture);

            List<Future<int>> sumSquaresList = new List<Future<int>>();
            Future<int> tmpIntFuture = null;

            foreach (var list in squaresList)
            {
                tmpIntFuture = new Future<int>(new Func<int>(() =>
                {
                    int sum = 0;
                    foreach (var elem in list.Result)
                    {
                        sum += elem;
                    }
                    return sum;
                }));
                sumSquaresList.Add(tmpIntFuture);
            }
            
            long result = 0;
            foreach (var sum in sumSquaresList)
            {
                result += sum.Result;
            }
            return Convert.ToInt32(Math.Sqrt(result));
        }

        public List<int> CreateListOfSquares(int[] a, int firstInd, int secondInd)
        {
            List<int> result = new List<int>();
            for (int i = firstInd; i < secondInd; ++i)
            {
                result.Add(a[i] * a[i]);
            }
            return result;
        }
    }
}
