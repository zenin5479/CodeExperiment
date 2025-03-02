using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeExperiment
{
   internal class Program
   {
      static void Main()
      {
         double MyParse(string x)
         {
            double y = double.Parse(x);
            return y;
         }

         string str = "6,0 5,0 9,3 7,8 5,7 8,1 1,2";
         string[] s = str.Split();
         List<double> list = s.Select(MyParse).ToList();
         foreach (double rs in list)
         {
            Console.WriteLine(rs);
         }

         Console.ReadKey();
      }
   }
}