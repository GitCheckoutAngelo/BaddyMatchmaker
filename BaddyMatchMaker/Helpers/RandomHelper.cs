using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaddyMatchMaker.Helpers
{
    public static class RandomHelper
    {
        public static readonly Random Rand = new Random();

        public static IEnumerable<T> GetRandom<T>(this IEnumerable<T> enumerable, int numberOfItems)
        {
            if (!enumerable.Any())
            {
                throw new ArgumentException("Source can't be empty.");
            }

            var list = enumerable.ToList();

            if (list.Count < numberOfItems)
            {
                throw new ArgumentException("Requested number of items exceeds number of source items.");
            }

            var items = new List<T>();
            for (var i = 0; i < numberOfItems; i++){
                var randomIndex = Rand.Next(list.Count);
                var randomItem = list[randomIndex];
                items.Add(randomItem);
                list.Remove(randomItem);
            }

            return items;
        }

        public static T GetSingleRandom<T>(this IEnumerable<T> enumerable)
        {
            return GetRandom<T>(enumerable, 1).First();
        }
    }
}
