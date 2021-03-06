﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Core
{
    public class Cell : IEquatable<Cell>
    {
        public int row { get; set; } = -1;
        public int column { get; set; } = -1;

        /// Needed for Djikstra
        public virtual Distances Distances
        {
            get
            {
                var distances = new Distances(this);
                var frontier = new List<Cell> { this };

                while (frontier.Any())
                {
                    var newFrontier = new List<Cell>();

                    foreach (var cell in frontier)
                    {
                        foreach (var linked in cell.Links)
                        {
                            if (!distances.ContainsKey(linked))
                            {
                                distances[linked] = distances[cell] + 1;
                                newFrontier.Add(linked);
                            }
                        }
                    }

                    frontier = newFrontier;
                }

                return distances;

            }
        }

        public Cell North { get; set; }

        public Cell South { get; set; }

        public Cell East { get; set; }

        public Cell West { get; set; }

        protected Dictionary<Cell, bool> links;

        /// <summary>All cells arround this cell (connected or not).</summary>
        public List<Cell> Neighbors
        {
            get
            {
                var list = new List<Cell>();

                if (North != null)
                    list.Add(North);
                if (South != null)
                    list.Add(South);
                if (East != null)
                    list.Add(East);
                if (West != null)
                    list.Add(West);

                return list;
            }
        }

        public Cell(int _row, int _column)
        {
            Initialize(_row, _column);
        }

        /// <summary>All cells linked to this cell.</summary>
        public List<Cell> Links
        {
            get
            {
                return links.Keys.ToList();
            }
        }

        protected void Initialize(int _row, int _column)
        {
            row = _row;
            column = _column;
            links = new Dictionary<Cell, bool>(); 
        }

        public Cell Link(Cell cell, bool bidirectional = true)
        {
            if (!links.ContainsKey(cell))
                links.Add(cell, true);

            if (bidirectional)
                cell.Link(this, false);

            return this;
        }

        public Cell UnLink(Cell cell, bool bidirectional = true)
        {
            if (links.ContainsKey(cell))
                links.Remove(cell);
                         
            if (bidirectional)
                cell.UnLink(this, false);

            return this;
        }

        public bool IsLinked(Cell cell)
        {
            if (cell == null) return false;
            return links.ContainsKey(cell);
        }

        #region ToString() implementation

        public override string ToString()
        {
            return $"({this.row},{this.column})";
        }

        public string ToStringDistance()
        {
            return $"({this.row},{this.column})";
        }

        #endregion

        #region IEquatable and other such things...
        public bool Equals(Cell other)
        {
            if (other == null) return false;
            return (row == other.row && column == other.column);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Cell);
        }

        public override int GetHashCode()
        {
            return $"{row}_{column}".GetHashCode();
        }

        #endregion
    }
}
