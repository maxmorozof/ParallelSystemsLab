using System;

namespace ArrayParallelSum
{
    public class ArrayProcessor
    {
        public long SumRange(int[] array, int startIndex, int endIndex)
        {
            long total = 0;
            for (int i = startIndex; i < endIndex; i++)
            {
                total += array[i];
            }
            return total;
        }
    }
}
