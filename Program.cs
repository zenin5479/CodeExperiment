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
         double[,] sizeArrayDouble = new double[n, m];
         string filePath = AppContext.BaseDirectory + "a.txt";
         // Двумерный массив вещественных чисел
         double[,] arrayDoubleFile = { };


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

            Console.ResetColor();
            Console.WriteLine();

            // Разделение строки на подстроки по пробелу и конвертация подстрок в double
            Console.WriteLine("Двухмерный числовой массив");
            StringBuilder stringModified = new StringBuilder();
            arrayDoubleFile = new double[arrayLines.Length, sizeArray.Length];
            char spaceCharacter = ' ';
            int row = 0;
            int column = 0;
            int countCharacter = 0;
            while (row < arrayDoubleFile.GetLength(0))
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
                        arrayDoubleFile[row, column] = Convert.ToDouble(subLine);
                        Console.Write(arrayDoubleFile[row, column] + " ");
                        stringModified.Clear();
                        column++;
                     }

                     if (countCharacter == line.Length - 1)
                     {
                        string subLine = stringModified.ToString();
                        arrayDoubleFile[row, column] = Convert.ToDouble(subLine);
                        Console.Write(arrayDoubleFile[row, column]);
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

         double[,] hjkh = InputArray(sizeArrayDouble, n, m);

         FileWriteAllLines(arrayDoubleFile);
         Console.ReadKey();
      }

      private static double[,] InputArray(double[,] a, int n, int m)
      {
         //1 2 3 4 75 6 7 8 9 -10 1 2 3 4 5 6 87 8 9 -10
         //1 2 3 4 5 6 7 8 9 10 1 2 3 4 5 6 7 8 9 10

         for (int i = 0; i < n; i++)
         {
            for (int j = 0; j < m; j++)
            {

               //fscanf(f, "%lf", a[i, j]);
               Console.Write("{0:f} ", a[i, j]);
            }
            Console.WriteLine();
         }
      }

      public static int SizeRow()
      {
         int n;
         do
         {
            Console.WriteLine("Введите количество строк массива А");
            int.TryParse(Console.ReadLine(), out n);
            //n = Convert.ToInt32(Console.ReadLine());
            if (n <= 0 || n >= 20)
            {
               Console.WriteLine("Введено не верное значение");
            }
         } while (n <= 0 || n >= 20);

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
            if (m <= 0 || m >= 20)
            {
               Console.WriteLine("Введено не верное значение");
            }
         } while (m <= 0 || m >= 20);

         return m;
      }

      public static void FileWriteAllLines(double[,] arrayRealNumbers)
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