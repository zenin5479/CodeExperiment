using System;
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
         string filePath = AppContext.BaseDirectory + "a.txt";
         try
         {
            using StreamReader sr = new StreamReader(filePath);
            //Это позволяет вам выполнить одну операцию чтения
            Console.WriteLine(sr.ReadToEnd());
         }
         catch (Exception e)
         {
            Console.WriteLine("Процесс завершился неудачей: {0}", e);
         }

         // Классический вариант чтения файла построчно
         StreamReader readerone = new StreamReader(filePath);
         string[] arrayone = new string[n];
         int k = 0;
         while (!readerone.EndOfStream)
         {
            string stroka = readerone.ReadLine();
            arrayone[k] = stroka;
            Console.WriteLine(stroka);
            k++;
         }
         Console.WriteLine();
         // Разделение строки на подстроки и конвертация подстрок в double
         int z = 0;
         while (z < arrayone.GetLength(0))
         {
            string[] arraysplit = arrayone[z].Split(" ");
            int x = 0;
            while (x < arraysplit.GetLength(0))
            {
               arrayForFileSize[z, x] = Convert.ToDouble(arraysplit[x]);
               Console.Write(arrayForFileSize[z, x] + " ");
               x++;
            }
            Console.WriteLine();
            z++;
         }
         readerone.Close();
         Console.WriteLine();

         FileStream fpA = File.Open(filePath, FileMode.Open, FileAccess.Read);
         if (fpA == null)
         {
            Console.WriteLine("Ошибка при открытии файла для чтения");
         }
         // Cвязываем StreamReader c файловыйм потоком
         if (fpA != null)
         {
            StreamReader readerfour = new StreamReader(fpA);
            for (int i = 0; i < n; i++)
            {
               // Метод ReadLine() считает одну строку и перенесет указатель на начало следующей строки
               string singleLine = readerfour.ReadLine();
               Console.WriteLine(singleLine);
            }
            // Закрытие потока
            readerfour.Close();
         }
         Console.WriteLine();

         // Конвертируем массив строк
         string[,] txtNum = { { "21,5", "123,1", "87,8" }, { "54,3", "2,7", "0,8" }, { "0,3", "7,9", "4,5" } };
         double[,] number = new double[txtNum.GetLength(0), txtNum.GetLength(1)];
         for (int i = 0; i < txtNum.GetLength(0); i++)
         {
            for (int j = 0; j < txtNum.GetLength(1); j++)
            {
               number[i, j] = Convert.ToDouble(txtNum[i, j]);
               Console.Write(number[i, j] + " ");
            }
            Console.WriteLine();
         }
         Console.WriteLine();

         Console.ReadKey();
      }
   }
}