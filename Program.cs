using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeExperiment
{
   internal class Program
   {
      static void Main()
      {
         //double MyParse(string x)
         //{
         //   double y = double.Parse(x);
         //   return y;
         //}

         //string str = "6,0 5,0 9,3 7,8 5,7 8,1 1,2";
         //string[] s = str.Split();
         //List<double> list = s.Select(MyParse).ToList();
         //foreach (double rs in list)
         //{
         //   Console.WriteLine(rs);
         //}

         string str = "6,0 5,0 9,3 7,8 5,7 8,1 1,2";
         string[] s = str.Split();
         List<double> list = s.Select(double.Parse).ToList();
         foreach (double rs in list)
         {
            Console.WriteLine(rs);
         }

         string[,] txtNum = { { "21,5", "123,1", "87,8" }, { "54,3", "2,7", "0,8" }, { "0,3", "7,9", "4,5" } };
         double[,] number = new double[txtNum.GetLength(0), txtNum.GetLength(1)];
         for (int i = 0; i < txtNum.GetLength(0); i++)
         {
            for (int j = 0; j < txtNum.GetLength(1); j++)
            {
               number[i, j] = Convert.ToDouble(txtNum[i, j]);
               Console.Write(number[i, j] + " ");
            }

            Console.WriteLine();
         }

         Console.WriteLine("Диагональ массива");
         Console.WriteLine(number[0, 0]);
         Console.WriteLine(number[1, 1]);
         Console.WriteLine(number[2, 2]);


         using (StreamReader sr = new StreamReader("a.txt"))
         {
            string num = sr.ReadLine();
            if (num != null)
               foreach (string numbers in num.Split())
               {
                  Console.WriteLine(numbers);
               }
         }

         string textFilePath = "a.txt";
         using (StreamReader reader = new StreamReader(textFilePath))
         {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
               if (double.TryParse(line, out double doubleValue))
               {
                  Console.WriteLine(doubleValue);
               }
               else
               {
                  Console.WriteLine($"Недопустимое значение double: {line}");
               }
            }
         }

         string textFilePath2 = "a.txt";
         using (StreamReader reader2 = new StreamReader(textFilePath2))
         {
            string line2;
            while ((line2 = reader2.ReadLine()) != null)
            {
               try
               {
                  double doubleValue2 = double.Parse(line2);
                  Console.WriteLine(doubleValue2);
               }
               catch (FormatException)
               {
                  Console.WriteLine($"Недопустимый формат double: {line2}");
               }
            }
         }

         Console.ReadKey();
      }
   }
}