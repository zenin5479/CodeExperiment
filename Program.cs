using System;
using System.Linq;

namespace CodeExperiment
{
   internal class Program
   {
      public const double Pi = 3.1415926535897931;
      public const double E = 2.7182818284590451;

      static void Main()
      {
         //double pi = ?;
         
         double fi = (1 + Math.Sqrt(5)) / 2;
         Console.WriteLine(fi);
         double exp = Math.Exp(1);
         Console.WriteLine(exp);


         double[] x = { 100, 150, 170, 91, 30, 67, 79, 87, 96, 200 };
         double s = x.Average();
         for (int i = 0; i < x.Length; i++)
         {
            double y = Math.Exp(x[i] / 6);

            Console.WriteLine(y);
         }

         Console.WriteLine(s);
      }
   }
}