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
         Console.BackgroundColor = ConsoleColor.DarkMagenta;
         // Чтение массива строк из файла
         Console.WriteLine("Чтение массива строк из файла");
         string[] readFile = File.ReadAllLines(filePath);
         int i = 0;
         while (i < readFile.Length)
         {
            string s = readFile[i];
            Console.WriteLine(s);
            i++;
         }

         Console.ResetColor();

         FileReadAllLines();

         Console.ReadKey();
      }

      private static void FileReadAllLines()
      {
         // Переводит (,) в (.)
         //System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

         //string filePath = AppContext.BaseDirectory + "a.txt";
         string filePath = AppContext.BaseDirectory + "b.txt";
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
            Console.ResetColor();
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

            // Разделение строки на подстроки по пробелу и конвертация подстрок в double
            Console.WriteLine("Двухмерный числовой массив");
            Console.BackgroundColor = ConsoleColor.Magenta;
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
            //Console.WriteLine();
            // Проверка всех имеющихся элементов в строке
            int lines = 2;
            int range = arrayDouble.GetLength(1);
            int iterator = 0;
            while (iterator < range)
            {
               //Console.WriteLine("Элемент {0} строки по индексу {1} равен: {2}", lines, iterator, arrayDouble[lines, iterator]);
               iterator++;
            }
         }

         Console.ReadKey();
      }
   }
}