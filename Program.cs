using System;
using System.Linq;

namespace CodeExperiment
{
   internal class Program
   {
      //public const double Tau = 6.283185307179586;
      //public const double Pi = 3.141592653589793;
      //public const double E = 2.718281828459045;
      // Божественная пропорция
      public const double Fi = 1.618033988749895;
      public const double Fihalf = 0.809016994374947;
      // Постоянная Гаусса
      //public const double G = 0.834626841674073;

      static void Main()
      {
         //Console.WriteLine(Tau);
         //Console.WriteLine(Pi);
         //Console.WriteLine(E);
         Console.WriteLine(Fi);
         //Console.WriteLine(Fihalf);
         //Console.WriteLine(G);

         //double fi = (1 + Math.Sqrt(5)) / 2;
         //Console.WriteLine(fi);
         //double exp = Math.Exp(1);
         //Console.WriteLine(exp);

         int data = 300;
         double[] x = { 100, 150, 170, 250, 30, 280, 190, 87, 96, 200 };
         double s = x.Average();
         Console.WriteLine(s);

         //double tau1 = Convert.ToInt32(s / Tau);
         //Console.WriteLine(tau1);
         //double pi1 = Convert.ToInt32(s / Pi);
         //Console.WriteLine(pi1);
         //double e1 = Convert.ToInt32(s / E);
         //Console.WriteLine(e1);
         double fidata = Convert.ToInt32(data * Fihalf);
         Console.WriteLine(fidata);


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