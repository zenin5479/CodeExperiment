using System;
using System.Collections.Generic;
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
         FileStream fStream = File.Open(filePath, FileMode.Open, FileAccess.Read);
         if (fStream == null)
         {
            Console.WriteLine("Ошибка при открытии файла для чтения");
         }
         // Cвязываем StreamReader c файловыйм потоком
         if (fStream != null)
         {
            // Чтение файла построчно
            StreamReader readerOne = new StreamReader(fStream);
            // Создаем List<string> для определения количество строк в файле
            List<string> listOne = new List<string>();
            Console.WriteLine("Исходный массив строк");
            while (!readerOne.EndOfStream)
            {
               string stroka = readerOne.ReadLine();

               listOne.Add(stroka);
               Console.WriteLine(stroka);
            }

            readerOne.Close();
            fStream.Dispose();

            // Вариант 1 с помощью метода String.Split
            // Одномерный массив для определения количества столбцов в строке
            int[] arrayDimension = new int[listOne.Count];
            int d = 0;
            while (d < listOne.Count)
            {
               // Разделение строк на подстроки для определения количества столбцов в строке с помощью List<string>
               List<string> listSplit = new List<string>(listOne[d].Split(" "));
               arrayDimension[d] = listSplit.Count;
               //Console.WriteLine("В строке {0} количество столбцов {1}", d, arrayDimension[d]);
               d++;
            }

            // Проверка количества столбцов для определения размерности двухмерного массива (прямоугольный/зубчатый)
            int minOne = arrayDimension[0];
            int maxOne = arrayDimension[0];
            int f = 0;
            while (f < arrayDimension.Length)
            {
               if (arrayDimension[f] < minOne)
               {
                  minOne = arrayDimension[f];
               }

               if (arrayDimension[f] > maxOne)
               {
                  maxOne = arrayDimension[f];
               }

               f++;
            }

            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Количество строк {0}", listOne.Count);
            Console.WriteLine("Минимальное количество столбцов: {0}", minOne);
            Console.WriteLine("Максимальное количество столбцов: {0}", maxOne);
            if (minOne == maxOne)
            {
               Console.ForegroundColor = ConsoleColor.Green;
               Console.WriteLine("Массив имеет одинаковое количество столбцов - прямоугольный");
            }

            else
            {
               Console.ForegroundColor = ConsoleColor.Red;
               Console.WriteLine("Массив имеет разное количество столбцов - зубчатый");
            }

            //Console.WriteLine();

            string[] arrayOne = new string[listOne.Count];
            double[,] arrayTwo = new double[arrayOne.GetLength(0), maxOne];
            int h = 0;
            while (h < listOne.Count)
            {
               arrayOne[h] = listOne[h];
               //Console.WriteLine(arrayOne[h]);
               h++;
            }

            Console.WriteLine();
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            // Разделение строки на подстроки и конвертация подстрок в double
            Console.WriteLine("Двухмерный числовой массив");
            int z = 0;
            while (z < arrayTwo.GetLength(0))
            {
               string[] arraySplit = arrayOne[z].Split(" ");
               int x = 0;
               while (x < arraySplit.GetLength(0))
               {
                  arrayTwo[z, x] = Convert.ToDouble(arraySplit[x]);
                  Console.Write(arrayTwo[z, x] + " ");
                  x++;
               }

               z++;
               Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine(arrayTwo[0, arrayTwo.GetLength(0) - 1]);
            Console.WriteLine();

            // Вариант 2 с помощью StringBuilder
            // Разделение строки на подстроки для определения количества столбцов в строке с помощью StringBuilder
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.Magenta;
            StringBuilder stringModified = new StringBuilder();
            List<string> listColumns = new List<string>();
            int[] sizeArray = new int[listOne.Count];
            char spaceCharacter = ' ';
            int w = 0;
            int t = 0;
            while (t < listOne.Count)
            {
               string line = listOne[t];
               while (w < line.Length)
               {
                  if (spaceCharacter != line[w])
                  {
                     stringModified.Append(line[w]);
                  }
                  else
                  {
                     string subLine = stringModified.ToString();
                     listColumns.Add(subLine);
                     Console.Write(subLine + " ");
                     stringModified.Clear();
                  }

                  if (w == line.Length - 1)
                  {
                     string subLine = stringModified.ToString();
                     listColumns.Add(subLine);
                     Console.Write(subLine + " ");
                     stringModified.Clear();
                  }

                  w++;
               }

               Console.WriteLine();

               sizeArray[t] = listColumns.Count;
               //Console.WriteLine("В строке {0} количество столбцов {1}", t, listColumns.Count);
               t++;
               w = 0;
               listColumns.Clear();
            }

            // Проверка количества столбцов для определения размерности двухмерного массива (прямоугольный/зубчатый)
            int minTwo = sizeArray[0];
            int maxTwo = sizeArray[0];
            int p = 0;
            while (p < sizeArray.Length)
            {
               if (sizeArray[p] < minTwo)
               {
                  minTwo = sizeArray[p];
               }

               if (sizeArray[p] > maxTwo)
               {
                  maxTwo = sizeArray[p];
               }

               p++;
            }

            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Количество строк {0}", listOne.Count);
            Console.WriteLine("Минимальное количество столбцов: {0}", minTwo);
            Console.WriteLine("Максимальное количество столбцов: {0}", maxTwo);
            if (minTwo == maxTwo)
            {
               Console.ForegroundColor = ConsoleColor.Green;
               Console.WriteLine("Массив имеет одинаковое количество столбцов - прямоугольный");
            }
            else
            {
               Console.ForegroundColor = ConsoleColor.Red;
               Console.WriteLine("Массив имеет разное количество столбцов - зубчатый");
            }

            Console.ResetColor();
         }

         Console.ReadKey();
      }
   }
}