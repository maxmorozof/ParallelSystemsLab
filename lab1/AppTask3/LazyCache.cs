using System;
using System.Collections.Generic;
using System.Numerics;

namespace FactorialApp
{
    public class LazyCache
    {
        private readonly Dictionary<int, BigInteger> _cache = new Dictionary<int, BigInteger>();
        private readonly object _lock = new object();

        public BigInteger GetFactorial(int n)
        {
            lock (_lock)
            {
                if (_cache.ContainsKey(n))
                {
                    Console.WriteLine($" Кэш - Значение для {n} найдено!");
                    return _cache[n];
                }
            }

            Console.WriteLine($"Вычисление - Считаем факториал для {n}...");
            BigInteger result = Calculate(n);

            lock (_lock)
            {
                if (!_cache.ContainsKey(n))
                {
                    _cache.Add(n, result);
                }
            }

            return result;
        }

        private BigInteger Calculate(int n)
        {
            if (n < 0) throw new ArgumentException("Число должно быть положительным");
            
            BigInteger result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            System.Threading.Thread.Sleep(500); 
            return result;
        }
    }
}