using System;
using System.Collections.Generic;
using Infrastructure.Core;
using Infrastructure.Core.Interfaces;

namespace Infrastructure.Algorithms
{
    public delegate Cell SelectionFunction(IEnumerable<Cell> cellList);
    //equivalent to Func<IEnumerable<Cell> cellList, Cell>

    public interface IGrowingTreeAlgorithms

    {
        void Run(ref IGrid grid, SelectionFunction selectionFunction);
    }
}