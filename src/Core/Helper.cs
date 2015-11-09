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
            { // synchronize
                return rnd.Next(min, max);
            }
        }

        public static T Sample<T>(this IEnumerable<T> _list)
        {
            var list = _list.ToList();
            int index = GetRandomNumber(0, list.Count);
            return  list[index];
        }

    }
}
