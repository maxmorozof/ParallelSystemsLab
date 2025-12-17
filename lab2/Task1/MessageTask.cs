using System;
using System.Threading.Tasks;

namespace ParallelOutput
{
    public class MessageTask
    {
        public static async Task SayHelloAsync(string name, int delay)
        {
            await Task.Delay(delay);
            Console.WriteLine($"Привет от {name}! - Задержка: {delay}мс");
        }
    }
}
