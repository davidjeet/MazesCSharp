using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Core
{
    public static class Helper
    {
        /// Randon Number Helper
        private static readonly Random rnd = new Random();
        private static readonly object syncLock = new object();
        public static int GetRandomNumber(int min, int max)
        {
            lock (syncLock)
            {   // synchronize
                return rnd.Next(min, max);
            }
        }

        public static int GetRandomNumber(int max)
        {
            return GetRandomNumber(0, max);
        }

        public static double GetNextDouble()
        {
            lock (syncLock)
            {   // synchronize
                return rnd.NextDouble();
            }
        }

        public static T Sample<T>(this IEnumerable<T> _list)
        {
            var list = _list.ToList();
            int index = GetRandomNumber(0, list.Count);
            return list[index];
        }

        public static IList<T> Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = GetRandomNumber(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }

            return list;
        }

    }
}
