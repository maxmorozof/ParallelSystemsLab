using System;
using System.Collections.Generic;
using System.Threading;

namespace ThreadPoolFilterApp
{
    public class FilterState
    {
        public int[]? Numbers;
        public int StartIndex;
        public int EndIndex;
        public List<int>? ResultList;
        public ManualResetEvent? DoneEvent;
        public static readonly object LockObject = new object();
    }

    public class ArrayFilterProcessor
    {
        public static void FilterMoreThanFive(object? state)
        {
            Console.WriteLine($"Поток {Thread.CurrentThread.ManagedThreadId} начал фильтрацию сегмента");

            if (state is FilterState filterState && filterState.Numbers != null && filterState.ResultList != null)
            {
                List<int> localResults = new List<int>();

                for (int i = filterState.StartIndex; i < filterState.EndIndex; i++)
                {
                    if (filterState.Numbers[i] > 5)
                    {
                        localResults.Add(filterState.Numbers[i]);
                    }
                }

                lock (FilterState.LockObject)
                {
                    filterState.ResultList.AddRange(localResults);
                }

                filterState.DoneEvent?.Set();
            }

            Console.WriteLine($"Поток {Thread.CurrentThread.ManagedThreadId} завершил работу!");
        }
    }
}