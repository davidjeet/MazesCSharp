using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Algorithms;
using Infrastructure.Core;
using Infrastructure.Core.Interfaces;

namespace Recursive_Backtracker_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            IGrid grid = new Grid(10, 10);
            new RecursiveBacktracker().Run(ref grid);
            Console.WriteLine("No Braiding");
            Console.WriteLine(grid.ToString(false));
            Console.ReadKey();

            ((Grid)grid).Braid(0.5); // braiding
            Console.WriteLine("With Braiding");
            Console.WriteLine(grid.ToString(false));
            Console.ReadKey();
        }
    }
}
