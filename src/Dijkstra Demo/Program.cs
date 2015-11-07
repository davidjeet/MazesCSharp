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

            var distanceGrid = (DistanceGrid)grid; //casting to a distance grid to take advantage of the "distances" property
            distanceGrid.CellDistances = distances;
            Console.WriteLine(grid.ToString(false));

            Console.WriteLine("Path from NW corner to SW corner:");
            distanceGrid.CellDistances = distances.PathToGoal(grid[grid.Rows-1, 0]);
            Console.WriteLine(grid.ToString(false));

            Console.ReadKey();
        }
    }
}
