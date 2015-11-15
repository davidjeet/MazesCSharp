using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Algorithms;
using Infrastructure.Core;
using Infrastructure.Core.Interfaces;
using static Infrastructure.Core.Helper;

namespace GrowingTree_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            IGrid grid = new Grid(20, 20);
            new GrowingTree().Run(ref grid, RandomSelection);                  
            Console.WriteLine("Random Selection");
            Console.WriteLine(grid.ToString(false));
            Console.ReadKey();

            grid = new Grid(20, 20);
            new GrowingTree().Run(ref grid, LastSelection);
            Console.WriteLine("Last Selection");
            Console.WriteLine(grid.ToString(false));
            Console.ReadKey();

            grid = new Grid(20, 20);
            new GrowingTree().Run(ref grid, MixedSelection);
            Console.WriteLine("Mixed Selection");
            Console.WriteLine(grid.ToString(false));
            Console.ReadKey();
        }


        private static Cell RandomSelection(IEnumerable<Cell> list)
        {
            return list.Sample();
        }

        private static Cell LastSelection(IEnumerable<Cell> list)
        {
            return list.Last();
        }

        private static Cell MixedSelection(IEnumerable<Cell> list)
        {
            var rnd = GetRandomNumber(2);
            return (rnd == 0) 
                  ? list.Last() 
                  : list.Sample();
        }
    }
}
