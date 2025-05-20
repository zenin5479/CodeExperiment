using System;
using System.IO;
using System.Text;

// 1 Получаем количество строк и количество столбцов двумерного массива из консоли +
// 2 Читаем файл полностью конвертируем полученный двумерный массив в double и заполняем нужный двумерный массив, печатаем его в консоль +
// 3 Создаем одномерный массив размерности равный количеству строк +
// 4 Проводим поиск наибольшего элемента строки двухмерного массива и заполняем одномерный массив результатами +
// 5 Сохраняем полученный одномерный массив в файл (распечатываем его в консоль) +

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
            int indexLines = 0;
            while (indexLines < allLines.Length)
            {
               allLines[indexLines] = allLines[indexLines];
               Console.WriteLine(allLines[indexLines]);
               indexLines++;
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
         Console.WriteLine("Двумерный числовой массив для проведения поиска");
         double[,] arraySearch = InputArray(arrayDouble, n, m);
         Console.WriteLine();

         // Поиск максимального элемента строки (без флагов bool)
         double[] arrayMax = new double[arraySearch.GetLength(0)];
         int rowOut = 0;
         int columnOut = 0;
         while (rowOut < arraySearch.GetLength(0))
         {
            // Cчитаем, что максимум - это первый элемент строки
            double maxOut = arraySearch[rowOut, 0];
            while (columnOut < arraySearch.GetLength(1))
            {
               if (maxOut < arraySearch[rowOut, columnOut])
               {
                  maxOut = arraySearch[rowOut, columnOut];
               }

               columnOut++;
            }

            arrayMax[rowOut] = maxOut;
            //Console.WriteLine("Максимум в строке {0} равен: {1}", rowOut, maxOut);
            columnOut = 0;
            rowOut++;
         }

         Console.WriteLine("Массив максимальных значений строк");
         int indexMax = 0;
         while (indexMax < arrayMax.Length)
         {
            Console.Write("{0} ", arrayMax[indexMax]);
            indexMax++;
         }

         Console.WriteLine();

         FileWriteArray(arrayMax); // -
         //FileWriteString(arrayMax);

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

      public static void FileWriteString(double[] arrayRealNumbers)
      {
         // Объединение двухмерного массива double в одномерный массив строк для записи в файл
         Console.WriteLine("Одномерный массив строк");
         Console.BackgroundColor = ConsoleColor.DarkBlue;
         StringBuilder stringModified = new StringBuilder();
         int row = 0;
         while (row < arrayRealNumbers.GetLength(0))
         {
            if (row != arrayRealNumbers.GetLength(0) - 1)
            {
               stringModified.Append(arrayRealNumbers[row] + " ");
            }
            else
            {
               stringModified.Append(arrayRealNumbers[row]);
            }

            row++;
         }

         Console.Write(stringModified);
         Console.ResetColor();
         Console.WriteLine();
         // Запись массива строк в файл
         Console.WriteLine("Запись массива строк в файл");
         string filePath = AppContext.BaseDirectory + "b.txt";
         string[] arrayString = { stringModified.ToString() };

         File.WriteAllLines(filePath, arrayString);
      }

      public static void FileWriteArray(double[] arrayRealNumbers)
      {
         // Объединение двухмерного массива double в одномерный массив строк для записи в файл
         Console.WriteLine("Одномерный массив строк");
         //Console.BackgroundColor = ConsoleColor.DarkBlue; // -
         StringBuilder stringModified = new StringBuilder();
         string[] arrayString = new string[arrayRealNumbers.GetLength(0)];
         int row = 0;
         while (row < arrayRealNumbers.GetLength(0))
         {
            stringModified.Append(arrayRealNumbers[row]);
            string subLine = stringModified.ToString();
            arrayString[row] = subLine;
            Console.WriteLine(subLine);
            stringModified.Clear();
            row++;
         }

         //Console.ResetColor(); // -
         Console.WriteLine();
         // Запись массива строк в файл
         Console.WriteLine("Запись массива строк в файл");
         string filePath = AppContext.BaseDirectory + "c.txt";
         File.WriteAllLines(filePath, arrayString);
      }
   }
}