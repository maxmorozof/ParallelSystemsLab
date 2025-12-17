using System;
using System.Threading;

namespace ThreadMaxApp
{
    public class MaxState
    {
        public int[]? Numbers;
        public int StartIndex;
        public int EndIndex;
        public static int GlobalMax = int.MinValue;
        public static readonly object LockObject = new object();
    }

    public class ArrayMaxProcessor
    {
        public static void FindMaxPartial(object? state)
        {
            Console.WriteLine($"Поток {Thread.CurrentThread.ManagedThreadId} начал работу!");
            
            if (state is MaxState maxState && maxState.Numbers != null)
            {
                int currentMax = int.MinValue;

                for (int i = maxState.StartIndex; i < maxState.EndIndex; i++)
                {
                    if (maxState.Numbers[i] > currentMax)
                    {
                        currentMax = maxState.Numbers[i];
                    }
                }

                lock (MaxState.LockObject)
                {
                    if (currentMax > MaxState.GlobalMax)
                    {
                        MaxState.GlobalMax = currentMax;
                    }
                }
                Console.WriteLine($"Поток {Thread.CurrentThread.ManagedThreadId} завершил работу! Максимум: {currentMax}");
            }
        }
    }
}