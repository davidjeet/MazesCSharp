using System;
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
            for (var row = 0; row < Rows; row++)
            {
                for (var column = 0; column < Rows; column++)
                {
                    this[row, column].North = this[row - 1, column];
                    this[row, column].South = this[row + 1, column];
                    this[row, column].East = this[row, column -1];
                    this[row, column].West = this[row, column + 1];
                }
            }
        }

        #region Helper Methods  

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
