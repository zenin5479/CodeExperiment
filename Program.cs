using System;

// Передача параметров по ссылке и значению
// Выходные параметры. Модификатор out

namespace CodeExperiment
{
   internal class Program
   {
      static void Main()
      {
         int i;
         double myDr, mySqr, mySqrt, myD = 12.987;
         i = TrNumber(myD, out myDr, out mySqr, out mySqrt);

         Console.WriteLine(
            "Исходное число: {0}\nЦелая часть числа: {1}\nДробная часть числа: {2}\nКвадрат числа: {3}\nКвадратный корень числа: {4}",
            myD,
            i,
            myDr,
            mySqr,
            mySqrt);

         Console.ReadKey();
      }

      // Метод возвращающий целую и дробную части числа, квадрат и корень числа
      static int TrNumber(double d, out double dr, out double sqr, out double sqrt)
      {
         int i = (int)d;
         dr = d - i;
         sqr = d * d;
         sqrt = Math.Sqrt(d);

         return i;
      }
   }
}