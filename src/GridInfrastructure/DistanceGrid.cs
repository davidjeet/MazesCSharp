using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridInfrastructure
{
    public class DistanceGrid : Grid
    {
        public Distances distances { get; set; } = null;

        public DistanceGrid(int _rows, int _columns) : base(_rows, _columns)
        {
        }

        public override string ContentsOf(Cell cell)
        {
            if (distances != null && distances[cell] != null)
            {
                var distance = distances[cell].Value;
                return $" {Convert.ToString(distance, 16)} ";
            }
            return base.ContentsOf(cell); 
        }


        ////string xx = IntToString(42,
        ////    new char[] { '0','1','2','3','4','5','6','7','8','9',
        ////    'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z',
        ////    'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x'});

        ////public static string IntToString(int value, char[] baseChars)
        ////{
        ////    string result = string.Empty;
        ////    int targetBase = baseChars.Length;

        ////    do
        ////    {
        ////        result = baseChars[value % targetBase] + result;
        ////        value = value / targetBase;
        ////    }
        ////    while (value > 0);

        ////    return result;
        ////}

    }
}
