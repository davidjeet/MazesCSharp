using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Algorithms;
using Infrastructure.Core;
using Infrastructure.Core.Interfaces;


namespace Prim_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            IGrid grid = new Grid(20, 20);
            new SimplifiedPrim().Run(ref grid);

            Console.WriteLine(grid.ToString(false));
            ////Console.WriteLine(grid.ToDebug());
            Console.ReadKey();
        }
    }
}
