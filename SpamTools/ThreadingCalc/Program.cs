using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Concurrent;

namespace ThreadingCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            int factorial = 0;
            int N = 0;
            Console.WriteLine("===== Suggested number is 50 for both methods =====");
            Console.WriteLine("Please, enter a number for factorial calculation:");
            Int32.TryParse(Console.ReadLine(), out factorial);

            var thread = new Thread(() => FactorialEntryPoint(factorial));
            thread.Start();

            Console.WriteLine("Meanwhile lets calculate summ of up to N numbers.");
            Console.WriteLine("Please, enter N:");
            Int32.TryParse(Console.ReadLine(), out N);

            var thread2 = new Thread(() => SummEntryPoint(N));
            thread2.Start();

            Console.WriteLine("Calculating and sleeping. Please, wait...");
            thread.Join();
            thread2.Join();

            Console.WriteLine("\nNow another task is started, namely reading/writing files.");
            ThreadPool.SetMaxThreads(1, 1);
            thread = new Thread(CSVReaderWriter.ReadCSVEntryPoint);
            thread.Start();

            //thread2 = new Thread(CSVReaderWriter.WriteCSVEntryPoint);
            //thread2.Start();
//            while (thread.ThreadState.ToString() != "Stopped")
//            {
                
//            }
            
            Console.WriteLine("Please, wait for the completion.");
            Console.ReadLine();
        }

        private static void FactorialEntryPoint(int factorial)
        {
            System.UInt64 result = 1;
            for (uint i = 1; i < factorial; i++)
            {
                result = result * i;
                Thread.Sleep(100);
            }
            Console.WriteLine("Calculated factorial is: {0}", result);
        }

        private static void SummEntryPoint(int n)
        {
            int result = 1;
            for (int i = 0; i <= n; i++)
            {
                result = result + i;
                Thread.Sleep(100);
            }
            Console.WriteLine("Calculated summ is: {0}", result);
        }
    }
}
