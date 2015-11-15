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
    public class RecursiveDivision : IAlgorithms
    {
        private IGrid grid;
        public void Run(ref IGrid _grid)
        {
            grid = _grid;

            foreach(var cell in grid)
            {

            }

            ////var cell = grid.GetRandomCell;
            ////var unvisited = grid.Size - 1;

            ////while(unvisited > 0)
            ////{
            ////    // next three lines get a random neighbor
            ////    var neighbors = cell.Neighbors;
            ////    int index = GetRandomNumber(0, neighbors.Count);
            ////    var neighbor = neighbors[index];

            ////    var links = neighbor.Links;
            ////    if (links.Count == 0)
            ////    {
            ////        cell.Link(neighbor);
            ////        unvisited--; 
            ////    }

            ////    cell = neighbor;
            ////}

        }
    }
}
