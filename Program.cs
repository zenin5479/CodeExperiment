using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace CodeExperiment
{
   internal class Program
   {
      private static Stopwatch _sw = new Stopwatch();

      static void Main()
      {
         //string filePath = AppContext.BaseDirectory + "a.txt";
         string filePath = AppContext.BaseDirectory + "b.txt";
         try
         {
            FileStream fS = File.Open(filePath, FileMode.Open, FileAccess.Read);
            if (fS == null)
            {
               Console.WriteLine("Ошибка при открытии файла для чтения");
            }
            // Cвязываем StreamReader c файловыйм потоком
            if (fS != null)
            {
               // Чтение файла построчно
               StreamReader readerOne = new StreamReader(fS);
               // Создаем List<string> для определения количество строк в файле
               List<string> listOne = new List<string>();
               while (!readerOne.EndOfStream)
               {
                  string stroka = readerOne.ReadLine();
                  listOne.Add(stroka);
                  Console.WriteLine(stroka);
               }

               readerOne.Close();
               fS.Dispose();
               Console.WriteLine("Количество строк {0}", listOne.Count);
               Console.WriteLine();
               // Одномерный массив для определения количества столбцов в строке
               int[] arrayDimension = new int[listOne.Count];
               int g = 0;
               while (g < listOne.Count)
               {
                  // Разделение строк на подстроки для определения количества столбцов в строке с помощью List<string>
                  List<string> listSplit = new List<string>(listOne[g].Split(" "));
                  arrayDimension[g] = listSplit.Count;
                  //Console.WriteLine("В строке {0} количество столбцов {1}", g, arrayDimension[g]);
                  g++;
               }

               // Проверка количества столбцов для определения размерности двухмерного массива (прямоугольный/зубчатый)
               int min = arrayDimension[0];
               int max = arrayDimension[0];
               int f = 0;
               while (f < arrayDimension.Length)
               {
                  if (arrayDimension[f] < min)
                  {
                     min = arrayDimension[f];
                  }

                  if (arrayDimension[f] > max)
                  {
                     max = arrayDimension[f];
                  }

                  f++;
               }

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
                  Console.WriteLine("Массив имеет разное количество столбцов - зубчатый");
               }

               //Console.WriteLine();
               Console.ResetColor();
               string[] arrayOne = new string[listOne.Count];
               double[,] arrayTwo = new double[arrayOne.GetLength(0), max];
               int h = 0;
               while (h < listOne.Count)
               {
                  arrayOne[h] = listOne[h];
                  //Console.WriteLine(arrayOne[h]);
                  h++;
               }

               Console.WriteLine();

               // Разделение строки на подстроки и конвертация подстрок в double
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

               // Разделение строки на подстроки для определения количества столбцов в строке с помощью StringBuilder
               StringBuilder stringModified = new StringBuilder();
               List<string> listColumns = new List<string>();
               char spaceCharacter = ' ';
               int w = 0;
               int t = 0;
               while (t < listOne.Count)
               {
                  string line = listOne[t];
                  while (w < line.Length)
                  {
                     bool equally = spaceCharacter.Equals(line[w]);
                     if (!equally && w != line.Length - 1)
                     {
                        stringModified.Append(line[w]);
                     }
                     else
                     {
                        string subLine = stringModified.ToString();
                        listColumns.Add(subLine);
                        stringModified.Clear();
                     }
                     w++;
                  }
                  t++;
                  w = 0;
                  Console.WriteLine("В строке {0} количество столбцов {1}", t, listColumns.Count);
                  listColumns.Clear();
               }
            }
         }
         catch (Exception e)
         {
            Console.WriteLine("Процесс завершился неудачей: {0}", e);
         }


         // Заголовок окна
         Console.Title = "Класс Stopwatch";
         Console.ForegroundColor = ConsoleColor.Red;
         Console.WriteLine("Скорость выполнения циклов");
         Console.ForegroundColor = ConsoleColor.Green;
         int rep = 10000001;
         // Начало отсчета с 1
         int i = 0;
         while (i++ < 10)
         {
            Console.WriteLine("{0} ", i);
            For(rep);
            While(rep);
            DoWhile(rep);
         }
         Console.WriteLine();
         Console.ForegroundColor = ConsoleColor.Yellow;
         // Начало отсчета с 0
         int j = 0;
         while (j < 10)
         {
            Console.WriteLine("{0} ", j);
            j++;
            For(rep);
            While(rep);
            DoWhile(rep);
         }
         Console.WriteLine();
         Console.ReadKey();





         //Console.WriteLine();
         Console.ReadKey();
      }

      // Цикл for
      private static void For(int rep)
      {
         _sw = Stopwatch.StartNew();
         for (int i = 0; i < rep; ++i)
         {
            double sin = Math.Sin(i);
         }
         _sw.Stop();
         Console.Write("Цикл for\t");
         Console.WriteLine(_sw.ElapsedMilliseconds + " ms");
      }

      // Цикл while
      private static void While(int rep)
      {
         _sw = Stopwatch.StartNew();
         int i = 0;
         while (i++ < rep)
         {
            double sin = Math.Sin(i);
         }
         _sw.Stop();
         Console.Write("Цикл while\t");
         Console.WriteLine(_sw.ElapsedMilliseconds + " ms");
      }

      // Цикл do-while
      private static void DoWhile(int rep)
      {
         _sw = Stopwatch.StartNew();
         int i = 0;
         do
         {
            double sin = Math.Sin(i);
         }
         while (i++ < rep);
         _sw.Stop();
         Console.Write("Цикл do-while:\t");
         Console.WriteLine(_sw.ElapsedMilliseconds + " ms");
      }
   }
}