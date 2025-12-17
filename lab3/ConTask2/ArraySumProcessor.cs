using System;
using System.Threading;

namespace ThreadPoolSumApp
{
    public class SumState
    {
        public int[] Numbers;
        public long TotalSum = 0;
        public int StartIndex;
        public int EndIndex;
        public static readonly object LockObject = new object();
        public ManualResetEvent DoneEvent;
    }

    public class ArraySumProcessor
    {
        public static void ProcessSumPartial(object state)
        {
            Console.WriteLine($"Поток {Thread.CurrentThread.ManagedThreadId} начал работу!");
            SumState sumState = state as SumState;
            long partialSum = 0;

            for (int i = sumState.StartIndex; i < sumState.EndIndex; i++)
            {
                partialSum += sumState.Numbers[i];
            }

            lock (SumState.LockObject)
            {
                sumState.TotalSum += partialSum;
            }

            Console.WriteLine($"Поток {Thread.CurrentThread.ManagedThreadId} завершил работу!");
            sumState.DoneEvent.Set();
        }
    }
}