using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Core;
using Infrastructure.Core.Interfaces;

namespace Infrastructure.Algorithms
{
    public class SideWinder
    {
        public static void Run(ref IGrid grid)
        {
            foreach (var row in grid.GetAllRows())
            {
                var run = new List<Cell>();
                foreach(var cell in row)
                {
                    run.Add(cell);

                    bool atEasternBoundary = (cell.East == null);
                    bool atNorthernBoundary = (cell.North == null);

                    bool shouldCloseOut = atEasternBoundary || (!atNorthernBoundary && (Grid.GetRandomNumber(0, 2) == 0));

                    if (shouldCloseOut)
                    {
                        var index = Grid.GetRandomNumber(0, run.Count());
                        var member = run[index];

                        if (member.North !=null)
                        {
                            member.Link(member.North);
                        }
                        run.Clear();
                    }
                    else
                    {
                        cell.Link(cell.East);
                    }
                } //end inner-loop
            } //end outer-loop
        }
    }
}
