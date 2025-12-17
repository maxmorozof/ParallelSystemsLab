using System;
using System.Collections.Generic;

namespace TaskSystem
{
    public class WorkQueue
    {
        private readonly Queue<string> _tasks = new Queue<string>();
        private readonly object _lock = new object();

        public void AddTask(string task)
        {
            lock (_lock)
            {
                _tasks.Enqueue(task);
                Console.WriteLine($"[+] Задача добавлена: {task}");
            }
        }

        public void ProcessTasks(string workerName)
        {
            while (true)
            {
                string currentTask = null;

                lock (_lock)
                {
                    if (_tasks.Count > 0)
                    {
                        currentTask = _tasks.Dequeue();
                    }
                    else
                    {
                        break; 
                    }
                }

                if (currentTask != null)
                {
                    Console.WriteLine($"    {workerName} начал: {currentTask}");
                    System.Threading.Thread.Sleep(100); 
                    Console.WriteLine($"    {workerName} завершил: {currentTask}");
                }
            }
        }
    }
}
