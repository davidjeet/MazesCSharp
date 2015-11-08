using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Core
{
    public struct MaxResult
    {
        public Cell Cell;
        public int? Distance;

        public MaxResult(Cell _cell, int? _distance)
        {
            this.Cell = _cell;
            this.Distance = _distance;
        }
    }
}
