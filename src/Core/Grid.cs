using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Core.Interfaces;
using static Infrastructure.Core.Helper;

namespace Infrastructure.Core
{
    public class Grid : IGrid
    {
        protected Cell[,] grid;

        public int Rows { get; set; } = 0;

        public int Columns { get; set; } = 0;

        public virtual int Size { get { return Rows * Columns; } }

        // Constructor
        public Grid(int _rows, int _columns, bool useBaseInitializer = true)
        {
            if (useBaseInitializer)
            { 
                Initialize(_rows, _columns);
            }
        }

        public virtual Cell GetRandomCell
        {
            get
            {
                var i = GetRandomNumber(0, Rows - 1);
                var j = GetRandomNumber(0, Columns - 1);
                return this[i, j];
            }
        }

        public IEnumerable<Cell> DeadEnds
        {
            get
            {
                foreach (var cell in grid)
                {
                    if (cell.Links.Count == 1)
                        yield return cell;
                }
            }
        }

        protected virtual void Initialize(int _rows, int _columns)
        {
            Rows = _rows;
            Columns = _columns;

            PrepareGrid();
            ConfigureCells();
        }

        protected virtual void PrepareGrid()
        {
            grid = new Cell[Rows, Columns];
            for (var i = 0; i < Rows; i++)
            {
                for (var j = 0; j < Rows; j++)
                {
                    grid[i, j] = new Cell(i, j);
                }
            }
        }

        protected virtual void ConfigureCells()
        {
            foreach (var cell in grid)
            {

                cell.North = this[cell.row - 1, cell.column];
                cell.South = this[cell.row + 1, cell.column];
                cell.West = this[cell.row, cell.column - 1];
                cell.East = this[cell.row, cell.column + 1];
            }
        }

        protected IEnumerable<Cell> GetRow(int row)
        {
            for (var i = 0; i < Rows; i++)
            {
                for (var j = 0; j < Rows; j++)
                {
                    if (i == row)
                        yield return this[i, j];
                }
            }
        }

        public List<List<Cell>> GetAllRows()
        {
            var results = new List<List<Cell>>();
            for (var i = 0; i < Rows; i++)
            {
                var innerList = new List<Cell>();
                for (var j = 0; j < Rows; j++)
                {
                    innerList.Add(this[i, j]);
                }
                results.Add(innerList);
            }
            return results;
        }

        public IEnumerable<Cell> GetAllCells()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (var j = 0; j < Columns; j++)
                {
                    yield return this[i, j];
                }
            }
        }

        #region To Display / Debug Grid

        public virtual string ContentsOf(Cell cell)
        {
            return "   ";
        }

        public virtual string ToString(bool displayGridCoordinates)
        {
            var output = "+";

            // Top border
            for (int i = 0; i < Columns; i++)
            {
                var border = "---+";
                output += border;
            }
            output += System.Environment.NewLine;

            // Middle
            foreach (var row in this.GetAllRows())
            {
                var top = "|";
                var bottom = "+";

                foreach (var cell in row)
                {          
                    var body = (displayGridCoordinates) ? $"{cell.row},{cell.column}" : $"{ContentsOf(cell)}";
                    var eastBoundary = cell.IsLinked(cell.East) ? " " : "|";
                    top += body + eastBoundary;

                    var southBoundary = cell.IsLinked(cell.South) ? "   " : "---";
                    var corner = "+";
                    bottom += southBoundary + corner;
                }

                output += top + System.Environment.NewLine;
                output += bottom + System.Environment.NewLine;
            }

            return output;
        }

        public override string ToString()
        {
            return ToString(false);
        }

        public string ToDebug()
        {
            var output = string.Empty;
            foreach (var cell in grid)
            {
                output += $"({cell.row},{cell.column}) : ";
                output += (cell.IsLinked(cell.North)) ? "1, " : "0, ";
                output += (cell.IsLinked(cell.South)) ? "1, " : "0, ";
                output += (cell.IsLinked(cell.East)) ? "1, " : "0, ";
                output += (cell.IsLinked(cell.West)) ? "1" : "0";

                output += System.Environment.NewLine;
            }


            return output;
        }

        #endregion

        #region Helper Methods  

        /// <summary>IEnumerator for 2-D cell array.</summary>
        public IEnumerator<Cell> GetEnumerator()
        {
            for (var i = 0; i < Rows; i++)
            {
                for (var j = 0; j < Rows; j++)
                {
                    yield return grid[i, j];
                }
            }
        }

        /// <summary>2-D Array Accessor method.</summary>
        public Cell this[int row, int column]
        {
            get
            {
                if (row < 0 || row > Rows - 1) return null;
                if (column < 0 || column > Columns - 1) return null;
                return grid[row, column];
            }
            set
            {
                grid[row, column] = value;
            }
        }

        #endregion

    }
}
