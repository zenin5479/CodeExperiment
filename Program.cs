using System;
using System.IO;
using System.Text;

namespace CodeExperiment
{
   internal class Program
   {
      static void Main()
      {
         //string filePath = AppContext.BaseDirectory + "a.txt";
         string filePath = AppContext.BaseDirectory + "b.txt";
         Console.BackgroundColor = ConsoleColor.DarkBlue;
         // Чтение файла за одну операцию
         string[] AllLines = File.ReadAllLines(filePath);
         if (AllLines == null)
         {
            Console.WriteLine("Ошибка при открытии файла для чтения");
         }
         else
         {
            Console.WriteLine("Исходный массив строк");
            string[] arrayLines = new string[AllLines.Length];
            for (int i = 0; i < AllLines.Length; i++)
            {
               arrayLines[i] = AllLines[i];
               Console.WriteLine(arrayLines[i]);
            }
            // Разделение строки на подстроки для определения количества столбцов в строке
            Console.ResetColor();
            int[] sizeArray = new int[arrayLines.Length];
            char symbolSpace = ' ';
            int countRow = 0;
            int counterSymbol = 0;
            int countСolumn = 0;
            while (countRow < arrayLines.Length)
            {
               string line = arrayLines[countRow];
               while (counterSymbol < line.Length)
               {
                  if (symbolSpace == line[counterSymbol])
                  {
                     countСolumn++;
                  }

                  if (counterSymbol == line.Length - 1)
                  {
                     countСolumn++;
                  }

                  counterSymbol++;
               }

               sizeArray[countRow] = countСolumn;
               //Console.WriteLine("В строке {0} количество столбцов {1}", countRow, countСolumn);
               countСolumn = 0;
               countRow++;
               counterSymbol = 0;
            }

            // Проверка количества столбцов для определения размерности двухмерного массива (прямоугольный/ступенчатый)
            int min = sizeArray[0];
            int max = sizeArray[0];
            int k = 0;
            while (k < sizeArray.Length)
            {
               if (sizeArray[k] < min)
               {
                  min = sizeArray[k];
               }

               if (sizeArray[k] > max)
               {
                  max = sizeArray[k];
               }

               k++;
            }

            Console.ResetColor();
            Console.WriteLine("Количество строк {0}", arrayLines.Length);
            Console.WriteLine("Минимальное количество столбцов: {0}", min);
            Console.WriteLine("Максимальное количество столбцов: {0}", max);
            if (min == max)
            {
               Console.ForegroundColor = ConsoleColor.Green;
               Console.WriteLine("Массив имеет одинаковое количество столбцов - прямоугольный");
            }
            else
            {
               Console.ForegroundColor = ConsoleColor.Red;
               Console.WriteLine("Массив имеет разное количество столбцов - ступенчатый");
            }

            Console.ResetColor();
            Console.WriteLine();

            // Разделение строки на подстроки и конвертация подстрок в double
            Console.WriteLine("Двухмерный числовой массив");
            StringBuilder stringModified = new StringBuilder();
            double[,] arrayDouble = new double[arrayLines.Length, max];
            char spaceCharacterOne = ' ';
            int l = 0;
            int m = 0;
            int n = 0;
            while (l < arrayDouble.GetLength(0))
            {
               string line = arrayLines[l];
               while (m < sizeArray[l])
               {
                  while (n < line.Length)
                  {
                     if (spaceCharacterOne != line[n])
                     {
                        stringModified.Append(line[n]);
                     }
                     else
                     {
                        string subLineOne = stringModified.ToString();
                        arrayDouble[l, m] = Convert.ToDouble(subLineOne);
                        Console.Write(arrayDouble[l, m] + " ");
                        stringModified.Clear();
                        m++;
                     }

                     if (n == line.Length - 1)
                     {
                        string subLineOne = stringModified.ToString();
                        arrayDouble[l, m] = Convert.ToDouble(subLineOne);
                        Console.Write(arrayDouble[l, m] + " ");
                        stringModified.Clear();
                        m++;
                     }

                     n++;
                  }

                  n = 0;
               }

               Console.WriteLine();
               m = 0;
               l++;

               Console.ResetColor();
            }
            Console.WriteLine();
            // Проверка количества всех элементов строки
            int bar = 0;
            double variable = arrayDouble[bar, arrayDouble.GetLength(1) - 8];
            int iterator = arrayDouble.GetLength(1);
            int first = 0;
            while (first < iterator)
            {
               Console.WriteLine("Элемент {0} строки по индексу {1} равен: {2}  ", bar, first, arrayDouble[bar, first] + " ");
               first++;
            }
         }

         //Console.WriteLine();
         Console.ReadKey();
      }
   }
}