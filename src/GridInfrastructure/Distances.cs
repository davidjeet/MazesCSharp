using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridInfrastructure
{
    public class Distances
    {
        private Cell root;
        private Dictionary<Cell, int?> cells;

        public Distances(Cell _root)
        {
            root = _root;
            cells = new Dictionary<Cell, int?>();
            cells.Add(_root, 0);
        }

        public IEnumerable<Cell> Cells()
        {
            return cells.Keys;
        }

        public bool ContainsKey(Cell cell)
        {
            return cells.ContainsKey(cell);
        }


        // indexer on the Distances object that takes a cell and returns its distance value (relative to root = 0)
        public int? this[Cell cell]
        {
            get
            {
                return cells[cell];
            }
            set
            {
                cells[cell] = value;
            }
        }
    }
}
