using System;
using System.Linq;

namespace CodeExperiment
{
   internal class Program
   {
      static void Main()
      {
         double[] x = { 100, 150, 170, 91, 30, 67, 79, 87, 96, 200 };
         double s = x.Average();

         double fi = (1 + Math.Sqrt(5)) / 2;
         Console.WriteLine(fi);
         for (int i = 0; i < x.Length; i++)
         {
            double y = Math.Exp(x[i] / 6);
            double exp = Math.Exp(1);
            Console.WriteLine(exp);
            Console.WriteLine(y);
         }



         Console.WriteLine(s);







      }


   }
}
