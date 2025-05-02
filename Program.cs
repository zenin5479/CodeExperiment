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
            string[] arrayOne = new string[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
               arrayOne[i] = lines[i];
               Console.WriteLine(arrayOne[i]);
            }
            // Разделение строки на подстроки для определения количества столбцов в строке
            Console.ResetColor();
            int[] sizeArray = new int[arrayOne.Length];
            char spaceCharacter = ' ';
            int d = 0;
            int f = 0;
            int h = 0;
            while (h < arrayOne.Length)
            {
               string line = arrayOne[h];
               while (f < line.Length)
               {
                  if (spaceCharacter == line[f])
                  {
                     d++;
                  }

                  if (f == line.Length - 1)
                  {
                     d++;
                  }

                  f++;
               }

               sizeArray[h] = d;
               //Console.WriteLine("В строке {0} количество столбцов {1}", h, d);
               d = 0;
               h++;
               f = 0;
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
            Console.WriteLine("Количество строк {0}", arrayOne.Length);
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
            StringBuilder stringModifiedOne = new StringBuilder(); // Заменить на массив
            double[,] arrayFour = new double[arrayOne.Length, max];
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
            while (l < arrayFour.GetLength(0))
            {
               string line = arrayOne[l];
               // Изменить количество получемых элементов в соответствии с количеством столбцов
               if (sizeArray[l] != max)
               {

               }

               while (m < arrayFour.GetLength(1))
               {
                  sumAll++;
                  //bool isCharacter;
                  //bool isModified;
                  //bool isOthersCh = false;
                  while (n < line.Length)
                  {
                     if (spaceCharacterOne != line[n])
                     {
                        stringModifiedOne.Append(line[n]);
                        character++;
                        //isCharacter = true;
                        //isModified = true;
                     }
                     else
                     {
                        string subLineOne = stringModifiedOne.ToString();
                        arrayFour[l, m] = Convert.ToDouble(subLineOne);
                        Console.Write(arrayFour[l, m] + " ");
                        stringModifiedOne.Clear();
                        //isCharacter = false;
                        //isModified = false;
                        m++;
                     }

                     if (n == line.Length - 1)
                     {
                        string subLineOne = stringModifiedOne.ToString();
                        arrayFour[l, m] = Convert.ToDouble(subLineOne);
                        Console.Write(arrayFour[l, m] + " ");
                        stringModifiedOne.Clear();
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
            // Проверка последнего элемента первой строки
            Console.WriteLine("Последний элемент первой строки : {0}", arrayFour[0, arrayFour.GetLength(1) - 1]);
           
            //Console.WriteLine("Индекс последнего элемента первой строки : {0}", myIndex);
         }

         Console.WriteLine();
         FileReadAllLines(filePath);
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