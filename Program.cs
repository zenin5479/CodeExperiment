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
         string[] lines = File.ReadAllLines(filePath);
         if (lines == null)
         {
            Console.WriteLine("Ошибка при открытии файла для чтения");
         }
         else
         {
            Console.WriteLine("Исходный массив строк");
            string[] arrayLines = new string[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
               arrayLines[i] = lines[i];
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
               Console.WriteLine("В строке {0} количество столбцов {1}", countRow, countСolumn);
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
            StringBuilder stringModified = new StringBuilder(); // Заменить на массив
            double[,] arrayDouble = new double[arrayLines.Length, max];
            char spaceCharacterOne = ' ';
            int character, modified, others, sumAll;
            character = 0;
            modified = 0;
            others = 0;
            sumAll = 0;
            int l = 0;
            int m = 0;
            int n = 0;
            // Не присваивать лишние элементы массиву строк первые 3 строки содержат по 10 элементов - ступенчатый массив
            while (l < arrayDouble.GetLength(0))
            {
               string line = arrayLines[l];
               // Изменить количество получемых элементов в соответствии с количеством столбцов
               if (sizeArray[l] != max)
               {

               }

               while (m < arrayDouble.GetLength(1))
               {
                  sumAll++;
                  //bool isCharacter;
                  //bool isModified;
                  //bool isOthersCh = false;
                  while (n < line.Length)
                  {
                     if (spaceCharacterOne != line[n])
                     {
                        stringModified.Append(line[n]);
                        character++;
                        //isCharacter = true;
                        //isModified = true;
                     }
                     else
                     {
                        string subLineOne = stringModified.ToString();
                        arrayDouble[l, m] = Convert.ToDouble(subLineOne);
                        Console.Write(arrayDouble[l, m] + " ");
                        stringModified.Clear();
                        //isCharacter = false;
                        //isModified = false;
                        m++;
                     }

                     if (n == line.Length - 1)
                     {
                        string subLineOne = stringModified.ToString();
                        arrayDouble[l, m] = Convert.ToDouble(subLineOne);
                        Console.Write(arrayDouble[l, m] + " ");
                        stringModified.Clear();
                        //isCharacter = false;
                        //isModified = false;
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
            // Проверка элемента строки
            int bar = 0;
            double variable = arrayDouble[bar, arrayDouble.GetLength(1) - 8];
            int index = -1;
            int iterator = arrayDouble.GetLength(1) - 1;
            int first = 0;
            bool flag = false;
            // Обходим строку с последнего элемента
            while (first < iterator && flag != true)
            {
               if (Equals(arrayDouble[bar, iterator], variable))
               {
                  index = iterator;
                  flag = true;
               }

               iterator--;
            }

            Console.WriteLine("Элемент {0} строки: {1}; Индекс элемента: {2}  ", bar, variable, index);
         }

         Console.WriteLine();
         //FileReadAllLines(filePath);
         Console.ReadKey();
      }

      public static void FileReadAllLines(string filePath)
      {
         try
         {
            // Чтение файла выполняется за одну операцию
            string[] lines = File.ReadAllLines(filePath);
            string[] linesArrayOne = new string[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
               linesArrayOne[i] = lines[i];
               Console.WriteLine(linesArrayOne[i]);
            }

            Console.WriteLine();

            string[] linesArrayTwo = new string[lines.Length];
            Array.Copy(lines, 0, linesArrayTwo, 0, lines.Length);
            for (int i = 0; i < linesArrayTwo.Length; i++)
            {
               Console.WriteLine(linesArrayTwo[i]);
            }

            Console.WriteLine();
         }
         catch (Exception e)
         {
            Console.WriteLine("Процесс завершился неудачей {0}", e);
         }
      }
   }
}