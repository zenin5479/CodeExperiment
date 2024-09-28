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

         // Если меньше этого знчения среднее
         double fihalfdata = data * Fihalf;
         Console.WriteLine(fihalfdata);

         // Тогда уменьшаем заданное значение на процент
         double datafipercent = data * (Fi / 10);
         Console.WriteLine(datafipercent);

         int result = Convert.ToInt32(data - datafipercent);
         Console.WriteLine(result);

         Console.ReadKey();
      }
   }
}