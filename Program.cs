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
         int n = SizeRow();
         int m = SizeColumn();
         string filePath = AppContext.BaseDirectory + "a.txt";
         // Двумерный массив вещественных чисел
         double[,] arrayDouble = { };
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
            for (int i = 0; i < allLines.Length; i++)
            {
               allLines[i] = allLines[i];
               Console.WriteLine(allLines[i]);
            }
            // Разделение строки на подстроки по пробелу для определения количества столбцов в строке
            int[] sizeArray = new int[allLines.Length];
            char symbolSpace = ' ';
            int countRow = 0;
            int countSymbol = 0;
            int countСolumn = 0;
            while (countRow < allLines.Length)
            {
               string line = allLines[countRow];
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

            Console.ResetColor();
            Console.WriteLine();

            // Разделение строки на подстроки по пробелу и конвертация подстрок в double
            Console.WriteLine("Двухмерный числовой массив"); //
            StringBuilder stringModified = new StringBuilder();
            arrayDouble = new double[allLines.Length, sizeArray.Length];
            char spaceCharacter = ' ';
            int row = 0;
            int column = 0;
            int countCharacter = 0;
            while (row < arrayDouble.GetLength(0))
            {
               string line = allLines[row];
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

         Console.WriteLine();
         Console.WriteLine("Двухмерный числовой массив для проведения поиска");
         double[,] arraySearch = InputArray(arrayDouble, n, m);
         Console.WriteLine();

         // Поиск максимального элемента строки
         double[] arrayOutputMaxOne = new double[arraySearch.GetLength(0)];
         double[] arrayOutputMinOne = new double[arraySearch.GetLength(0)];
         int rowOne = 0;
         int columnOne = 0;
         while (rowOne < arraySearch.GetLength(0))
         {
            // Cчитаем, что максимум - это первый элемент строки
            double maxOne = arraySearch[rowOne, 0];
            // Cчитаем, что минимум - это первый элемент строки
            double minOne = arraySearch[rowOne, 0];
            while (columnOne < arraySearch.GetLength(1))
            {
               if (maxOne < arraySearch[rowOne, columnOne])
               {
                  maxOne = arraySearch[rowOne, columnOne];
                  //
               }

               if (minOne > arraySearch[rowOne, columnOne])
               {
                  minOne = arraySearch[rowOne, columnOne];
                  //
               }

               columnOne++;
            }

            arrayOutputMaxOne[rowOne] = maxOne;
            arrayOutputMinOne[rowOne] = minOne;
            Console.WriteLine("Максимум в строке {0} равен: {1}", rowOne, maxOne);
            Console.WriteLine("Минимум в строке {0} равен: {1}", rowOne, minOne);
            columnOne = 0;
            rowOne++;
         }

         // Поиск максимального элемента строки
         double[] arrayOutput1 = new double[arraySearch.GetLength(0)];

         bool fl = false;
         int row1 = 0;
         int column1 = 1;
         while (row1 < arraySearch.GetLength(0))
         {
            double max1 = arraySearch[row1, 0];

            while (column1 < arraySearch.GetLength(1))
            {
               if (arraySearch[row1, column1] > max1)
               {
                  max1 = arraySearch[row1, column1];
                  fl = true;
               }

               column1++;
            }
            if (fl)
            {
               arrayOutput1[row1] = max1;
            }

            Console.WriteLine("Максимум в строке {0} равен: {1}", row1, max1);
            column1 = 0;
            row1++;
         }

         //double minOne = arraySearch[0, 0];
         //double maxOne = arraySearch[0, 0];
         double[] arrayResultMin = new double[arraySearch.GetLength(0)];
         double[] arrayResultMax = new double[arraySearch.GetLength(0)];
         //int r = 0;
         //int c = 0;
         //bool flOne = false;
         //bool flTwo = false;
         //for (int i = 0; i < arraySearch.GetLength(0); i++)
         //{
         //   double maxOne = arraySearch[i, 0];
         //   double minOne = arraySearch[i, 0];
         //   for (int j = 1; j < arraySearch.GetLength(1); j++)
         //   {
         //      if (arraySearch[i, j] > maxOne)
         //      {
         //         maxOne = arraySearch[i, j];
         //         flOne = true;
         //      }
         //      if (arraySearch[i, j] < minOne)
         //      {
         //         minOne = arraySearch[i, j];
         //         flTwo = true;
         //      }
         //   }
         //   if (flOne)
         //   {
         //      arrayResultMax[i] = maxOne;
         //      flOne = false;
         //   }
         //   if (flTwo)
         //   {
         //      arrayResultMin[i] = minOne;
         //      flTwo = false;
         //   }
         //}
         Console.WriteLine();
         //Console.WriteLine("Минимальный элемент строки: {0}", arrayResultMin[r]);
         //Console.WriteLine("Максимальный элемент строки: {0}", arrayResultMax[r]);

         Console.WriteLine("Массив максимальных значений строк");
         int xc = 0;
         while (xc < arrayOutput1.Length)
         {
            Console.Write("{0} ", arrayOutput1[xc]);
            xc++;
         }
         Console.WriteLine();
         FileWriteArray(arraySearch);
         Console.ReadKey();
      }

      private static double[,] InputArray(double[,] inputArray, int n, int m)
      {
         double[,] outputArray = new double[n, m];
         for (int i = 0; i < n; i++)
         {
            for (int j = 0; j < m; j++)
            {
               outputArray[i, j] = inputArray[i, j];
               //Console.Write("{0:f2} ", outputArray[i, j]);
               //Console.Write("{0:f} ", outputArray[i, j]);
               Console.Write("{0} ", outputArray[i, j]);
            }
            Console.WriteLine();
         }

         return outputArray;
      }

      public static int SizeRow()
      {
         int n;
         do
         {
            Console.WriteLine("Введите количество строк массива А");
            int.TryParse(Console.ReadLine(), out n);
            //n = Convert.ToInt32(Console.ReadLine());
            if (n <= 0 || n > 20)
            {
               Console.WriteLine("Введено не верное значение");
            }
         } while (n <= 0 || n > 20);

         return n;
      }

      public static int SizeColumn()
      {
         int m;
         do
         {
            Console.WriteLine("Введите количество столбцов массива А");
            int.TryParse(Console.ReadLine(), out m);
            //m = Convert.ToInt32(Console.ReadLine());
            if (m <= 0 || m > 20)
            {
               Console.WriteLine("Введено не верное значение");
            }
         } while (m <= 0 || m > 20);

         return m;
      }

      public static void FileWriteArray(double[,] arrayRealNumbers)
      {
         // Объединение двухмерного массива double в одномерный массив строк для записи в файл
         Console.WriteLine("Одномерный массив строк");
         Console.BackgroundColor = ConsoleColor.DarkBlue;
         StringBuilder stringModified = new StringBuilder();
         string[] arrayString = new string[arrayRealNumbers.GetLength(0)];
         int row = 0;
         int column = 0;
         while (row < arrayRealNumbers.GetLength(0))
         {
            while (column < arrayRealNumbers.GetLength(1))
            {
               if (column != arrayRealNumbers.GetLength(1) - 1)
               {
                  stringModified.Append(arrayRealNumbers[row, column] + " ");
                  column++;
               }
               else
               {
                  stringModified.Append(arrayRealNumbers[row, column]);
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
         // Запись массива строк в файл
         Console.WriteLine("Запись массива строк в файл");
         string filePath = AppContext.BaseDirectory + "b.txt";
         File.WriteAllLines(filePath, arrayString);
      }
   }
}