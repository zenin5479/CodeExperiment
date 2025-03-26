using System;
using System.Collections.Generic;
using System.IO;

namespace CodeExperiment
{
   internal class Program
   {
      static void Main()
      {
         int n = 10;
         int m = 20;

         double[,] arrayForFileSize = new double[n, m];
         double[,] number = new double[arrayForFileSize.GetLength(0), arrayForFileSize.GetLength(1)];
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
               
               List<string> arrayone = new List<string>();
               while (!readerone.EndOfStream)
               {
                  string stroka = readerone.ReadLine();
                  arrayone.Add(stroka);
                  Console.WriteLine(stroka);

               }
               readerone.Close();
               Console.WriteLine();
               // Количество строк
               Console.WriteLine(arrayone.Count);
               Console.WriteLine();

               //Разделение строки на подстроки
               int z = 0;
               List<string> arraysplit = new List<string>();
               while (z < arrayone.Count)
               {
                  arraysplit = new List<string>(arrayone[z].Split(" "));
                  //Console.WriteLine();
                  z++;
               }
               //Console.WriteLine();
               // Количество столбцов
               Console.WriteLine(arraysplit.Count);
               //Console.WriteLine();

               //Console.WriteLine();

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