using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskSystem
{
    class Program
    {
        static async Task Main(string[] args)
        {
            WorkQueue workQueue = new WorkQueue();

            for (int i = 1; i <= 20; i++)
            {
                workQueue.AddTask($"Документ №{i}");
            }

            Console.WriteLine("\nНачинаем обработку несколькими потоками\n");

            List<Task> workers = new List<Task>();
            
            for (int i = 1; i <= 3; i++)
            {
                string workerName = $"Обработчик {i}";
                workers.Add(Task.Run(() => workQueue.ProcessTasks(workerName)));
            }
            
            await Task.WhenAll(workers);

            Console.WriteLine("\nВсе задачи обработаны!");
            Console.ReadKey();
        }
    }
}

