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
         double tau1 = s / Tau;
         Console.WriteLine(tau1);
         double pi1 = s / Pi;
         Console.WriteLine(pi1);
         double e1 = s / E;
         Console.WriteLine(e1);
         double fi1 = s / Fi;
         Console.WriteLine(fi1);

         Console.WriteLine();

         double tau2 = s * Tau;
         Console.WriteLine(tau2);
         double pi2 = s * Pi;
         Console.WriteLine(pi2);
         double e2 = s * E;
         Console.WriteLine(e2);
         double fi2 = s * Fi;
         Console.WriteLine(fi2);

         Console.ReadKey();
      }
   }
}