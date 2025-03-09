using System;
using System.Collections.Generic;
using System.IO;

namespace CodeExperiment
{
   internal class Program
   {
      static void Main()
      {
         int n = 3;
         int m = 3;

         double[,] a = new double[n, m];

         string path = AppContext.BaseDirectory;
         string filePath = path + "a.txt";

         // Классический вариант чтения файла построчно
         StreamReader f = new StreamReader(filePath);
         while (!f.EndOfStream)
         {
            string s = f.ReadLine();
            Console.WriteLine(s);
         }
         f.Close();
         Console.WriteLine();

         // Еще один пример, как можно организовать цикл построчного чтения
         string r;
         StreamReader t = new StreamReader(filePath);
         while ((r = t.ReadLine()) != null)
         {
            Console.WriteLine(r);
         }
         t.Close();
         Console.WriteLine();

         // Прочитать весь файл целиком в массив строк
         string[] lines = File.ReadAllLines(filePath);
         foreach (string s in lines)
         {
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
            StreamReader stream = new StreamReader(fpA);
            for (int i = 0; i < n; i++)
            {
               // Метод ReadLine() считает одну строку и перенесет указатель на начало следующей строки
               string singleLine = stream.ReadLine();
               Console.WriteLine(singleLine);
            }
            // Закрытие потока
            stream.Close();
         }
         Console.WriteLine();

         // Создаем новый список
         List<string> linesone = new List<string>();
         // Используем ключевое слово using для удаления
         using (StreamReader reader = new StreamReader(filePath))
         {
            // Используем шаблон while not null в цикле while
            string lineone;
            while ((lineone = reader.ReadLine()) != null)
            {
               // Переменная line - это строка в файле добавляем её в список
               linesone.Add(lineone);
            }
         }
         // Распечатываем все строки в списке
         foreach (string value in linesone)
         {
            Console.WriteLine(value);
         }
         Console.WriteLine();

         IEnumerable<string> linestwo = File.ReadLines("a.txt");
         Console.WriteLine(string.Join(Environment.NewLine, linestwo));
         Console.WriteLine();

         foreach (string linetwo in File.ReadLines("a.txt"))
         {
            Console.WriteLine(linetwo);
         }
         Console.WriteLine();

         // Обрабатывает все строки файла
         using (TextReader reader = File.OpenText("a.txt"))
         {
            string linethree;
            while ((linethree = reader.ReadLine()) != null)
            {
               string[] bitsthree = linethree.Split(' ');
               foreach (string bitthree in bitsthree)
               {
                  double value;
                  if (!double.TryParse(bitthree, out value))
                  {
                     Console.WriteLine("Неудовлетворительное значение");
                  }
                  else
                  {
                     Console.Write(bitthree + " ");
                  }
               }
               Console.WriteLine();
            }
         }
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
         using (StreamReader sr = new StreamReader("a.txt"))
         {
            string num = sr.ReadLine();
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
         Console.WriteLine();

         string textFilePath = "a.txt";
         using (StreamReader reader = new StreamReader(textFilePath))
         {
            string line1;
            while ((line1 = reader.ReadLine()) != null)
            {
               if (double.TryParse(line1, out double doubleValue))
               {
                  Console.WriteLine(doubleValue);
               }
               else
               {
                  Console.WriteLine($"Недопустимое значение double: {line1}");
               }
            }
         }
         Console.WriteLine();

         string textFilePath2 = "a.txt";
         using (StreamReader reader2 = new StreamReader(textFilePath2))
         {
            string line2;
            while ((line2 = reader2.ReadLine()) != null)
            {
               try
               {
                  double doubleValue2 = double.Parse(line2);
                  Console.WriteLine(doubleValue2);
               }
               catch (FormatException)
               {
                  Console.WriteLine($"Недопустимый формат double: {line2}");
               }
            }
         }
         Console.WriteLine();

         Console.ReadKey();
      }
   }
}