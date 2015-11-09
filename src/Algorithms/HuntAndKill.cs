using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Core;
using Infrastructure.Core.Interfaces;

namespace Infrastructure.Algorithms
{
    public class HuntAndKill
    {
        public static void Run(ref IGrid grid)
        {
            var current = grid.GetRandomCell;

            while(current != null) //assumption that might be wrong
            {
                var unvisitedNeighbors = current.Neighbors.Where(x => x.Links.Any()); // get all neighbors of cell that has links

                if (unvisitedNeighbors.Any())
                {
                    var neighbor = unvisitedNeighbors.Sample<Cell>();
                    current.Link(neighbor);
                    current = neighbor;
                }
                else
                {
                    current = null;
                }

                foreach(var cell in grid)
                {
                    var visitedNeighbors = cell.Neighbors.Where(x => x.Links.Any());
                }
            }

        }
    }
}
