using System;
using System.Linq;

namespace CodeExperiment
{
   internal class Program
   {
      public const double Tau = 6.283185307179586;
      public const double Pi = 3.141592653589793;
      public const double E = 2.718281828459045;
      // Божественная пропорция
      public const double Fi = 1.618033988749895;
      // Постоянная Гаусса
      public const double G = 0.834626841674073;

      static void Main()
      {
         Console.WriteLine(Tau);
         Console.WriteLine(Pi);
         Console.WriteLine(E);
         Console.WriteLine(Fi);
         Console.WriteLine(Fi/2);
         Console.WriteLine(G);

         //double fi = (1 + Math.Sqrt(5)) / 2;
         //Console.WriteLine(fi);
         //double exp = Math.Exp(1);
         //Console.WriteLine(exp);

         double[] x = { 100, 150, 170, 91, 30, 67, 79, 87, 96, 200 };
         double s = x.Average();
         Console.WriteLine(s);

         double tau1 = Convert.ToInt32(s / Tau);
         Console.WriteLine(tau1);
         double pi1 = Convert.ToInt32(s / Pi);
         Console.WriteLine(pi1);
         double e1 = Convert.ToInt32(s / E);
         Console.WriteLine(e1);
         double fi1 = Convert.ToInt32(s / Fi);
         Console.WriteLine(fi1);

         Console.WriteLine();

         double fi2 = Convert.ToInt32(s * Fi);
         Console.WriteLine(fi2);

         Console.ReadKey();
      }
   }
}