using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Algorithms;
using Infrastructure.Core;
using Infrastructure.Core.Interfaces;

namespace Aldous_Broder_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            IGrid grid = new Grid(10, 10);
            AldousBroder.Run(ref grid);

            Console.WriteLine(grid.ToString(false));
            ////Console.WriteLine(grid.ToDebug());
            Console.ReadKey();
        }
    }
}
