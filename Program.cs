using System;
using System.IO;

namespace CodeExperiment
{
   internal class Program
   {
      static void Main()
      {
         //double[,] arrayDouble = 
         //{
         //   { 1, 2, 3, 4, 5, 6, 7, 8, 9, -10, 1, 2, 3, 4, 5, 6, 80, 8, 9, -10 },
         //   { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 1, 2, 3, 4, 5, 6, 81, 8, 9, 10 },
         //   { 1, 2, 3, 4, 5, 6, 7, 8, 9, -10, 1, 2, 3, 4, 5, 6, 82, 8, 9, -10 },
         //   { 1, 2, 3, 4, 5, 6, 7, 8, 9, -10, 1, 2, 3, 4, 5, 6, 83, 8, 9, -10 },
         //   { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 1, 2, 3, 4, 5, 6, 84, 8, 9, 10 },
         //   { 1, 2, 3, 4, 5, 6, 7, 8, 9, -10, 1, 2, 3, 4, 5, 6, 88, 8, 9, -10 },
         //   { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 1, 2, 3, 4, 5, 6, 86, 8, 9, 10 },
         //   { 1, 2, 3, 4, 5, 6, 7, 8, 9, -10, 1, 2, 3, 4, 5, 6, 87, 8, 9, -10 },
         //   { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 1, 2, 3, 4, 5, 6, 88, 8, 9, 10 },
         //   { 1, 2, 3, 4, 5, 6, 7, 8, 9, -10, 1, 2, 3, 4, 5, 6, 89, 8, 9, -10 },
         //};

         double[,] arrayDouble =
         {
            { 1.5, 5.6, 9.8, 2.1, 5.8, 9.1, 7.3, 4.2, 2.9, 1.7 },
            { 8.3, 5.3, 5.7, 3.6, 3.7, 9.4, 5.3, 7.5, 8.1, 8.1 },
            { 1.3, 3.6, 7.5, 8.8, 8.3, 4.8, 7.2, 5.1, 4.1, 9.7 },
            { 1, 2, 3, 4, 5, 6, 83, 8, 9, -10 },
            { 1, 2, 3, 4, 5, 6, 84, 8, 9, 10 },
            { 1, 2, 3, 4, 5, 6, 88, 8, 9, -10 },
            { 1, 2, 3, 4, 5, 6, 86, 8, 9, 10 },
            { 1, 2, 3, 4, 5, 6, 87, 8, 9, -10 },
            { 1, 2, 3, 4, 5, 6, 88, 8, 9, 10 },
            { 1, 2, 3, 4, 5, 6, 89, 8, 9, -10 },
         };

         //arrayDouble

         //string[,] arrayString = 

         //string filePath = AppContext.BaseDirectory + "с.txt";

         // Specifying a file 
         string path = "file.txt";

         // Creating some string array to 
         // write into the file 
         string[] createText = { "GFG", "is a", "CS portal." };

         // Calling WriteAllLines() function to write 
         // the specified string array into the file 
         File.WriteAllLines(path, createText);

         // Reading the file contents 
         string[] readText = File.ReadAllLines(path);
         foreach (string s in readText)
         {
            Console.WriteLine(s);
         }

         Console.ReadKey();
      }
   }
}