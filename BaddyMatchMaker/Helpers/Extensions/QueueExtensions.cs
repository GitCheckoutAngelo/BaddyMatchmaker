using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaddyMatchMaker.Helpers.Extensions
{
    public static class QueueExtensions
    {
        public static IEnumerable<T> DequeueMultiple<T>(this Queue<T> queue, int size)
        {
            for (int i = 0; i < size && queue.Count > 0; i++)
            {
                yield return queue.Dequeue();
            }
        }
    }
}
