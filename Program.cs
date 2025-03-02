using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeExperiment
{
   internal class Program
   {
      static void Main()
      {
         string str = "6,0 5,0 9,3 7,8 5,7 8,1 1,2";
         string[] s = str.Split();
         List<double> list = s.Select(double.Parse).ToList();
         foreach (double rs in list)
         {
            Console.WriteLine(rs);
         }

         Console.ReadKey();
      }
   }
}