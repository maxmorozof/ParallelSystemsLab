using System;
using System.Numerics;
using System.Threading.Tasks;

namespace ParallelCalculations
{
    class Program
    {
        static async Task Main(string[] args)
        {
            MathCalculator calculator = new MathCalculator();

            Console.WriteLine("Начало параллельных вычислений");

            Task<BigInteger> factorialTask = Task.Run(() => calculator.CalculateFactorial(20));
            Task<long> sumTask = Task.Run(() => calculator.CalculateSum(100000));

            await Task.WhenAll(factorialTask, sumTask);

            BigInteger factorialResult = await factorialTask;
            long sumResult = await sumTask;

            Console.WriteLine("Результаты!");
            Console.WriteLine($"Факториал числа 20: {factorialResult}");
            Console.WriteLine($"Сумма чисел до 100 000: {sumResult}");
            Console.ReadKey();
        }
    }
}
