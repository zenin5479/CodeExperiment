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

         double[,] a = new double[n, m];

         string path = AppContext.BaseDirectory;
         string filePath = path + "a.txt";

         // Классический вариант чтения файла построчно
         StreamReader readertwo = new StreamReader(filePath);
         string[] listone = new string[n];
         int p = 0;
         while (!readertwo.EndOfStream && p < n)
         {
            string s = readertwo.ReadLine();
            listone[p] = s;
            Console.WriteLine(s);
            p++;
         }
         Console.WriteLine();

         // Разделение строки на прдстроки и конвертация подстрок в double
         for (int i = 0; i < listone.Length; i++)
         {
            string[] split = listone[i].Split(" ");
            for (int j = 0; j < split.Length; j++)
            {
               a[i, j] = Convert.ToDouble(split[j]);
               Console.Write(a[i, j] + " ");
            }
            Console.WriteLine();
         }
         readertwo.Close();
         Console.WriteLine();

         // Пример организации цикла построчного чтения
         string r;
         StreamReader readerthree = new StreamReader(filePath);
         while ((r = readerthree.ReadLine()) != null)
         {
            Console.WriteLine(r);
         }
         readerthree.Close();
         Console.WriteLine();

         // Прочитать весь файл целиком в массив строк
         string[] lines = File.ReadAllLines(filePath);
         for (int i = 0; i < lines.Length; i++)
         {
            string s = lines[i];
            Console.WriteLine(s);
         }
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

         // Создаем новый список
         List<string> linesone = new List<string>();
         // Используем ключевое слово using для удаления
         using (StreamReader readerfive = new StreamReader(filePath))
         {
            // Используем шаблон while not null в цикле while
            string lineone;
            while ((lineone = readerfive.ReadLine()) != null)
            {
               // Переменная line - это строка в файле добавляем её в список
               linesone.Add(lineone);
            }
         }
         // Распечатываем все строки в списке
         for (int i = 0; i < linesone.Count; i++)
         {
            string value = linesone[i];
            Console.WriteLine(value);
         }
         Console.WriteLine();

         List<string> linestwo = new List<string>(File.ReadLines(filePath));
         Console.WriteLine(string.Join(Environment.NewLine, linestwo));
         Console.WriteLine();

         // Конвертирует массив строк
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

         // Обрабатывает строку файла
         using (StreamReader readerseven = new StreamReader(filePath))
         {
            string num = readerseven.ReadLine();
            if (num != null)
            {
               string[] split = num.Split(" ");
               for (int i = 0; i < split.Length; i++)
               {
                  string numbers = split[i];
                  Console.Write(numbers + " ");
               }
            }
            Console.WriteLine();
         }
         //Console.WriteLine();

         Console.ReadKey();
      }
   }
}