using System;
using System.IO;
using System.Text;

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
               int total = (int)fpA.Length;
               string[] arrayone = new string[n];
               int k = 0;
               while (!readerone.EndOfStream)
               {
                  string stroka = readerone.ReadLine();
                  arrayone[k] = stroka;
                  Console.WriteLine(stroka);
                  k++;
               }
               readerone.Close();
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
               Console.WriteLine();
            }
         }
         catch (Exception e)
         {
            Console.WriteLine("Процесс завершился неудачей: {0}", e);
         }

         using FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
         int totalBytes = (int)stream.Length;
         byte[] bytes = new byte[totalBytes];
         int bytesRead = 0;
         while (bytesRead < totalBytes)
         {
            int len = stream.Read(bytes, bytesRead, totalBytes);
            bytesRead += len;
         }

         string text = Encoding.UTF8.GetString(bytes);
         Console.WriteLine(text);
         Console.WriteLine(string.Join(", ", text));

         Console.ReadKey();
      }
   }
}