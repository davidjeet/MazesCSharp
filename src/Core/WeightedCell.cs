using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Core
{
    public class WeightedCell : Cell
    {
        public int Weight { get; set; }

        public WeightedCell(int _row, int _column) : base(_row, _column)
        {
            Weight = 1;
        }

        public override Distances Distances
        {
            get
            {
                Distances weights = new Distances(this);
                var pending = new List<WeightedCell> { this };

                while(pending.Any())
                {
                    var cell = weights.Min.Cell as WeightedCell;
                    pending.Remove(cell);

                    foreach(WeightedCell neighbor in cell.Links)
                    {
                        var totalWeight = weights[cell] + neighbor.Weight;
                        if (!weights.ContainsKey(neighbor) || totalWeight < weights[neighbor])
                        {
                            pending.Add(neighbor);
                            weights[neighbor] = totalWeight;
                        }
                    }
                }

                return weights;
            }
        }
    }
}
