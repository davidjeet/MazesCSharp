using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridInfrastructure
{
    public class Grid
    {
        private Cell[,] grid;

        public int Rows { get; set; } = 0;
        public int Columns { get; set; } = 0;

        public int Size { get { return Rows * Columns; } }

        public Grid(int _rows, int _columns)
        {
            Initialize(_rows, _columns);
        }

        private void Initialize(int _rows, int _columns)
        {
            Rows = _rows;
            Columns = _columns;

            PrepareGrid();
            ConfigureCells();
        }

        private void PrepareGrid()
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

        private void ConfigureCells()
        {
            foreach (var cell in grid)
            {
                ////Console.WriteLine($"({cell.row},{cell.column})");
                cell.North = this[cell.row - 1, cell.column];
                cell.South = this[cell.row + 1, cell.column];
                cell.West = this[cell.row, cell.column - 1];
                cell.East = this[cell.row, cell.column + 1];
            }
        }

        private IEnumerable<Cell> GetRow(int row)
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

        private Cell Random_Cell()
        {
            var i = GetRandomNumber(0, Rows - 1);
            var j = GetRandomNumber(0, Columns - 1);
            return this[i, j];
        }

        #region To Display / Debug Grid

        public string ToString(bool displayGridCoordinates)
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
            for (var i = 0; i < Rows; i++)
            {
                var row = GetRow(i);
                var top = "|";
                var bottom = "+";

                foreach (var cell in row)
                {
                    //3 spaces or print coordinates for debugging
                    var body = (displayGridCoordinates) ? $"{cell.row},{cell.column}" : "   ";
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

        /// Randon Number Helper
        private static readonly Random rnd = new Random();
        private static readonly object syncLock = new object();
        public static int GetRandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return rnd.Next(min, max);
            }
        }

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
