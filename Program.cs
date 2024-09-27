using System;
using System.Linq;

namespace CodeExperiment
{
   internal class Program
   {
      public const double Tau = 6.2831853071795862;
      public const double Pi = 3.1415926535897931;
      public const double E = 2.7182818284590451;
      public const double Fi = 1.618033988749895;

      static void Main()
      {
         Console.WriteLine(Tau);
         Console.WriteLine(Pi);
         Console.WriteLine(E);
         Console.WriteLine(Fi);

         //double fi = (1 + Math.Sqrt(5)) / 2;
         //Console.WriteLine(fi);
         //double exp = Math.Exp(1);
         //Console.WriteLine(exp);

         double[] x = { 100, 150, 170, 91, 30, 67, 79, 87, 96, 200 };
         double s = x.Average();
         Console.WriteLine(s);
         double tau = s / Tau;
         Console.WriteLine(tau);
         double pi = s / Pi;
         Console.WriteLine(pi);
         double e = s / E;
         Console.WriteLine(e);
         double fi = s / Fi;
         Console.WriteLine(fi);

         Console.ReadKey();
      }
   }
}