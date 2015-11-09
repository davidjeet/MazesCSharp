using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Algorithms;
using Infrastructure.Core;
using Infrastructure.Core.Interfaces;

namespace Binary_Tree_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            IGrid grid = new Grid(10, 10);
            BinaryTree.Run(ref grid);

            Console.WriteLine(grid.ToString(true));
            ////Console.WriteLine(grid.ToDebug());

            var deadends = ((Grid)grid).DeadEnds;
            Console.WriteLine($"There were {deadends.Count()} dead ends found.");
            Console.ReadKey();
        }
    }
}
