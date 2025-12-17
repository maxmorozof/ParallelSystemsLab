using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParallelOutput
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Запуск асинхронных задач...");

            Task task1 = MessageTask.SayHelloAsync("Задачи №1", 1500);
            Task task2 = MessageTask.SayHelloAsync("Задачи №2", 500);
            Task task3 = MessageTask.SayHelloAsync("Задачи №3", 1000);

            List<Task> tasks = new List<Task> { task1, task2, task3 };

            await Task.WhenAll(tasks);

            Console.WriteLine("\nПрограмма завершена!");
            Console.ReadKey();
        }
    }
}
