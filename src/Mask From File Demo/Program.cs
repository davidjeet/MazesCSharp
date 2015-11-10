using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Algorithms;
using Infrastructure.Core;
using Infrastructure.Core.Interfaces;

namespace Mask_From_File_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = (args.Length == 1)
                        ? file = args[0]
                        : Path.Combine(Environment.CurrentDirectory, "mask.txt");

            var mask = Mask.ReadFromTextFile(file);
            IGrid grid = new MaskedGrid(mask);
            new RecursiveBacktracker().Run(ref grid);

            Console.WriteLine(grid.ToString(false));
            Console.ReadKey();
        }
    }
}
