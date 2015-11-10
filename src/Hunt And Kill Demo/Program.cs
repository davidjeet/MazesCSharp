using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Algorithms;
using Infrastructure.Core;
using Infrastructure.Core.Interfaces;

namespace Hunt_And_Kill_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            IGrid grid = new Grid(19, 19);
            new HuntAndKill().Run(ref grid);

            Console.WriteLine(grid.ToString(false));
            Console.ReadKey();
        }
    }
}
