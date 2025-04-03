using System;
using System.Collections.Generic;
using System.IO;

namespace CodeExperiment
{
   internal class Program
   {
      static void Main()
      {
         string filePath = AppContext.BaseDirectory + "a.txt";
         //string filePath = AppContext.BaseDirectory + "b.txt";
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

               //readerOne.Close();
               Console.WriteLine();
               Console.WriteLine("Количество строк {0}", listOne.Count);

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

               // Проверка количества столбцов для определения вида будущего двухмерного массива (прямоугольный/зубчатый)
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
               fS.Dispose();

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

               // Разделение строки на подстроки и конвертация подстрок в double
               int z = 0;
               while (z < arrayTwo.GetLength(0))
               {
                  string[] arraysplit = arrayOne[z].Split(" ");
                  int x = 0;
                  while (x < arraysplit.GetLength(0))
                  {
                     arrayTwo[z, x] = Convert.ToDouble(arraysplit[x]);
                     Console.Write(arrayTwo[z, x] + " ");
                     x++;
                  }

                  Console.WriteLine();
                  z++;
               }
               Console.WriteLine();

               // Разделение строки на подстроки и конвертация подстрок в double
               //int z = 0;
               //while (z < arrayone.GetLength(0))
               //{
               //   string[] arraysplit = arrayone[z].Split(" ");
               //   int x = 0;
               //   while (x < arraysplit.GetLength(0))
               //   {
               //      arrayForFileSize[z, x] = Convert.ToDouble(arraysplit[x]);
               //      Console.Write(arrayForFileSize[z, x] + " ");
               //      x++;
               //   }
               //   Console.WriteLine();
               //   z++;
               //}
               //Console.WriteLine();


            }
         }
         catch (Exception e)
         {
            Console.WriteLine("Процесс завершился неудачей: {0}", e);
         }

         Console.WriteLine();
         Console.ReadKey();
      }
   }
}