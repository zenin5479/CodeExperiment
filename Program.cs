using System;

namespace CodeExperiment
{
   internal class Program
   {
      static void Main()
      {
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

         Console.WriteLine(number[0, 0]);
         Console.WriteLine(number[1, 1]);
         Console.WriteLine(number[2, 2]);

         Console.ReadKey();
      }
   }
}