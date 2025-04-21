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
            int a = 0;
            while (a < listOne.Count)
            {
               // Разделение строк на подстроки для определения количества столбцов в строке с помощью List<string>
               List<string> listSplit = new List<string>(listOne[a].Split(" "));
               arrayDimension[a] = listSplit.Count;
               //Console.WriteLine("В строке {0} количество столбцов {1}", d, arrayDimension[d]);
               a++;
            }

            // Проверка количества столбцов для определения размерности двухмерного массива (прямоугольный/зубчатый)
            int minOne = arrayDimension[0];
            int maxOne = arrayDimension[0];
            int b = 0;
            while (b < arrayDimension.Length)
            {
               if (arrayDimension[b] < minOne)
               {
                  minOne = arrayDimension[b];
               }

               if (arrayDimension[b] > maxOne)
               {
                  maxOne = arrayDimension[b];
               }

               b++;
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
            int c = 0;
            while (c < listOne.Count)
            {
               arrayOne[c] = listOne[c];
               //Console.WriteLine(arrayOne[h]);
               c++;
            }

            Console.WriteLine();
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.Magenta;
            // Разделение строки на подстроки и конвертация подстрок в double
            Console.WriteLine("Двухмерный числовой массив");
            int d = 0;
            while (d < arrayTwo.GetLength(0))
            {
               string[] arraySplit = arrayOne[d].Split(" ");
               int e = 0;
               while (e < arraySplit.GetLength(0))
               {
                  arrayTwo[d, e] = Convert.ToDouble(arraySplit[e]);
                  Console.Write(arrayTwo[d, e] + " ");
                  e++;
               }

               d++;
               Console.WriteLine();
            }

            Console.WriteLine();
            Console.ResetColor();
            Console.WriteLine("Последний элемент первой строки : {0}", arrayTwo[0, arrayTwo.GetLength(1) - 1]);
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
                     //Console.Write(subLine + " ");
                     stringModified.Clear();
                  }

                  if (w == line.Length - 1)
                  {
                     string subLine = stringModified.ToString();
                     listColumns.Add(subLine);
                     //Console.Write(subLine + " ");
                     stringModified.Clear();
                  }

                  w++;
               }

               //Console.WriteLine();

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
            //Console.WriteLine();
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
            //Console.BackgroundColor = ConsoleColor.DarkBlue;

            Console.WriteLine();
            StringBuilder stringModifiedOne = new StringBuilder();
            double[,] arrayFour = new double[listOne.Count, maxTwo];
            char spaceCharacterOne = ' ';
            int zi = 0;
            int zj = 0;
            int zk = 0;
            while (zi < arrayFour.GetLength(0))
            {
               string line = listOne[zi];
               while (zj < arrayFour.GetLength(1))
               {
                  while (zk < line.Length)
                  {
                     if (spaceCharacterOne != line[zk])
                     {
                        stringModifiedOne.Append(line[zk]);
                     }
                     else
                     {
                        string subLineOne = stringModifiedOne.ToString();
                        arrayFour[zi, zj] = Convert.ToDouble(subLineOne);
                        Console.Write(arrayFour[zi, zj] + " ");
                        stringModifiedOne.Clear();
                        zj++;
                     }

                     if (zk == line.Length - 1)
                     {
                        string subLineOne = stringModifiedOne.ToString();
                        arrayFour[zi, zj] = Convert.ToDouble(subLineOne);
                        Console.Write(arrayFour[zi, zj] + " ");
                        stringModifiedOne.Clear();
                        zj++;
                     }

                     zk++;
                  }
                  zk = 0;

                  Console.WriteLine();
               }
               zj = 0;
               zi++;
            }

            Console.ResetColor();
         }

         Console.ReadKey();
      }
   }
}