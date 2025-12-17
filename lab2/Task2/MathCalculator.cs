using System;
using System.Numerics;
using System.Threading.Tasks;

namespace ParallelCalculations
{
    public class MathCalculator
    {
        public BigInteger CalculateFactorial(int n)
        {
            BigInteger result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            Task.Delay(1000).Wait(); 
            return result;
        }
        public long CalculateSum(int n)
        {
            long sum = 0;
            for (int i = 1; i <= n; i++)
            {
                sum += i;
            }
            Task.Delay(800).Wait();
            return sum;
        }
    }
}