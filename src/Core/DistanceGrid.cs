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
        public Distances distances { get; set; } = null;

        public DistanceGrid(int _rows, int _columns) : base(_rows, _columns)
        {
        }

        public override string ContentsOf(Cell cell)
        {
            if (distances != null && distances[cell] != null)
            {
                var distance = distances[cell].Value;
                return $" {Convert.ToString(distance, 16)} ";
            }
            return base.ContentsOf(cell); 
        }
    }
}
