using System;

namespace VectorLengthComputer
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random(DateTime.Now.Millisecond);
            int[] vector = new int[1000000];
            for (int i = 0; i < 1000000; i++)
            {
                vector[i] = random.Next(1000);
            }
            var sumSquaresComputer = new SumSquaresInIntervalComputer();
            var squareAndSumComputer = new SquareAndSumComputer();
            var sequentialComputer = new SequentialVectorLengthComputer();
            int startComputingTime;
            int endComputingTime;

            startComputingTime = DateTime.Now.Millisecond;
            Console.WriteLine(sumSquaresComputer.ComputeLength(vector));
            endComputingTime = DateTime.Now.Millisecond;
            Console.WriteLine("SumSquaresInInterval comptute takes {0} Milliseconds", endComputingTime - startComputingTime);

            startComputingTime = DateTime.Now.Millisecond;
            Console.WriteLine(squareAndSumComputer.ComputeLength(vector));
            endComputingTime = DateTime.Now.Millisecond;
            Console.WriteLine("SquaresAndSum comptute takes {0} Milliseconds", endComputingTime - startComputingTime);

            startComputingTime = DateTime.Now.Millisecond;
            Console.WriteLine(sequentialComputer.ComputeLength(vector));
            endComputingTime = DateTime.Now.Millisecond;
            Console.WriteLine("Sequential comptute takes {0} Milliseconds", endComputingTime - startComputingTime);

            Console.ReadKey();
        }
    }
}
