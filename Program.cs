using System;
using System.IO;
using System.Text;

// 1 Получаем количество строк и количество столбцов двумерного массива из консоли
// 2 Читаем файл полностью конвертируем полученный двумерный массив в double и заполняем нужный двумерный массив, печатаем его в консоль
// 3 Создаем одномерный массив размерности равный количеству строк
// 4 Проводим поиск наибольшего элемента строки двухмерного массива и заполняем одномерный массив результатами
// 5 Сохраняем полученный одномерный массив в файл (распечатываем его в консоль)

namespace CodeExperiment
{
   internal class Program
   {
      static void Main()
      {
         double[,] arrayDouble =
         {
            {3.61, 1.12, 9.60, 7.96, 8.65, -2.18, 7.36, -4.54, -2.30, 4.14, 1.52, 3.67, 3.13, 1.39, -7.26, -4.20, 6.88, -8.50, 9.19, 3.39},
            {- 1.65, 0.41, 4.50, 1.09, 3.27, 1.13, -4.96, -9.82, -8.26, 0.08, 7.64, -0.55, -1.86, 8.36, -3.18, -3.22, -0.87, -6.87, 8.32, 8.83},
            {2.39, 1.54, 8.76, 6.49, -7.85, 9.07, -1.40, -7.28, -8.97, -9.03, -6.64, -3.34, 0.63, 9.86, -7.83, 5.53, -3.43, 5.32, 0.45, 7.38},
            {- 8.19, -3.85, -1.00, 6.63, 3.18, -3.00, 0.72, 5.80, 1.99, -8.65, 1.80, 8.51, 7.04, -8.29, 4.32, -8.84, 1.15, -5.38, -4.94, -2.42},
            {3.62, -0.08, 6.13, -4.64, 2.69, -3.67, -9.73, -3.10, 8.68, -9.42, -3.66, 7.14, -6.99, -6.34, 1.21, -6.28, -5.24, 6.11, 9.07, -3.65},
            {- 5.68, -5.10, 3.73, -0.70, -2.35, 6.49, 4.52, 2.13, -6.85, 0.67, -5.13, -4.54, -9.83, 3.88, 6.85, -6.40, 1.48, -3.42, 8.47, 1.96},
            {3.14, -1.45, -8.16, 1.48, -1.30, -2.09, -2.14, 9.61, 1.40, -5.50, -1.58, -0.63, -1.15, 0.83, -2.51, -0.81, -9.61, 6.61, -8.39, -7.95},
            {5.81, -5.75, 2.19, 4.04, -5.58, -5.99, -3.92, 6.60, -1.88, 0.51, 8.53, 2.35, -7.90, -4.05, -9.64, 8.54, -9.05, -4.75, -7.37, -9.76},
            {6.15, 4.40, -2.02, -3.35, -1.55, 2.51, 1.09, -8.08, -0.40, 5.17, -3.94, 7.21, -6.02, 4.47, 9.61, 7.51, -8.88, 0.37, -0.86, 8.74},
            {1.67, 2.25, -3.07, 3.67, -3.26, -5.61, 5.56, -5.65, -5.04, -6.94, -8.06, 2.96, 4.51, 2.69, -3.68, -6.43, -0.21, 6.72, 6.74, -6.48},
            {9.70, -7.37, -5.87, 6.92, 8.36, 7.39, 2.86, -5.83, 8.69, 5.12, -1.19, 8.12, -3.20, -6.42, -4.05, 3.18, 8.03, 3.59, -4.74, 2.09},
            {3.23, -8.88, 2.67, -0.51, -9.78, -9.73, 9.73, 2.88, -3.96, 3.16, 9.97, 2.46, -1.11, 2.84, -3.04, -7.77, -8.87, 1.36, -2.52, -7.12},
            {7.39, 9.17, -2.57, 2.73, -4.42, 6.53, 7.08, -9.29, -6.23, 8.24, -2.24, -7.03, -4.67, -8.79, -9.72, 6.39, 4.55, 5.95, -4.39, 1.55},
            {- 3.48, -4.82, -3.64, 4.71, 3.56, 9.40, -0.34, 3.61, 8.22, -2.25, -5.10, 9.83, -6.44, 2.70, -6.23, 6.11, 7.42, -4.52, -4.11, -9.19},
            {7.92, -7.33, -9.72, -7.59, -9.87, -0.26, 9.36, -4.26, 1.70, -3.61, 8.06, -7.47, 1.28, 8.53, 0.93, 5.44, 4.41, 1.88, -2.29, 9.13},
            {- 4.90, -1.49, -5.86, 5.76, 3.24, 9.68, 0.42, -8.94, 8.36, 0.32, -7.00, 1.26, -1.41, 0.47, -0.15, -3.60, -1.71, 7.77, 2.03, 1.55},
            {- 3.57, -8.41, -0.17, 7.17, 6.81, 6.45, -6.83, -4.14, 1.35, 2.29, 0.71, -0.88, 1.42, -4.79, -1.68, 1.08, 7.29, -7.15, -2.24, -5.77},
            {- 2.41, 4.80, 1.46, 7.45, -3.42, 4.12, -9.72, 9.37, -8.60, 0.11, 2.46, 4.92, -5.69, -7.96, 9.76, 1.55, -0.60, -0.68, 5.02, 6.41},
            {5.44, -5.28, 9.23, 2.79, 9.66, -1.79, -4.16, 3.80, -2.61, 6.02, -5.70, 7.98, 5.68, -3.18, 9.43, 6.02, -6.25, 3.24, -1.16, 7.97},
            {- 4.65, -7.14, 4.65, 9.31, -0.65, -0.51, 2.37, 4.78, -3.17, 4.12, 8.24, -5.13, -2.35, -6.06, 4.62, 0.06, 9.05, 0.61, -1.55, -1.77},
         };

         // Объединение двухмерного массива double в одномерный массив строк для записи в файл
         Console.WriteLine("Одномерный массив строк");
         Console.BackgroundColor = ConsoleColor.DarkBlue;
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

         Console.ResetColor();
         Console.WriteLine();
         // Запись массива строк в  файл
         string filePath = AppContext.BaseDirectory + "с.txt";
         File.WriteAllLines(filePath, arrayString);
         // Чтение массива строк из файла
         Console.WriteLine("Чтение массива строк из файла");
         Console.BackgroundColor = ConsoleColor.DarkBlue;
         string[] readFile = File.ReadAllLines(filePath);
         int i = 0;
         while (i < readFile.Length)
         {
            string s = readFile[i];
            Console.WriteLine(s);
            i++;
         }

         Console.ResetColor();
         Console.WriteLine();
         FileReadAllLines();

         Console.ReadKey();
      }

