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
         try
         {
            FileStream fpA = File.Open(filePath, FileMode.Open, FileAccess.Read);
            if (fpA == null)
            {
               Console.WriteLine("Ошибка при открытии файла для чтения");
            }
            // Cвязываем StreamReader c файловыйм потоком
            if (fpA != null)
            {
               // Классический вариант чтения файла построчно
               StreamReader readerone = new StreamReader(fpA);
               // Создаем List<string> для определения количество строк в файле
               List<string> arrayone = new List<string>();
               while (!readerone.EndOfStream)
               {
                  string stroka = readerone.ReadLine();
                  arrayone.Add(stroka);
                  Console.WriteLine(stroka);
               }
               readerone.Close();
               Console.WriteLine();

               Console.WriteLine("Количество строк {0}", arrayone.Count);
               // Предварительное разделение строк на подстроки для определения количества столбцов в файле
               int g = 0;
               // Создаем List<string> для определения количества столбцов в файле
               List<string> arraysplit = new List<string>();
               int[] checkinDimension = new int[arrayone.Count];
               while (g < arrayone.Count)
               {
                  arraysplit = new List<string>(arrayone[g].Split(" "));
                  //Console.WriteLine();
                  checkinDimension[g] = arraysplit.Count;
                  Console.WriteLine("Количество столбцов {0} в строке {1}", checkinDimension[g], g);
                  g++;
               }
               Console.WriteLine("Количество столбцов {0}", arraysplit.Count);

               int min = checkinDimension[0];
               int max = checkinDimension[0];
               int i = 0;
               while (i < checkinDimension.Length)
               {
                  if (checkinDimension[i] < min)
                  {
                     min = checkinDimension[i];
                  }

                  if (checkinDimension[i] > max)
                  {
                     max = checkinDimension[i];
                  }


                  i++;
               }

               Console.WriteLine();
               Console.ForegroundColor = ConsoleColor.Red;
               Console.WriteLine(min);
               Console.ForegroundColor = ConsoleColor.Green;
               Console.WriteLine(max);

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