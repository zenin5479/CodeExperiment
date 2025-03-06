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
         int n = 3;
         int m = 3;
         bool fl = false;

         double[,] a = new double[n, m];

         //string path = AppContext.BaseDirectory;
         //string filePath = path + "a.txt";
         //FileStream fpA = File.Open(filePath, FileMode.Open, FileAccess.Read);
         //if (fpA == null)
         //{
         //   Console.WriteLine("Ошибка при открытии файла для чтения");
         //}

         // Calling the ReadLines(String) function 

         string secondLine = File.ReadLines("a.txt").ElementAtOrDefault(0);
         Console.WriteLine(secondLine);

         IEnumerable<string> lines = File.ReadLines("a.txt");
         //Console.WriteLine(string.Join(Environment.NewLine, lines));

         foreach (string line in File.ReadLines("a.txt"))
         {
            // Printing the file contents 
            //Console.WriteLine(line);
         }


         // Правильно обрабатывает все строки
         //using (TextReader reader = File.OpenText("a.txt"))
         //{
         //   string line;
         //   while ((line = reader.ReadLine()) != null)
         //   {
         //      string[] bits = line.Split(' ');
         //      foreach (string bit in bits)
         //      {
         //         double value;
         //         if (!double.TryParse(bit, out value))
         //         {
         //            Console.WriteLine("Неудовлетворительное значение");
         //         }
         //         else
         //         {
         //            Console.Write(bit + " ");
         //         }
         //      }
         //      Console.WriteLine();
         //   }
         //}

         //Console.WriteLine();

         // Правильно обрабатывает 3 строки
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

         Console.WriteLine();

         // Правильно обрабатывает 1 строку
         using (StreamReader sr = new StreamReader("a.txt"))
         {
            string num = sr.ReadLine();
            if (num != null)
            {
               foreach (string numbers in num.Split(" "))
               {
                  Console.Write(numbers + " ");
               }
            }

            Console.WriteLine();
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

         Console.WriteLine();

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

         Console.WriteLine();
         Console.ReadKey();
      }
   }
}