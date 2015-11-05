using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Algorithms;
using Infrastructure.Core;
using Infrastructure.Core.Interfaces;

namespace Dijkstra_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            IGrid grid = new DistanceGrid(5, 5);
            BinaryTree.Run(ref grid);

            var start = grid[0, 0];
            var distances = start.distances;

            var grid2 = (DistanceGrid)grid;
            grid2.distances = distances;

            Console.WriteLine(grid.ToString(false));
            Console.ReadKey();
        }
    }
}
