using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GridInfrastructure;

namespace Binary_Tree_Demo
{
    public class BinaryTree
    {
        //TODO:
        // ##### 0. May be working but just the row iteration is messed up 
        // 1. Look at the grid generation (or the decision branching)
        // 2. Look at the display
        // 3. Or the problem is both

        public static void Run(ref Grid grid)
        {
            foreach (var cell in grid.GetAllCells())
            {
                var neighbors = new List<Cell>();
                if (cell.North != null) neighbors.Add(cell.North);
                if (cell.East != null) neighbors.Add(cell.East);

                int index = Grid.GetRandomNumber(0, neighbors.Count);
                if (neighbors.Count > 0)
                {
                    Cell neighbor = neighbors[index];
                    cell.Link(neighbor);
                }
            }
        }
    }
}
