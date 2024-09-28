using System;
using System.Linq;

namespace CodeExperiment
{
   internal class Program
   {
      // Божественная пропорция
      public const double Fi = 1.618033988749895;
      public const double Fihalf = 0.809016994374947;

      static void Main()
      {
         Console.WriteLine(Fi);
         Console.WriteLine(Fihalf);

         int data = 300;
         double[] x = { 100, 150, 170, 250, 30, 280, 190, 87, 96, 200 };
         double s = x.Average();
         Console.WriteLine(s);

         double fihalfdata = data * Fihalf;
         Console.WriteLine(fihalfdata);

         double fi1 = Convert.ToInt32(s / Fi);
         Console.WriteLine(fi1);
         double result = Convert.ToInt32(data / (Fi * 10));
         Console.WriteLine(result);

         Console.WriteLine();

         double fi2 = Convert.ToInt32(s * Fi);
         Console.WriteLine(fi2);
         Console.WriteLine(GetPercent(s, data));

         Console.ReadKey();
      }

      public static double GetPercent(double s, int data)
      {
         if (s == 0) return 0;
         if (data == 0) return 0;

         return s / (data / 100f);
      }
   }
}