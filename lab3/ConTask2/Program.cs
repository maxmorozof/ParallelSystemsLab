using System;
using System.Threading;

namespace ThreadPoolSumApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadPoolSumProcess();
            Console.ReadKey();
        }
        static void ThreadPoolSumProcess()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int midIndex = numbers.Length / 2;
            var doneEvent1 = new ManualResetEvent(false);
            var doneEvent2 = new ManualResetEvent(false);

            SumState state1 = new SumState 
            { 
                Numbers = numbers, StartIndex = 0, EndIndex = midIndex, DoneEvent = doneEvent1 
            };
            SumState state2 = new SumState 
            { 
                Numbers = numbers, StartIndex = midIndex, EndIndex = numbers.Length, DoneEvent = doneEvent2 
            };

            ThreadPool.QueueUserWorkItem(ArraySumProcessor.ProcessSumPartial, state1);
            ThreadPool.QueueUserWorkItem(ArraySumProcessor.ProcessSumPartial, state2);

            Console.WriteLine("Задачи поставлены в очередь. Ожидание завершения!");

            WaitHandle.WaitAll(new WaitHandle[] { doneEvent1, doneEvent2 });

            long totalSum = state1.TotalSum; 

            Console.WriteLine("\nВсе потоки завершили работу!");
            Console.WriteLine($"Общая сумма элементов массива: {totalSum}");
        }
    }
}