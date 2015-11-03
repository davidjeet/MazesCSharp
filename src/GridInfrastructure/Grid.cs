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

        public int Rows { get; set; }
        public int Columns { get; set; }

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
            for(var i=0; i< Rows; i++)
            {
                for (var j = 0; j < Rows; j++)
                {
                    grid[i, j] = new Cell(i, j);
                }
            }
        }

        private void ConfigureCells()
        {
            foreach(var cell in grid)
            {
                cell.North = this[cell.row - 1, cell.column];
                cell.South = this[cell.row + 1, cell.column];
                cell.East = this[cell.row, cell.column - 1];
                cell.West = this[cell.row, cell.column + 1];
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

        private Cell Random_Cell()
        {
            var i = GetRandomNumber(0, Rows-1);
            var j = GetRandomNumber(0, Columns - 1);
            return this[i, j];
        }

        

        // DEPREACTED
        ////private void ConfigureCells()
        ////{
        ////    for (var row = 0; row < Rows; row++)
        ////    {
        ////        for (var column = 0; column < Rows; column++)
        ////        {
        ////            this[row, column].North = this[row - 1, column];
        ////            this[row, column].South = this[row + 1, column];
        ////            this[row, column].East = this[row, column - 1];
        ////            this[row, column].West = this[row, column + 1];
        ////        }
        ////    }
        ////}

        #region Helper Methods  

        /// Randon Number Helper
        private static readonly Random rnd = new Random();
        private static readonly object syncLock = new object();
        private static int GetRandomNumber(int min, int max)
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
