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
                var unvisited_neighbors = current.Neighbors.Where(x => x.Links().Any()); // get all neighbors of cell that has links

                if (unvisited_neighbors.Any())
                {
                    var neighbor = unvisited_neighbors.Sample<Cell>();
                }
            }

        }
    }
}
