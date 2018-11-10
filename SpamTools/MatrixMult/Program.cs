using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MatrixMult
{
    class Program
    {
        const int rows = 100;
        const int columns = 100;
        static string folderName = "d:/temp/test/"; //folder name for files manipulations
        static bool rwlock = true; //define locker
        static Random rnd = new Random();

        //Matrices multiplication module
        static void Main(string[] args)
        {
            int[,] matrix1 = NewMatrix(rows, columns);
            int[,] matrix2 = NewMatrix(rows, columns);
            int[,] result = MultiplyMatrices(matrix1, matrix2);
            //PrintMatrix(result);

            ReadAndProcessFiles();
            Console.Read();
        }

        //create a matrix with defined size and fill it
        public static int[,] NewMatrix(int rows, int columns)
        {
            int[,] matrix = new int[rows, columns];
            int randomNumber;
            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < columns; j++)
                {
                    randomNumber = rnd.Next(1, 10);
                    matrix[i, j] = randomNumber;
                }
            }
            return matrix;
        }

        //matrix printing
        public static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write("{0} ", matrix[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("--------------------------");
        }

        //matrix multiplication using parallel for loop
        public static int[,] MultiplyMatrices(int[,] matrix1, int[,] matrix2)
        {
            int[,] result = NewMatrix(rows, columns);
            Parallel.For(0, rows, i =>
                {
                    for (int j = 0; j < columns; ++j)
                        for (int k = 0; k < rows; ++k)
                            result[i, j] += matrix1[i, k] * matrix2[k, j];
                }
                );
            return result;
        }

        public static void ReadAndProcessFiles()
        {
            if (!Directory.Exists(folderName))
            {
                Console.WriteLine("The directory does not exist.");
                return;
            }

            String[] files = Directory.GetFiles(folderName);
            double result = 0;
            Parallel.For(0, files.Length,
                   i =>
                   {
                       var fileContent = File.ReadAllText(files[i]);
                       var data = fileContent.Split((string[])null, StringSplitOptions.RemoveEmptyEntries);
                       int caseSwitch = int.Parse(data[0]);
                       switch (caseSwitch)
                       {
                           case 1: //multiply
                               result = double.Parse(data[1]) * double.Parse(data[2]);
                               break;
                           case 2: //divide
                               result = double.Parse(data[1]) / double.Parse(data[2]);
                               break;
                           default:
                               break;
                       }
                       while (rwlock == false)
                       {
                           Thread.Sleep(100);
                       }
                       rwlock = false;
                       using (System.IO.StreamWriter file =new System.IO.StreamWriter("d:/temp/test/result.txt", true))
                           {
                               file.WriteLine(result.ToString());
                           }
                       rwlock = true;
                       Console.WriteLine(result.ToString());
                       //FileInfo fi = new FileInfo(files[i]);
                       //Console.WriteLine(fi.Name);
                   });

        }
    }
}
