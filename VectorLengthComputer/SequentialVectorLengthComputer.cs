using System;

namespace VectorLengthComputer
{
    class SequentialVectorLengthComputer : IVectorLengthComputer
    {
        public int ComputeLength(int[] a)
        {
            long sum = 0;
            for (int i = 0; i < a.Length; ++i)
            {
                sum += a[i] * a[i];
            }
            return Convert.ToInt32(Math.Sqrt(sum));
        }
    }
}
