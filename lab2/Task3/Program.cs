using System;
using System.Linq;
using System.Threading.Tasks;

namespace ArrayParallelSum
{
    class Program
    {
        static async Task Main(string[] args)
        {
            int[] numbers = Enumerable.Range(1, 1000000).ToArray();
            ArrayProcessor processor = new ArrayProcessor();

            int mid = numbers.Length / 2;

            Console.WriteLine($"Обработка массива из {numbers.Length} элементов");

            Task<long> task1 = Task.Run(() => processor.SumRange(numbers, 0, mid));
            
            Task<long> task2 = Task.Run(() => processor.SumRange(numbers, mid, numbers.Length));

            await Task.WhenAll(task1, task2);

            long partialSum1 = await task1;
            long partialSum2 = await task2;
            long totalSum = partialSum1 + partialSum2;

            Console.WriteLine($"Результаты вычислений");
            Console.WriteLine($"Сумма первой части:{partialSum1:N0}");
            Console.WriteLine($"Сумма второй части:{partialSum2:N0}");
            Console.WriteLine($"Общая сумма:{totalSum:N0}");

            long expected = (long)numbers.Length * (numbers.Length + 1) / 2;
            Console.WriteLine($"Ожидаемая сумма:{expected:N0}");
            Console.WriteLine(totalSum == expected ? "Корректно" : "Ошибка");

            Console.ReadKey();
        }
    }
}