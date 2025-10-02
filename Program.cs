using System;

// Передача параметров по ссылке и значению
// Выходные параметры. Модификатор out

namespace CodeExperiment
{
   internal class Program
   {
      static void Main()
      {
         int z;
         double myDr, mySqr, mySqrt, myD = 12.987;
         z = TrNumber(myD, out myDr, out mySqr, out mySqrt);
         Console.WriteLine("Исходное число: {0}\nЦелая часть числа: {1}\nДробная часть числа: {2}\nКвадрат числа: {3}\nКвадратный корень числа: {4}",
            myD, z, myDr, mySqr, mySqrt);

         int x = 1, y = 2, a = 3, b = 4;
         Console.WriteLine("До вызова: \tx={0}; y ={1}; a ={2}; b ={3}", x, y, a, b);
         Add(out a, out b);
         Console.WriteLine("После вызова: \tx={0}; y ={1}; a ={2}; b ={3}", x, y, a, b);
         Console.ReadKey();
      }

      // Выходные параметры, представленные значением
      public static void Add(out int a, out int b)
      {
         a = 30; b = 40;
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