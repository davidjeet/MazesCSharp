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
    public class BinaryTree : IAlgorithms
    {
        public void Run(ref IGrid grid)
        {
            foreach (var cell in grid.GetAllCells())
            {
                var neighbors = new List<Cell>();
                if (cell.North != null) neighbors.Add(cell.North);
                if (cell.East != null) neighbors.Add(cell.East);

                int index = GetRandomNumber(0, neighbors.Count);
                if (neighbors.Count > 0)
                {
                    Cell neighbor = neighbors[index];
                    cell.Link(neighbor);
                }
            }
        }
    }
}
