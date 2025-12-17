using System;

namespace CounterApp
{
    public class SafeCounter
    {
        private int _value = 0;
        private readonly object _lockObject = new object();

        public int Value => _value;
        public void Increment()
        {
            lock (_lockObject)
            {
                _value++;
            }
        }

        public void Decrement()
        {
            lock (_lockObject)
            {
                _value--;
            }
        }
    }
}
