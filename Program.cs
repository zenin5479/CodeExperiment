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
         string filePath = AppContext.BaseDirectory + "a.txt";
         double[,] arrayForFileSize = new double[n, m];

         // Классический вариант чтения файла построчно
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
               StreamReader readerone = new StreamReader(filePath);
               while (!readerone.EndOfStream)
               {
                  Console.WriteLine(readerone.ReadLine());
               }
               // Закрытие потока
               readerone.Close();

               string[] arrayone = new string[n];

               Console.WriteLine();
               // Разделение строки на подстроки и конвертация подстрок в double
               int c = 0;
               while (c < arrayone.GetLength(0))
               {
                  string[] arraysplit = arrayone[c].Split(" ");
                  int x = 0;
                  while (x < arraysplit.GetLength(0))
                  {
                     arrayForFileSize[c, x] = Convert.ToDouble(arraysplit[x]);
                     Console.Write(arrayForFileSize[c, x] + " ");
                     x++;
                  }
                  Console.WriteLine();
                  c++;
               }
               Console.WriteLine();
            }

            Console.WriteLine();
         }
         catch (Exception e)
         {
            Console.WriteLine("Процесс завершился неудачей {0}", e);
         }

         // Для создания списка списков необходимо создать отдельные списки
         // и использовать List<T>.Add(T) для добавления их в основной список
         List<List<string>> itemBag = new List<List<string>>();
         List<string> weapons = new List<string> { "Меч", "Кинжал", "Арбалет" };
         itemBag.Add(weapons);
         List<string> potions = new List<string> { "Зелье здоровья", "Зелье силы", "Зелье удачи" };
         itemBag.Add(potions);
         int z = 0;
         Console.WriteLine("Количество листов {0}", itemBag.Count);
         while (z < itemBag.Count)
         {
            Console.WriteLine("Лист {0}: количество элементов во вложенном листе {1}", z, itemBag[z].Count);
            int x = 0;
            while (x < itemBag[z].Count)
            {
               Console.Write("{0} ", itemBag[z][x]);
               x++;
            }
            Console.WriteLine();
            z++;
         }
         Console.WriteLine();

         Console.ReadKey();
      }
   }
}