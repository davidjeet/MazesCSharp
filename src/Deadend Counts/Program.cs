using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Algorithms;
using Infrastructure.Core;
using Infrastructure.Core.Interfaces;
namespace Deadend_Counts
{
    class Program
    {
        static void Main(string[] args)
        {
            var algorithms = new IAlgorithms[] { new BinaryTree(), new SideWinder(),
                new AldousBroder(), new HuntAndKill(), new RecursiveBacktracker() };

            var tries = 100;
            var size = 20;

            var averages = new Dictionary<string, double>();

            foreach(var algorithm in algorithms)
            {
                var name = algorithm.GetType().Name;
                Console.WriteLine($"Running {name} algorithm");
                var deadendCounts = new List<int>();
                for(int i=0;i<tries;i++)
                {
                    IGrid grid = new Grid(size, size);
                    algorithm.Run(ref grid);
                    deadendCounts.Add(((Grid)grid).DeadEnds.Count());                     
                }

                var totalDeadends = deadendCounts.Sum();
                averages.Add(name, totalDeadends / deadendCounts.Count);
            }


            var totalCells = size * size;
            Console.WriteLine(" ");
            Console.WriteLine($"Average dead-ends per {size}x{size} maze ({totalCells} cells)");
            Console.WriteLine(" ");

            var sortedAlgorithm = averages.OrderByDescending(kvp => kvp.Value);
            foreach(var algorithm in sortedAlgorithm)
            {
                var percentage = (algorithm.Value * 100.0) / (size * size);
                Console.WriteLine($"{algorithm.Key}: {algorithm.Value}/{size*size} ({percentage}%)");
            }

            Console.ReadKey();
        }

    }
}
