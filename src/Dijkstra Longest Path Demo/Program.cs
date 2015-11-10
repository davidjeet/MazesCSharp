using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Algorithms;
using Infrastructure.Core;
using Infrastructure.Core.Interfaces;

namespace Dijkstra_Longest_Path_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            IGrid grid = new DistanceGrid(5, 5);
            new BinaryTree().Run(ref grid);

            var start = grid[0, 0];
            Distances distances = start.Distances;

            var newStart = distances.Max.Cell;
            var distance = distances.Max.Distance;

            var newDistances = newStart.Distances;
            MaxResult result = newDistances.Max;

            DistanceGrid distanceGrid = (DistanceGrid)grid;
            distanceGrid.CellDistances = newDistances.PathToGoal(result.Cell);

            Console.WriteLine(distanceGrid.ToString(false));

            Console.ReadKey();
        }
    }
}
