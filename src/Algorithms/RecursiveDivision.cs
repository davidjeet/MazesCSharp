﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Core;
using Infrastructure.Core.Interfaces;
using static Infrastructure.Core.Helper;

namespace Infrastructure.Algorithms
{
    public class RecursiveDivision : IAlgorithms
    {
        private IGrid grid;
        public void Run(ref IGrid _grid)
        {
            grid = _grid;

            foreach (var cell in grid)
            {
                foreach (var neighbor in cell.Neighbors)
                {
                    cell.Link(neighbor, false);
                }
            }

            Divide(0, 0, grid.Rows, grid.Columns);
        }

        private void Divide(int row, int column, int height, int width, Func<int,int,bool> DividerCriteria = null)
        {
            ////if (DividerCriteria ==null) DividerCriteria = DefaultDivider;
            if (DividerCriteria == null) DividerCriteria = RoomDivider;
            
            if (DividerCriteria(height, width)) return;

            if (height > width)
                DivideHorizontally(row, column, height, width);
            else
                DivideVertically(row, column, height, width);
        }

        private void DivideHorizontally(int row, int column, int height, int width)
        {
            var divideSouthOf = GetRandomNumber(height - 1);
            var passageAt = GetRandomNumber(width);

            for (int x = 0; x < width; x++)
            {
                if (passageAt != x)
                {
                    var cell = grid[row + divideSouthOf, column + x];
                    cell.UnLink(cell.South);
                }
            }

            Divide(row, column, divideSouthOf + 1, width);
            Divide(row + divideSouthOf + 1, column, height - divideSouthOf - 1, width);
        }

        private void DivideVertically(int row, int column, int height, int width)
        {
            var divideEastOf = GetRandomNumber(width - 1);
            var passageAt = GetRandomNumber(height);

            for (int y = 0; y < height; y++)
            {
                if (passageAt != y)
                {
                    var cell = grid[row + y, column + divideEastOf];
                    cell.UnLink(cell.East);
                }
            }

            Divide(row, column, height, divideEastOf + 1);
            Divide(row, column + divideEastOf + 1, height, width - divideEastOf - 1);
        }


        private bool DefaultDivider(int height, int width)
        {
            return (height <= 1 || width <= 1);
        }

        private bool RoomDivider(int height, int width)
        {
            return (height <= 1 || width <= 1 || (height < 5 && width <5 && GetRandomNumber(4) == 0));
        }
    }
}
