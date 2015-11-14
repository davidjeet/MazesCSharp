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
            Console.WriteLine("Simplified Prim");
            Console.WriteLine(grid.ToString(false));
            Console.ReadKey();


            grid = new Grid(20, 20);
            new TruePrim().Run(ref grid);
            Console.WriteLine("True Prim");
            Console.WriteLine(grid.ToString(false));
            Console.ReadKey();
        }
    }
}
