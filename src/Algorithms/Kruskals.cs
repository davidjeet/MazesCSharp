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
        class CellPair : IEquatable<CellPair>
        {
            public Cell Left { get; private set; }
            public Cell Right { get; private set; }

            public CellPair(Cell left, Cell right)
            {
                Left = left;
                Right = right;
            }

            public bool Equals(CellPair other)
            {
                if (other == null) return false;
                return (Left == other.Left && Right == other.Right);
            }

            public override bool Equals(object obj)
            {
                return Equals(obj as CellPair);
            }

            public override int GetHashCode()
            {
                return $"{Left.ToString()}_{Right.ToString()}".GetHashCode();
            }
        }

        class State
        {
            internal List<CellPair> Neighbors { get; set; } 
            internal Dictionary<Cell, int> setForCell { get; private set; }
            internal Dictionary<int, List<Cell>> cellsInSet { get; private set; }
            private IGrid grid;

            public State(ref IGrid _grid)
            {
                grid = _grid;
                Neighbors = new List<CellPair>();
                setForCell = new Dictionary<Cell, int>();
                cellsInSet = new Dictionary<int, List<Cell>>();

                foreach(var cell in grid)
                {
                    int set = setForCell.Count;
                    setForCell[cell] = set;
                    cellsInSet[set] = new List<Cell> { cell };

                    if (cell.South !=null)
                    {
                        Neighbors.Add(new CellPair(cell, cell.South));
                    }
                    if (cell.East != null)
                    {
                        Neighbors.Add(new CellPair(cell, cell.East));
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
            var neighbors = new Stack<CellPair>(_neighbors);
            
            while (neighbors.Any())
            {
                var pair = neighbors.Pop();
                var left = pair.Left;
                var right = pair.Right;
                if (state.CanMerge(left, right))
                {
                    state.Merge(left, right);
                }
            }

        }
    }
}
