using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Infrastructure.Core.Helper;

namespace Infrastructure.Core
{
    public class Mask
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        private bool[,] bits;

        public Mask(int rows, int columns)
        {
            this.Rows = rows;
            this.Columns = columns;
            bits = new bool[Rows, Columns];

            //initialize all cells to 'enabled' (true)
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Columns; j++)
                    bits[i, j] = true;
        }


        #region Helper Properties/Methods

        /// <summary>2-D Array Accessor method.</summary>
        public bool this[int row, int column]
        {
            get
            {
                if (row < 0 || row > Rows - 1) return false;
                if (column < 0 || column > Columns - 1) return false;
                return bits[row, column];
            }
            set
            {
                bits[row, column] = value;
            }
        }

        public int Count
        {
            get
            {
                var count = 0;

                for (int i = 0; i < Rows; i++)
                    for (int j = 0; j < Columns; j++)
                        if (this[i, j])
                            count++;

                return count;
            }
        }

        public Tuple<int, int> RandomLocation()
        {
            int row=0, column=0;
            do
            {
                row = GetRandomNumber(0, Rows);
                column = row = GetRandomNumber(0, Columns);

            } while (bits[row, column] == false); //keep looping until  we find an enabled cell

            return new Tuple<int, int>(row, column);
        }

        #endregion
    }
}
