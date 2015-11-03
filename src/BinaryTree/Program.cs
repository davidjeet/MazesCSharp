using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GridInfrastructure;

namespace Binary_Tree_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var grid = new Grid(4, 4);
            BinaryTree.Run(ref grid);

            System.Console.WriteLine(grid.ToString(true));
            System.Console.WriteLine(grid.ToDebug());
            Console.ReadKey();
        }
    }
}
