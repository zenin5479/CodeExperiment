using System;
using System.IO;
using System.Text;

namespace CodeExperiment
{
   internal class Program
   {
      static void Main()
      {
         //double[,] arrayDouble = 
         //{
         //   { 1, 2, 3, 4, 5, 6, 7, 8, 9, -10, 1, 2, 3, 4, 5, 6, 80, 8, 9, -10 },
         //   { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 1, 2, 3, 4, 5, 6, 81, 8, 9, 10 },
         //   { 1, 2, 3, 4, 5, 6, 7, 8, 9, -10, 1, 2, 3, 4, 5, 6, 82, 8, 9, -10 },
         //   { 1, 2, 3, 4, 5, 6, 7, 8, 9, -10, 1, 2, 3, 4, 5, 6, 83, 8, 9, -10 },
         //   { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 1, 2, 3, 4, 5, 6, 84, 8, 9, 10 },
         //   { 1, 2, 3, 4, 5, 6, 7, 8, 9, -10, 1, 2, 3, 4, 5, 6, 88, 8, 9, -10 },
         //   { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 1, 2, 3, 4, 5, 6, 86, 8, 9, 10 },
         //   { 1, 2, 3, 4, 5, 6, 7, 8, 9, -10, 1, 2, 3, 4, 5, 6, 87, 8, 9, -10 },
         //   { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 1, 2, 3, 4, 5, 6, 88, 8, 9, 10 },
         //   { 1, 2, 3, 4, 5, 6, 7, 8, 9, -10, 1, 2, 3, 4, 5, 6, 89, 8, 9, -10 },
         //};

         double[,] arrayDouble =
         {
            { 1.5, 5.6, 9.8, 2.1, 5.8, 9.1, 7.3, 4.2, 2.9, 1.7 },
            { 8.3, 5.3, 5.7, 3.6, 3.7, 9.4, 5.3, 7.5, 8.1, 8.1 },
            { 1.3, 3.6, 7.5, 8.8, 8.3, 4.8, 7.2, 5.1, 4.1, 9.7 },
            { 1, 2, 3, 4, 5, 6, 83, 8, 9, -10 },
            { 1, 2, 3, 4, 5, 6, 84, 8, 9, 10 },
            { 1, 2, 3, 4, 5, 6, 88, 8, 9, -10 },
            { 1, 2, 3, 4, 5, 6, 86, 8, 9, 10 },
            { 1, 2, 3, 4, 5, 6, 87, 8, 9, -10 },
            { 1, 2, 3, 4, 5, 6, 88, 8, 9, 10 },
            { 1, 2, 3, 4, 5, 6, 89, 8, 9, -10 },
         };

         // Объединение двухмерного массива double в одномерный массив строк для записи в файл
         //Console.BackgroundColor = ConsoleColor.Magenta;
         Console.WriteLine("Одномерный массив строк");
         StringBuilder stringModified = new StringBuilder();
         string[] arrayString = new string[arrayDouble.GetLength(0)];
         int row = 0;
         int column = 0;
         while (row < arrayDouble.GetLength(0))
         {
            while (column < arrayDouble.GetLength(1))
            {
               if (column != arrayDouble.GetLength(1) - 1)
               {
                  stringModified.Append(arrayDouble[row, column] + " ");
                  column++;
               }
               else
               {
                  stringModified.Append(arrayDouble[row, column]);
                  column++;
               }
            }

            string subLine = stringModified.ToString();
            arrayString[row] = subLine;
            Console.Write(subLine);
            stringModified.Clear();
            Console.WriteLine();
            column = 0;
            row++;
         }

         Console.WriteLine();

         string filePath = AppContext.BaseDirectory + "с.txt";
         File.WriteAllLines(filePath, arrayString);
         string[] readFile = File.ReadAllLines(filePath);
         int i = 0;
         while (i < readFile.Length)
         {
            string s = readFile[i];
            Console.WriteLine(s);
            i++;
         }

         Console.ReadKey();
      }
   }
}