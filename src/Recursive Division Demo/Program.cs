using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Algorithms;
using Infrastructure.Core;
using Infrastructure.Core.Interfaces;
using static Infrastructure.Core.Helper;

namespace Recursive_Division_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            IGrid grid = new Grid(20, 20);
            new RecursiveDivision().Run(ref grid);
            Console.WriteLine(grid.ToString(false));
            Console.ReadKey();
        }
    }
}
