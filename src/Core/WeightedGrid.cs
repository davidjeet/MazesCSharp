using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Core
{
    public class WeightedGrid : Grid
    {
        public int Distances { get; set; }
        public WeightedGrid(int rows, int columns) : base(rows, columns)
        {

        }
    }
}
