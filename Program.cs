using System;
using System.Collections.Generic;
using System.IO;

namespace CodeExperiment
{
   internal class Program
   {
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

               Console.ResetColor();
               string[] arrayOne = new string[listOne.Count];
               double[,] arrayTwo = new double[arrayOne.GetLength(0), max];
               int h = 0;
               while (h < listOne.Count)
               {
                  arrayOne[h] = listOne[h];
                  Console.WriteLine(arrayOne[h]);
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

                  Console.WriteLine();
                  z++;
               }

               string s = "1,5 5,6 9,8 2,1 5,8 9,1 7,3 4,2 2,9 1,7";
               char charRange = ' ';
               List<int> whiteSpace = new List<int>();
               const int dr = 0;
               whiteSpace.Add(dr);
               for (int i = 1; i < s.Length; i++)
               {
                  if (charRange.Equals(s[i]))
                  {
                     whiteSpace.Add(i);
                     //Console.WriteLine("Индекс: {0}", i);
                  }
               }

               foreach (int c in whiteSpace)
               {
                  Console.WriteLine("Индекс: {0}", c);
               }

               Console.WriteLine("Количество пробелов {0}", whiteSpace.Count);
               Console.WriteLine();

               int startIndex = 0;
               string[] arr = new string[whiteSpace.Count];
               for (int i = 0; i < whiteSpace.Count; i++)
               {
                  arr[i] = s.Substring(startIndex, whiteSpace[i] - startIndex);
                  startIndex = whiteSpace[i];

                  Console.WriteLine("Substring: {0}", arr[i]);
               }

               // Метод String.IndexOf(char, int, int)
               string br1 = "0----+----1----+----2----+----3----+----4----+----5----+----6----+----7";
               string br2 = "01234567890123456789012345678901234567890123456789012345678901234567890";
               string str = "ABCDEFGHI abcdefghi ABCDEFGHI abcdefghi ABCDEFGHI abcdefghi ABCDEFGHI";

               Console.WriteLine("Метод String.IndexOf(char, int, int) генерирует следующий результат");
               Console.WriteLine("{0}{1}{0}{2}{0}{3}{0}", Environment.NewLine, br1, br2, str);
               FindAllChar('A', str);
               FindAllChar('a', str);
               FindAllChar('I', str);
               FindAllChar('i', str);
               FindAllChar('@', str);
               FindAllChar(' ', str);
            }
         }
         catch (Exception e)
         {
            Console.WriteLine("Процесс завершился неудачей: {0}", e);
         }

         Console.WriteLine();
         Console.ReadKey();
      }
      static void FindAllChar(char target, string searched)
      {
         Console.Write("Символ '{0}' встречается в позиции(ах): ", target);

         int startIndex = -1;
         int hitCount = 0;

         // Выполните поиск по всем появлениям объекта.
         while (true)
         {
            startIndex = searched.IndexOf(
               target, startIndex + 1,
               searched.Length - startIndex - 1);

            // Выйдите из цикла, если цель не найдена.
            if (startIndex < 0)
               break;

            Console.Write("{0}, ", startIndex);
            hitCount++;
         }

         Console.WriteLine("проявление: {0}", hitCount);
      }


   }
}