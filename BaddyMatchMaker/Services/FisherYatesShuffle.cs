using BaddyMatchMaker.Helpers;
using System.Collections.Generic;

namespace BaddyMatchMaker.Services
{
    public class FisherYatesShuffle : IShuffleService
    {
        public void Shuffle<T>(IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                int k = (RandomHelper.Rand.Next(0, n) % n);
                n--;
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
