using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CodeExperiment
{
   internal class Program
   {
      static void Main()
      {
         //string filePath = AppContext.BaseDirectory + "a.txt";
         string filePath = AppContext.BaseDirectory + "b.txt";
         Console.BackgroundColor = ConsoleColor.DarkBlue;
         FileStream fStream = File.Open(filePath, FileMode.Open, FileAccess.Read);
         if (fStream == null)
         {
            Console.WriteLine("Ошибка при открытии файла для чтения");
         }
         // Cвязываем StreamReader c файловыйм потоком
         if (fStream != null)
         {
            // Чтение файла построчно
            StreamReader readerOne = new StreamReader(fStream);
            // Создаем List<string> для определения количество строк в файле
            List<string> listOne = new List<string>();
            Console.WriteLine("Исходный массив строк");
            while (!readerOne.EndOfStream)
            {
               string stroka = readerOne.ReadLine();

               listOne.Add(stroka);
               Console.WriteLine(stroka);
            }

            readerOne.Close();
            fStream.Dispose();

            // Вариант 1 с помощью метода String.Split
            // Одномерный массив для определения количества столбцов в строке
            int[] arrayDimension = new int[listOne.Count];
            int a = 0;
            while (a < listOne.Count)
            {
               // Разделение строк на подстроки для определения количества столбцов в строке с помощью List<string>
               List<string> listSplit = new List<string>(listOne[a].Split(" "));
               arrayDimension[a] = listSplit.Count;
               //Console.WriteLine("В строке {0} количество столбцов {1}", d, arrayDimension[d]);
               a++;
            }

            // Проверка количества столбцов для определения размерности двухмерного массива (прямоугольный/зубчатый)
            int minOne = arrayDimension[0];
            int maxOne = arrayDimension[0];
            int b = 0;
            while (b < arrayDimension.Length)
            {
               if (arrayDimension[b] < minOne)
               {
                  minOne = arrayDimension[b];
               }

               if (arrayDimension[b] > maxOne)
               {
                  maxOne = arrayDimension[b];
               }

               b++;
            }

            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Количество строк {0}", listOne.Count);
            Console.WriteLine("Минимальное количество столбцов: {0}", minOne);
            Console.WriteLine("Максимальное количество столбцов: {0}", maxOne);
            if (minOne == maxOne)
            {
               Console.ForegroundColor = ConsoleColor.Green;
               Console.WriteLine("Массив имеет одинаковое количество столбцов - прямоугольный");
            }

            else
            {
               Console.ForegroundColor = ConsoleColor.Red;
               Console.WriteLine("Массив имеет разное количество столбцов - зубчатый");
            }

            //Console.WriteLine();

            string[] arrayOne = new string[listOne.Count];
            double[,] arrayTwo = new double[arrayOne.GetLength(0), maxOne];
            int c = 0;
            while (c < listOne.Count)
            {
               arrayOne[c] = listOne[c];
               //Console.WriteLine(arrayOne[h]);
               c++;
            }

            Console.WriteLine();
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.Magenta;
            // Разделение строки на подстроки и конвертация подстрок в double
            Console.WriteLine("Двухмерный числовой массив");
            int d = 0;
            while (d < arrayTwo.GetLength(0))
            {
               string[] arraySplit = arrayOne[d].Split(" ");
               int e = 0;
               while (e < arraySplit.GetLength(0))
               {
                  arrayTwo[d, e] = Convert.ToDouble(arraySplit[e]);
                  Console.Write(arrayTwo[d, e] + " ");
                  e++;
               }

               d++;
               Console.WriteLine();
            }

            Console.WriteLine();
            Console.ResetColor();
            Console.WriteLine("Последний элемент первой строки : {0}", arrayTwo[0, arrayTwo.GetLength(1) - 1]);
            Console.WriteLine();

            // Вариант 2 с помощью StringBuilder
            // Разделение строки на подстроки для определения количества столбцов в строке с помощью StringBuilder
            Console.ResetColor();
            StringBuilder stringModified = new StringBuilder();
            List<string> listColumns = new List<string>();
            int[] sizeArray = new int[listOne.Count];
            char spaceCharacter = ' ';
            int f = 0;
            int h = 0;
            while (h < listOne.Count)
            {
               string line = listOne[h];
               while (f < line.Length)
               {
                  if (spaceCharacter != line[f])
                  {
                     stringModified.Append(line[f]);
                  }
                  else
                  {
                     string subLine = stringModified.ToString();
                     listColumns.Add(subLine);
                     //Console.Write(subLine + " ");
                     stringModified.Clear();
                  }

                  if (f == line.Length - 1)
                  {
                     string subLine = stringModified.ToString();
                     listColumns.Add(subLine);
                     //Console.Write(subLine + " ");
                     stringModified.Clear();
                  }

                  f++;
               }

               //Console.WriteLine();

               sizeArray[h] = listColumns.Count;
               //Console.WriteLine("В строке {0} количество столбцов {1}", t, listColumns.Count);
               h++;
               f = 0;
               listColumns.Clear();
            }

            // Проверка количества столбцов для определения размерности двухмерного массива (прямоугольный/зубчатый)
            int minTwo = sizeArray[0];
            int maxTwo = sizeArray[0];
            int k = 0;
            while (k < sizeArray.Length)
            {
               if (sizeArray[k] < minTwo)
               {
                  minTwo = sizeArray[k];
               }

               if (sizeArray[k] > maxTwo)
               {
                  maxTwo = sizeArray[k];
               }

               k++;
            }

            Console.ResetColor();
            //Console.WriteLine();
            Console.WriteLine("Количество строк {0}", listOne.Count);
            Console.WriteLine("Минимальное количество столбцов: {0}", minTwo);
            Console.WriteLine("Максимальное количество столбцов: {0}", maxTwo);
            if (minTwo == maxTwo)
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
            Console.WriteLine();
            // Разделение строки на подстроки и конвертация подстрок в double
            Console.WriteLine("Двухмерный числовой массив");
            StringBuilder stringModifiedOne = new StringBuilder();
            double[,] arrayFour = new double[listOne.Count, maxTwo];
            char spaceCharacterOne = ' ';
            int vowels, consonants, others, punctuationmarks, sumAll, sumFour;
            vowels = 0;
            consonants = 0;
            others = 0;
            punctuationmarks = 0;
            sumAll = 0;
            int l = 0;
            int m = 0;
            int n = 0;
            while (l < arrayFour.GetLength(0))
            {
               string line = listOne[l];
               while (m < arrayFour.GetLength(1))
               {
                  sumAll++;
                  bool isVowel = false;
                  bool isConsonants = false;
                  bool isOthersCh = false;
                  while (n < line.Length)
                  {
                     if (spaceCharacterOne != line[n])
                     {
                        vowels++;
                        isVowel = true;
                     }

                     n++;
                  }

                  if (isVowel == false)
                  {
                     int p = 0;
                     while (p < line.Length)
                     {
                        //if (phrase[l] == consonantsCh[p])
                        //{
                        //   consonants++;
                        //   isConsonants = true;
                        //}

                        p++;
                     }
                  }

                  if (isVowel == false && isConsonants == false)
                  {
                     int r = 0;
                     while (r < line.Length)
                     {
                        //if (phrase[l] == othersCh[r])
                        //{
                        //   others++;
                        //   isOthersCh = true;
                        //}

                        r++;
                     }
                  }

                  if (isVowel == false && isConsonants == false && isOthersCh == false)
                  {
                     int s = 0;
                     while (s < line.Length)
                     {
                        //if (phrase[l] == punctuationMarksCh[s])
                        //{
                        //   punctuationmarks++;
                        //}
                        //s++;
                     }
                  }

                  l++;
               }
            }

            sumFour = vowels + consonants + others + punctuationmarks;
            Console.WriteLine("Количество гласных: {0}", vowels);
            Console.WriteLine("Количество coгласных: {0}", consonants);
            Console.WriteLine("Количество других знаков: {0}", others);
            Console.WriteLine("Количество знаков пунктуации: {0}", punctuationmarks);
            Console.WriteLine("Сумма гласных, согласных, других знаков и знаков пунктуации: {0}", sumFour);
            Console.WriteLine("Количество всех знаков: {0}", sumAll);
            //Console.ResetColor();

            Console.ReadKey();
            // Не присваивать лишние элементы массиву строки (первые 3 строки 10)
         }

         //Console.WriteLine("Двухмерный числовой массив");
         //StringBuilder stringModifiedOne = new StringBuilder();
         //double[,] arrayFour = new double[listOne.Count, maxTwo];
         //char spaceCharacterOne = ' ';
         //int l = 0;
         //int m = 0;
         //int n = 0;
         //while (l < arrayFour.GetLength(0))
         //{
         //   string line = listOne[l];
         //   while (m < arrayFour.GetLength(1))
         //   {
         //      while (n < line.Length)
         //      {
         //         if (spaceCharacterOne != line[n])
         //         {
         //            stringModifiedOne.Append(line[n]);
         //         }
         //         else
         //         {
         //            string subLineOne = stringModifiedOne.ToString();
         //            arrayFour[l, m] = Convert.ToDouble(subLineOne);
         //            Console.Write(arrayFour[l, m] + " ");
         //            stringModifiedOne.Clear();
         //            m++;
         //         }

         //         if (n == line.Length - 1)
         //         {
         //            string subLineOne = stringModifiedOne.ToString();
         //            arrayFour[l, m] = Convert.ToDouble(subLineOne);
         //            Console.Write(arrayFour[l, m] + " ");
         //            stringModifiedOne.Clear();
         //            m++;
         //         }

         //         n++;
         //      }

         //      n = 0;
         //   }

         //   Console.WriteLine();
         //   m = 0;
         //   l++;
         //}
      }
   }
}