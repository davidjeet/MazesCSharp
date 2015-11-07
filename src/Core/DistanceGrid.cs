using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Core
{
    public class DistanceGrid : Grid
    {
        public Distances CellDistances { get; set; } = null;

        public DistanceGrid(int _rows, int _columns) : base(_rows, _columns)
        {
        }

        public override string ContentsOf(Cell cell)
        {
            if (CellDistances != null && CellDistances[cell] != null)
            {
                var distance = CellDistances[cell].Value;
                return $" {Convert.ToString(distance, 16)} ";
            }
            return base.ContentsOf(cell); 
        }
    }
}
