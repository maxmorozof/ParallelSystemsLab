using System;
using System.Threading;

namespace ThreadMaxApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadMaxArrProcess();
            Console.ReadKey();
        }

        static void ThreadMaxArrProcess()
        {
            int[] numbers = { 3, 17, 5, 22, 9, 11, 8, 30, 15 };
            int midIndex = numbers.Length / 2;

            MaxState.GlobalMax = int.MinValue;

            MaxState state1 = new MaxState 
            { 
                Numbers = numbers, StartIndex = 0, EndIndex = midIndex 
            };
            MaxState state2 = new MaxState 
            { 
                Numbers = numbers, StartIndex = midIndex, EndIndex = numbers.Length 
            };

            ThreadPool.QueueUserWorkItem(ArrayMaxProcessor.FindMaxPartial, state1);
            ThreadPool.QueueUserWorkItem(ArrayMaxProcessor.FindMaxPartial, state2);

            Console.WriteLine("Запущен поиск максимального значения в двух потоках!");
            Thread.Sleep(1000); 

            int maxResult = MaxState.GlobalMax;

            Console.WriteLine("\nПотоки завершили работу!");
            Console.WriteLine("Массив: " + string.Join(", ", numbers));
            Console.WriteLine($"Максимальное значение в массиве: {maxResult}");
        }
    }
}
