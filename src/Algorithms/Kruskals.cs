using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Core;
using Infrastructure.Core.Interfaces;
using static Infrastructure.Core.Helper;

namespace Infrastructure.Algorithms
{
    public class Kruskals : IAlgorithms
    {
        class State
        {
            internal List<Cell []> Neighbors { get; set; } 
            internal Dictionary<Cell, int> setForCell { get; private set; }
            internal Dictionary<int, List<Cell>> cellsInSet { get; private set; }
            private IGrid grid;

            public State(ref IGrid _grid)
            {
                grid = _grid;
                Neighbors = new List<Cell []>();
                setForCell = new Dictionary<Cell, int>();
                cellsInSet = new Dictionary<int, List<Cell>>();

                foreach(var cell in grid)
                {
                    int set = setForCell.Count;
                    setForCell[cell] = set;
                    cellsInSet[set] = new List<Cell> { cell };

                    if (cell.South !=null)
                    {
                        Neighbors.Add(new Cell[] { cell, cell.South });
                    }
                    if (cell.East != null)
                    {
                        Neighbors.Add(new Cell[] { cell, cell.East });
                    }
                }
            }

            internal bool CanMerge(Cell left, Cell right)
            {
                return setForCell[left] != setForCell[right];
            }

            internal void Merge(Cell left, Cell right)
            {
                left.Link(right);

                var winner = setForCell[left];
                var loser = setForCell[right];
                var losers = cellsInSet[loser];
                losers.Add(right); // TODO:  Poor ruby  interpretation of || operator?

                foreach (var cell in losers)
                {
                    cellsInSet[winner].Add(cell);
                    setForCell[cell] = winner;
                }

                cellsInSet.Remove(loser);
            }

        } //end class

        public void Run(ref IGrid grid)
        {
            var state = new State(ref grid);
            var _neighbors = state.Neighbors.Shuffle();     // Shuffle<Cell []>()
            var neighbors = new Stack<Cell[]>(_neighbors);
            
            while (neighbors.Any())
            {
                var pair = neighbors.Pop();
                var left = pair[0];
                var right = pair[1];
                if (state.CanMerge(left, right))
                {
                    state.Merge(left, right);
                }
            }

        }
    }
}
