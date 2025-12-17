using System;
using System.Collections.Generic;
using System.Threading;

namespace ThreadPoolFilterApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadPoolFilterMoreThenFiveProcess();
            Console.ReadKey();
        }
        static void ThreadPoolFilterMoreThenFiveProcess()
        {
            int[] numbers = { 1, 8, 3, 10, 5, 6, 2, 9, 7, 4 };
            List<int> filteredNumbers = new List<int>();
            int midIndex = numbers.Length / 2;

            using var doneEvent1 = new ManualResetEvent(false);
            using var doneEvent2 = new ManualResetEvent(false);

            FilterState state1 = new FilterState
            {
                Numbers = numbers,
                StartIndex = 0,
                EndIndex = midIndex,
                ResultList = filteredNumbers,
                DoneEvent = doneEvent1
            };
            FilterState state2 = new FilterState
            {
                Numbers = numbers,
                StartIndex = midIndex,
                EndIndex = numbers.Length,
                ResultList = filteredNumbers,
                DoneEvent = doneEvent2
            };

            ThreadPool.QueueUserWorkItem(ArrayFilterProcessor.FilterMoreThanFive, state1);
            ThreadPool.QueueUserWorkItem(ArrayFilterProcessor.FilterMoreThanFive, state2);

            WaitHandle.WaitAll(new WaitHandle[] { doneEvent1, doneEvent2 });

            Console.WriteLine("\nРезультат фильтрации (числа > 5):");
            Console.WriteLine(string.Join(", ", filteredNumbers));
        }
    }
}