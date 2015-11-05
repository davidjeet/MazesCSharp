using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Algorithms;
using Infrastructure.Core;
using Infrastructure.Core.Interfaces;

namespace SideWinder_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            IGrid grid = new Grid(6, 6);
            SideWinder.Run(ref grid);

            Console.WriteLine(grid.ToString(false));
            //Console.WriteLine(grid.ToDebug());
            Console.ReadKey();
        }
    }
}
