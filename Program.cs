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
            StreamReader readerone = new StreamReader(filePath);
            while (!readerone.EndOfStream)
            {
               Console.WriteLine(readerone.ReadLine());
            }

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
            readerone.Close();
            Console.WriteLine();
         }
         catch (Exception e)
         {
            Console.WriteLine("Процесс завершился неудачей {0}", e);
         }

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

         // Для создания списка списков необходимо создать отдельные списки
         // и использовать List<T>.Add(T) для добавления их в основной список
         List<List<string>> listOfListsOne = new List<List<string>>();
         List<string> languageOne = new List<string> { "C", "C++", "C#" };
         List<string> autoOne = new List<string> { "Volvo", "Audi", "BMW" };
         listOfListsOne.Add(languageOne);
         listOfListsOne.Add(autoOne);
         for (int i = 0; i < listOfListsOne.Count; i++)
         {
            Console.WriteLine("Лист {0}", i);
            List<string> list = listOfListsOne[i];
            // Метод String.Join объединяет элементы массива или коллекции,
            // используя указанный разделитель между каждым элементом
            Console.WriteLine(string.Join(", ", list));
         }
         Console.WriteLine();

         // Эквивалентно
         List<List<string>> itemBag = new List<List<string>>();
         List<string> weapons = new List<string> { "Меч", "Кинжал", "Арбалет" };
         itemBag.Add(weapons);
         List<string> potions = new List<string> { "Зелье здоровья", "Зелье силы", "Зелье удачи" };
         itemBag.Add(potions);
         for (int i = 0; i < itemBag.Count; i++)
         {
            Console.WriteLine("Лист {0}", i);
            for (int j = 0; j < itemBag[i].Count; j++)
            {
               Console.Write("{0} ", itemBag[i][j]);
            }
            Console.WriteLine();
         }
         Console.WriteLine();

         //
         List<List<string>> mylist = new List<List<string>>
         {
                new List<string> { "Один", "Два" },
                new List<string> { "Три", "Четыре", "Пять" },
                new List<string> { "Шесть", "Семь", "Восемь" },
                new List<string> { "Девять", "Десять" }
         };

         for (int i = 0; i < mylist.Count; i++)
         {
            Console.WriteLine("Лист {0}", i);
            for (int j = 0; j < mylist[i].Count; j++)
            {
               Console.Write("{0} ", mylist[i][j]);
            }
            Console.WriteLine();
         }
         Console.WriteLine();

         int z = 0;
         Console.WriteLine("Количество листов {0}", mylist.Count);
         while (z < mylist.Count)
         {
            Console.WriteLine("Лист {0}: количество элементов во вложенном листе {1}", z, mylist[z].Count);
            int x = 0;
            while (x < mylist[z].Count)
            {
               Console.Write("{0} ", mylist[z][x]);
               x++;
            }
            Console.WriteLine();
            z++;
         }
         Console.WriteLine();

         //
         try
         {
            // За одну операцию выполняется чтение файла вплоть до конца
            using StreamReader sr = new StreamReader(filePath);
            Console.WriteLine(sr.ReadToEnd());
            Console.WriteLine();
         }
         catch (Exception e)
         {
            Console.WriteLine("Процесс завершился неудачей {0}", e);
         }

         Console.ReadKey();
      }
   }
}