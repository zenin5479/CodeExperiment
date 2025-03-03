using System;
using System.IO;

namespace CodeExperiment
{
   internal class Program
   {
      static void Main()
      {
         //string[,] txtNum = { { "21,5", "123,1", "87,8" }, { "54,3", "2,7", "0,8" }, { "0,3", "7,9", "4,5" } };
         //double[,] number = new double[txtNum.GetLength(0), txtNum.GetLength(1)];
         //for (int i = 0; i < txtNum.GetLength(0); i++)
         //{
         //   for (int j = 0; j < txtNum.GetLength(1); j++)
         //   {
         //      number[i, j] = Convert.ToDouble(txtNum[i, j]);
         //      Console.Write(number[i, j] + " ");
         //   }

         //   Console.WriteLine();
         //}

         //Console.WriteLine("Диагональ массива");
         //Console.WriteLine(number[0, 0]);
         //Console.WriteLine(number[1, 1]);
         //Console.WriteLine(number[2, 2]);


         using (StreamReader sr = new StreamReader("a.txt"))
         {
            string num = sr.ReadLine();
            if (num != null)
               foreach (string number in num.Split())
               {
                  Console.WriteLine(number);
               }
         }


         using (FileStream fs = new FileStream("a.txt", FileMode.Open, FileAccess.Read))
         {
            using (BinaryReader r = new BinaryReader(fs))
            {
               for (int i = 0; i < 10; i++)
               {
                  Console.WriteLine(r.ReadInt32());
               }
            }
         }


         //string textFilePath = "a.txt";

         //// Read double values from the text file
         //using (StreamReader reader = new StreamReader(textFilePath))
         //{
         //   string line;
         //   while ((line = reader.ReadLine()) != null)
         //   {
         //      // Convert the read string to a double
         //      if (double.TryParse(line, out double doubleValue))
         //      {
         //         // Process the double value
         //         Console.WriteLine(doubleValue);
         //      }
         //      else
         //      {
         //         Console.WriteLine($"Invalid double value: {line}");
         //      }
         //   }
         //}


         // Specify the path to the text file
         string textFilePath = "a.txt";

         // Read and parse double values from the text file
         using (StreamReader reader = new StreamReader(textFilePath))
         {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
               try
               {
                  // Parse the line as a double
                  double doubleValue = double.Parse(line);

                  // Process the double value
                  Console.WriteLine(doubleValue);
               }
               catch (FormatException)
               {
                  Console.WriteLine($"Invalid double format: {line}");
               }
            }
         }


         Console.ReadKey();
      }
   }
}