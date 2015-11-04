using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GridInfrastructure;

namespace SideWinder_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var grid = new Grid(6, 6);
            SideWinder.Run(ref grid);

            Console.WriteLine(grid.ToString(false));
            //Console.WriteLine(grid.ToDebug());
            Console.ReadKey();
        }
    }
}
