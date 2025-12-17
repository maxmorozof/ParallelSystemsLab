using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CounterApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            SafeCounter counter = new SafeCounter();
            
            int threadCount = 10;
            int incrementsPerThread = 1000;
            
            List<Task> tasks = new List<Task>();

            Console.WriteLine($"Запуск {threadCount} потоков по {incrementsPerThread} инкрементов");

            for (int i = 0; i < threadCount; i++)
            {
                tasks.Add(Task.Run(() =>
                {
                    for (int j = 0; j < incrementsPerThread; j++)
                    {
                        counter.Increment();
                    }
                }));
            }
            await Task.WhenAll(tasks);

            Console.WriteLine("Результат проверки");
            Console.WriteLine($"Ожидалось: {threadCount * incrementsPerThread}");
            Console.WriteLine($"Получено:  {counter.Value}");
            
            if (counter.Value == threadCount * incrementsPerThread)
            {
                Console.WriteLine("Успешно! Потокобезопасно");
            }
            else
            {
                Console.WriteLine("Ошибка! Данные повреждены)");
            }
            Console.ReadKey();
        }
    }
}
