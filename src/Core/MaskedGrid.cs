using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Infrastructure.Core.Helper;

namespace Infrastructure.Core
{
    public class MaskedGrid : Grid
    {
        private Mask mask;
        public override int Size { get { return mask.Count; } }

        public MaskedGrid(Mask _mask) : base(_mask.Rows, _mask.Columns, false)
        {
            this.mask = _mask;
            this.Initialize(_mask.Rows, mask.Columns);
        }

        protected override void PrepareGrid()
        {
            grid = new Cell[Rows, Columns];
            for (var i = 0; i < Rows; i++)
            {
                for (var j = 0; j < Rows; j++)
                {
                    if (mask[i, j] == true) //is enabled
                        grid[i, j] = new Cell(i, j);
                }
            }
        }

        public override Cell GetRandomCell
        {
            get
            {
                var location = mask.RandomLocation();
                return this[location.Item1, location.Item2];
            }
        }
    }
}
