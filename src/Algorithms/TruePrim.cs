using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Core;
using Infrastructure.Core.Interfaces;
using static Infrastructure.Core.Helper;

namespace Infrastructure.Algorithms
{
    public class TruePrim : IAlgorithms
    {
        private Stack<Cell> active;
        private Dictionary<Cell, int> costs;

        public void Run(ref IGrid grid)
        {
            var startAt = grid.GetRandomCell;
            active = new Stack<Cell>();
            active.Push(startAt);

            costs = new Dictionary<Cell, int>();
            foreach(var cell in grid)
            {
                costs[cell] = GetRandomNumber(0, 100);
            }

            int iterations = 1;
            while(active.Any())
            {
                iterations++;
                var cell = Min(active);  // Get the minimum value in the *active* set
                var availableNeighbors = cell.Neighbors.Where(x => x.Links.Count == 0);

                if (availableNeighbors.Any())
                {
                    var neighbor = Min(availableNeighbors); // Get the minimum value in the *availableNeighbors* set
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


        private Cell Min(IEnumerable<Cell> cells)
        {
            Cell lowest = null;
            int lowestValue = int.MaxValue;
            foreach(var cell in cells)
            {
                int cost = costs[cell];
                if (cost < lowestValue)
                {
                    lowestValue = cost;
                    lowest = cell;
                }
            }

            return lowest;
        }
    }
}
