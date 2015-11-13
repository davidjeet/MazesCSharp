using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Core
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

        public Distances PathToGoal(Cell goal)
        {
            var current = goal;

            var breadcrumbs = new Distances(root);
            breadcrumbs[current] = cells[current];

            do
            {
                foreach (Cell neighbor in current.Links)
                {
                    if (cells[neighbor] < cells[current])
                    {
                        breadcrumbs[neighbor] = cells[neighbor];
                        current = neighbor;
                        break;
                    }
                }
            } while(current != root);

            return breadcrumbs;
        }

        public MaxResult Max
        {
            get
            {
                int? maxDistance = 0;
                Cell maxCell = root;

                foreach (var key in cells.Keys)
                {
                    var distance = cells[key];
                    if (distance > maxDistance)
                    {
                        maxCell = key;
                        maxDistance = distance;
                    }
                }

                return new MaxResult(maxCell, maxDistance);
            }
        }

        public MaxResult Min
        {
            get
            {
                int? minDistance = 0;
                Cell maxCell = root;

                foreach (var key in cells.Keys)
                {
                    var distance = cells[key];
                    if (distance < minDistance)
                    {
                        maxCell = key;
                        minDistance = distance;
                    }
                }

                return new MaxResult(maxCell, minDistance);
            }
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
                return cells.ContainsKey(cell) ? cells[cell] : null;
            }
            set
            {
                cells[cell] = value;
            }
        }
    }

}