      private static void FileReadAllLines()
      {
         //string filePath = AppContext.BaseDirectory + "a.txt";
         //string filePath = AppContext.BaseDirectory + "b.txt";
         string filePath = AppContext.BaseDirectory + "с.txt";
         // Чтение файла за одну операцию
         string[] allLines = File.ReadAllLines(filePath);
         if (allLines == null)
         {
            Console.WriteLine("Ошибка при открытии файла для чтения");
         }
         else
         {
            Console.WriteLine("Исходный массив строк");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            string[] arrayLines = new string[allLines.Length];
            for (int i = 0; i < allLines.Length; i++)
            {
               arrayLines[i] = allLines[i];
               Console.WriteLine(arrayLines[i]);
            }
            // Разделение строки на подстроки по пробелу для определения количества столбцов в строке
            int[] sizeArray = new int[arrayLines.Length];
            char symbolSpace = ' ';
            int countRow = 0;
            int countSymbol = 0;
            int countСolumn = 0;
            while (countRow < arrayLines.Length)
            {
               string line = arrayLines[countRow];
               while (countSymbol < line.Length)
               {
                  if (symbolSpace == line[countSymbol])
                  {
                     countСolumn++;
                  }

                  if (countSymbol == line.Length - 1)
                  {
                     countСolumn++;
                  }

                  countSymbol++;
               }

               sizeArray[countRow] = countСolumn;
               //Console.WriteLine("В строке {0} количество столбцов {1}", countRow, countСolumn);
               countСolumn = 0;
               countRow++;
               countSymbol = 0;
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
            Console.WriteLine();

            // Разделение строки на подстроки по пробелу и конвертация подстрок в double
            Console.WriteLine("Двухмерный числовой массив");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            StringBuilder stringModified = new StringBuilder();
            double[,] arrayDouble = new double[arrayLines.Length, max];
            char spaceCharacter = ' ';
            int row = 0;
            int column = 0;
            int countCharacter = 0;
            while (row < arrayDouble.GetLength(0))
            {
               string line = arrayLines[row];
               while (column < sizeArray[row])
               {
                  while (countCharacter < line.Length)
                  {
                     if (spaceCharacter != line[countCharacter])
                     {
                        stringModified.Append(line[countCharacter]);
                     }
                     else
                     {
                        string subLine = stringModified.ToString();
                        arrayDouble[row, column] = Convert.ToDouble(subLine);
                        Console.Write(arrayDouble[row, column] + " ");
                        stringModified.Clear();
                        column++;
                     }

                     if (countCharacter == line.Length - 1)
                     {
                        string subLine = stringModified.ToString();
                        arrayDouble[row, column] = Convert.ToDouble(subLine);
                        Console.Write(arrayDouble[row, column]);
                        stringModified.Clear();
                        column++;
                     }

                     countCharacter++;
                  }

                  countCharacter = 0;
               }

               Console.WriteLine();
               column = 0;
               row++;
            }

            Console.ResetColor();
         }
      }

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

      //double[,] arrayDouble =
      //{
      //   { 1.5, 5.6, 9.8, 2.1, 5.8, 9.1, 7.3, 4.2, 2.9, 1.7 },
      //   { 8.3, 5.3, 5.7, 3.6, 3.7, 9.4, 5.3, 7.5, 8.1, 8.1 },
      //   { 1.3, 3.6, 7.5, 8.8, 8.3, 4.8, 7.2, 5.1, 4.1, 9.7 },
      //   { 1, 2, 3, 4, 5, 6, 83, 8, 9, -10 },
      //   { 1, 2, 3, 4, 5, 6, 84, 8, 9, 10 },
      //   { 1, 2, 3, 4, 5, 6, 88, 8, 9, -10 },
      //   { 1, 2, 3, 4, 5, 6, 86, 8, 9, 10 },
      //   { 1, 2, 3, 4, 5, 6, 87, 8, 9, -10 },
      //   { 1, 2, 3, 4, 5, 6, 88, 8, 9, 10 },
      //   { 1, 2, 3, 4, 5, 6, 89, 8, 9, -10 },
      //};
   }
}