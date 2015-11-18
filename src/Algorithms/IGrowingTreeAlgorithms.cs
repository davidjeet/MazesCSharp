using System;
using System.Collections.Generic;
using Infrastructure.Core;
using Infrastructure.Core.Interfaces;

namespace Infrastructure.Algorithms
{
    public interface IGrowingTreeAlgorithms
    {
        void Run(ref IGrid grid, Func<IEnumerable<Cell>, Cell> selectionFunction);
    }
}