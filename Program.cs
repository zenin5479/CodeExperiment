using System;
using System.Linq;

namespace CodeExperiment
{
   internal class Program
   {
      static void Main()
      {
         double[] x = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
         int n = x.Length;
         double s = x.Average();
         double y = Ema(s, n);
         Console.WriteLine(y);
      }

      public static double Ema(double s, int n)
      {
         // x - это входная серия            
         // N - условный возраст используемых данных
         // k - константа сглаживания

         double k = 2.0 / (n + 1);
         double y = k * s + (1 - k) * s;

         return y;
      }
   }
}
