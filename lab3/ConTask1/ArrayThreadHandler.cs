using System;
using System.Threading;

namespace ThreadArrayProject
{
    public class ArrayThreadHandler
    {
        public static void ProcessArrayMulti(int[] array, int startIndex, int endIndex)
        {
            Console.WriteLine($"Поток {Thread.CurrentThread.ManagedThreadId} начал обработку диапазона: {startIndex} - {endIndex-1}");

            for (int i = startIndex; i < endIndex; i++)
            {
                array[i] *= 2;
            }

            Thread.Sleep(500); 
            Console.WriteLine($"Поток {Thread.CurrentThread.ManagedThreadId} завершил работу.");
        }
    }
}
