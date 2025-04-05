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

               string[] pairs = { "Color1=red", "Color2=green", "Color3=blue", "Title=Code Repository" };
               foreach (string pair in pairs)
               {
                  int position = pair.IndexOf("=", StringComparison.Ordinal);
                  if (position < 0)
                  {
                     continue;
                  }

                  Console.WriteLine("Key: {0}, Value: '{1}'", pair.Substring(0, position), pair.Substring(position + 1));
               }

               string s = "aaaaabbbcccccccdd";
               char charRange = 'b';
               int startIndex = s.IndexOf(charRange);
               int endIndex = s.LastIndexOf(charRange);
               int length = endIndex - startIndex + 1;
               Console.WriteLine("{0}.Substring({1}, {2}) = {3}", s, startIndex, length, s.Substring(startIndex, length));

               string text2 = "(Hello World!)";
               int startChar = text2.IndexOf('(') + 1;
               int endChar = text2.IndexOf(')');
               string sub2 = text2.Substring(startChar, endChar - startChar);
               Console.WriteLine(sub2);

               string text3 = "C# Programmers are awesome!";
               int empStartIndex = text3.IndexOf("are", StringComparison.Ordinal) + 4;
               int empLength = text3.Length - empStartIndex;
               string sub3 = text3.Substring(empStartIndex, empLength);
               Console.WriteLine(sub3);

               string[] info = { "Name: Felica Walker", "Title: Mz.",
                  "Age: 47", "Location: Paris", "Gender: F"};
               int found = 0;

               Console.WriteLine("The initial values in the array are:");
               foreach (string s1 in info)
                  Console.WriteLine(s1);

               Console.WriteLine("\nWe want to retrieve only the key information. That is:");
               foreach (string s2 in info)
               {
                  found = s2.IndexOf(": ", StringComparison.Ordinal);
                  Console.WriteLine("   {0}", s2.Substring(found + 2));
               }

               // The example displays the following output:
               //       The initial values in the array are:
               //       Name: Felica Walker
               //       Title: Mz.
               //       Age: 47
               //       Location: Paris
               //       Gender: F
               //       
               //       We want to retrieve only the key information. That is:
               //          Felica Walker
               //          Mz.
               //          47
               //          Paris
               //          F
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