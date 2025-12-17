using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FactorialApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            LazyCache cache = new LazyCache();
            List<Task> tasks = new List<Task>();

            Console.WriteLine("Запуск запросов к кэшу");

            for (int i = 0; i < 5; i++)
            {
                tasks.Add(Task.Run(() => {
                    var res = cache.GetFactorial(10);
                    Console.WriteLine($"Поток {Task.CurrentId}: Результат 10! = {res.ToString().Substring(0, 7)}...");
                }));

                tasks.Add(Task.Run(() => {
                    var res = cache.GetFactorial(5);
                    Console.WriteLine($"Поток {Task.CurrentId}: Результат 5! = {res}");
                }));
            }

            await Task.WhenAll(tasks);

            Console.WriteLine("\nВсе операции завершены!");
            Console.ReadKey();
        }
    }
}
