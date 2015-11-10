using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Algorithms;
using Infrastructure.Core;
using Infrastructure.Core.Interfaces;

namespace Simple_Mask_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var mask = new Mask(5, 5);
            mask[0, 0] = false;
            mask[2, 2] = false;
            mask[4, 4] = false;

            IGrid grid = new MaskedGrid(mask);
            new RecursiveBacktracker().Run(ref grid);

            Console.WriteLine(grid.ToString(false));
            Console.ReadKey();
        }
    }
}
