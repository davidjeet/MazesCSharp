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
    public class GrowingTree : IGrowingTreeAlgorithms
    {
        private Stack<Cell> active;

        public void Run(ref IGrid grid, Func<IEnumerable<Cell>, Cell> SelectionFunction)
        {
            var startAt = grid.GetRandomCell;
            active = new Stack<Cell>();
            active.Push(startAt);

            while(active.Any())
            {
                var cell = SelectionFunction(active);  
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
        }

    }
}
