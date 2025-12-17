using System;
using System.Threading;

namespace ThreadArrayProject
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadMultiArrProcess();
            Console.ReadKey();
        }
        static void ThreadMultiArrProcess()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int mid = numbers.Length / 2;

            Console.WriteLine("Исходный массив: " + string.Join(", ", numbers));

            Thread thread1 = new Thread(() => 
                ArrayThreadHandler.ProcessArrayMulti(numbers, 0, mid));

            Thread thread2 = new Thread(() => 
                ArrayThreadHandler.ProcessArrayMulti(numbers, mid, numbers.Length));

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            Console.WriteLine("\nВсе потоки завершили работу");
            Console.WriteLine("Результат: " + string.Join(", ", numbers));
        }
    }
}
