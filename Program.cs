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
               //Разделение строки на подстроки
               int g = 0;
               // Создаем List<string> для определения количество столбцов в файле
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
               Console.WriteLine();
               // Определяет, все ли элементы массива удовлетворяют условиям указанного предиката
               // public static bool TrueForAll<T> (T[] array, Predicate<T> match);
               bool value = Array.TrueForAll(checkinDimension, s => s.Equals(20));
               Console.WriteLine(value);
               bool trueForAll = Array.TrueForAll(checkinDimension, t => t.Equals(arraysplit.Count));
               Console.WriteLine(trueForAll);

               Console.WriteLine("Количество столбцов {0}", arraysplit.Count);

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

         List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
         // Использование Predicate<T> для поиска четных чисел
         Predicate<int> isEvenPredicate = IsEven;
         List<int> evenNumbers = numbers.FindAll(isEvenPredicate);

         Console.Write("Четные числа: ");
         foreach (int num in evenNumbers)
         {
            Console.Write("{0} ", num);
         }
         Console.WriteLine();

         // Использование Predicate<T> делегат принимает только один параметр
         Predicate<string> val = Myfun;
         Console.WriteLine(val("GeeksforGeeks"));

         Console.WriteLine();
         Console.ReadKey();
      }

      // Метод, соответствующий сигнатуре делегата Predicate<T> для поиска четных чисел
      public static bool IsEven(int value)
      {
         return value % 2 == 0;
      }

      // Метод
      public static bool Myfun(string mystring)
      {
         if (mystring.Length < 20)
         {
            return true;
         }

         return false;
      }
   }
}