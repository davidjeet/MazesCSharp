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

        protected override void ConfigureCells()
        {
            foreach (var cell in grid)
            {
                //...null conditional check needed for masked grid implementation               
                if (cell != null)
                {
                    cell.North = this[cell.row - 1, cell.column];
                    cell.South = this[cell.row + 1, cell.column];
                    cell.West = this[cell.row, cell.column - 1];
                    cell.East = this[cell.row, cell.column + 1];
                }
            }
        }



        //some thoughts:
        //1. Top and middle need to be handled differently. Not just assumed values when you start.
        //2. Use a i,j coordinate system, not a foreach loop. This gives us finer grain control over boundary cases on how they should be handled.
        //3. Each cell is responsible for itself *AND*  checking if a border below it is merited, and a border to the left (west) is merited (but see also 2)
        // In conclusion: I would do a complete re-write of this method.


        //private IServiceProvider 
        private bool IsCellNull(int i, int j)
        {
            return this[i, j] == null;
        }

        public override string ToString(bool displayGridCoordinates)
        {
            var output = new List<string>();

            string topRow = "";
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (i==0) // top row
                    {                        
                        topRow += (IsCellNull(i, j))
                            ? "    "
                            : "---+";
                    }
                }
            }
            topRow += Environment.NewLine;
            output.Add(topRow);

            for (int i = 0; i < Rows; i++)
            {
                string row1 = "";
                string row2 = "";

                for (int j = 0; j < Columns; j++)
                {
                    //row 1
                    var cell = this[i, j];
                    
                    //west wall responsibility
                    if (IsCellNull(i, j))
                    { 
                        row1 += " ";
                    }
                    else if (cell.IsLinked(cell.West))
                    {
                        row1 += "|";
                    }
                    else
                    {
                        row1 += " ";
                    }

                    //cell responsibility
                    if (IsCellNull(i, j))
                    {
                        row1 += "   ";
                    }
                    else
                    {
                        row1 += $"{ContentsOf(cell)}";
                    }
                        


                    //row 2

                    //corner responsibility + south border responsibility
                    if (IsCellNull(i+1, j))
                    {
                        row2 += " ";  //corner
                        row2 += "   "; //south border
                    }
                    else
                    {
                        row2 += "+";  //corner
                        row2 += "---";  //south border
                    }
                }

                row1 += System.Environment.NewLine;
                row2 += System.Environment.NewLine;

                output.Add(row1 + row2);
            }



            return String.Join<string>(String.Empty, output);



            #region Obsolete

            ////string output = "+";

            ////// Top border
            ////for (int i = 0; i < Columns; i++)
            ////{
            ////    string border = "    ";
            ////    if (this[0, i] == null)
            ////    {
            ////        if (i == 0) output = "";
            ////    }
            ////    else
            ////    {
            ////        border = "---+";
            ////    }

            ////    output += border;
            ////}
            ////output += System.Environment.NewLine;

            ////// Middle
            ////foreach (var row in this.GetAllRows())
            ////{
            ////    var top = "|";
            ////    var bottom = "+";

            ////    foreach (var cell in row)
            ////    {
            ////        //null check added for maskedgrid
            ////        if (cell != null)
            ////        {
            ////            var body = (displayGridCoordinates) ? $"{cell.row},{cell.column}" : $"{ContentsOf(cell)}";
            ////            var eastBoundary = cell.IsLinked(cell.East) ? " " : "|";
            ////            top += body + eastBoundary;

            ////            var southBoundary = cell.IsLinked(cell.South) ? "   " : "---";
            ////            var corner = "+";
            ////            bottom += southBoundary + corner;
            ////        }
            ////        else
            ////        {
            ////            //what to print for a null cell (only relevent if using a masked grid)  

            ////            ////if (top == "|") top = " ";

            ////            var body = $"{ContentsOf(cell)}";
            ////            //var eastBoundary = "|";
            ////            var eastBoundary = " ";

            ////            top += body + eastBoundary;

            ////            var southBoundary = "---";
            ////            //var southBoundary = "   ";

            ////            //var corner = "+";
            ////            var corner = " ";

            ////            ////if (bottom == "+") bottom = " ";
            ////            bottom += southBoundary + corner;
            ////        }
            ////    }

            ////    output += top + System.Environment.NewLine;
            ////    output += bottom + System.Environment.NewLine;
            ////}

            ////return output;

            #endregion
        }
    }
}
