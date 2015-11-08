using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Core;
using Infrastructure.Core.Interfaces;

namespace Infrastructure.Algorithms
{
    public class AldousBroder
    {
        public static void Run(ref IGrid grid)
        {
            var cell = grid.GetRandomCell;
            var unvisited = grid.Size - 1;

            while(unvisited > 0)
            {
                // next three lines get a random neighbor
                var neighbors = cell.GetAllNeighborsOfCell();
                int index = Grid.GetRandomNumber(0, neighbors.Count);
                var neighbor = neighbors[index];

                var links = neighbor.Links();
                if (links.Count == 0)
                {
                    cell.Link(neighbor);
                    unvisited--; 
                }

                cell = neighbor;
            }

        }
    }
}
