using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Core;
using Infrastructure.Core.Interfaces;

namespace Infrastructure.Algorithms
{
    public class RecursiveBacktracker : IAlgorithms
    {
        public void Run(ref IGrid grid)
        {
            var startAt = grid.GetRandomCell;
            var stack = new Stack<Cell>();
            stack.Push(startAt);

            while(stack.Any())
            {
                var current = stack.Peek();
                var neighbors = current.Neighbors.Where(n => n.Links.Count == 0);

                if (neighbors.Count() ==0)
                {
                    stack.Pop();
                }
                else
                {
                    var neighbor = neighbors.Sample<Cell>();
                    current.Link(neighbor);
                    stack.Push(neighbor);
                }
            }

        }
    }
}
