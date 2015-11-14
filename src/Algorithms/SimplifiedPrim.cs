using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Core;
using Infrastructure.Core.Interfaces;

namespace Infrastructure.Algorithms
{
    public class SimplifiedPrim : IAlgorithms
    {
        public void Run(ref IGrid grid)
        {
            var startAt = grid.GetRandomCell;
            Stack<Cell> active = new Stack<Cell>();
            active.Push(startAt);
            int iterations = 1;
            while(active.Any())
            {
                iterations++;
                var cell = active.Sample();
                var availableNeighbors = cell.Neighbors.Where(x => x.Links.Count == 0);

                if (availableNeighbors.Any())
                {
                    var neighbor = availableNeighbors.Sample();
                    cell.Link(neighbor);
                    active.Push(neighbor);
                }
                else
                {
                    var list = active.ToList();
                    list.Remove(cell);
                    active = new Stack<Cell>(list);
                }
            }
            Console.WriteLine($"Iterations: {iterations}");
        }
    }
}
