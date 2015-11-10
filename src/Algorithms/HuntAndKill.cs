using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Core;
using Infrastructure.Core.Interfaces;

namespace Infrastructure.Algorithms
{
    public class HuntAndKill : IAlgorithms
    {
        public void Run(ref IGrid grid)
        {
            var current = grid.GetRandomCell;

            while(current != null) 
            {
                var unvisitedNeighbors = current.Neighbors.Where(x => x.Links.Count == 0); // get all neighbors of cell that does not have any links (yet)

                if (unvisitedNeighbors.Count() > 0)
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
                    var visitedNeighbors = cell.Neighbors.Where(x => x.Links.Count() > 0);
                    if ((cell.Links.Count == 0 || cell.Links== null) && visitedNeighbors.Count() > 0)
                    {
                        current = cell;

                        var neighbor = visitedNeighbors.Sample<Cell>();
                        current.Link(neighbor);

                        break;
                    }
                }
            }

        }
    }
}
