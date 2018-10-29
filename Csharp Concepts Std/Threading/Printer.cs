using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Csharp_Concepts_Std.Threading
{
    public class Printer
    {

        private readonly object threadLock = new object();

        public void PrintNumbers()
        {
            // Display Thread info.
            Console.WriteLine("-> {0} is executing PrintNumbers()",
            Thread.CurrentThread.Name);
            
            // Print out numbers.
            Console.Write("Your numbers: ");

            for (int i = 0; i < 10; i++)
            {
                Console.Write("{0} , ", i);
                Thread.Sleep(2000);
            }

            Console.WriteLine();
        }

        public void PrintNumbersConcurrency()
        {
            // Display Thread info.
            Console.WriteLine("-> {0} is executing PrintNumbers()",
            Thread.CurrentThread.Name);

            for (int i = 0; i < 10; i++)
            {
                Random r = new Random();
                Thread.Sleep(1000 * r.Next(5));

                Console.Write("{0} , ", i);
            }

            Console.WriteLine();
        }

        public void PrintNumbersLock()
        {
            //lock (this)
            lock(threadLock)
            {
                // Display Thread info.
                Console.WriteLine("-> {0} is executing PrintNumbers()",
                Thread.CurrentThread.Name);

                for (int i = 0; i < 10; i++)
                {
                    Random r = new Random();
                    Thread.Sleep(1000 * r.Next(5));

                    Console.Write("{0} , ", i);
                }

                Console.WriteLine();
            }
        }

        public void PrintNumbersWithMonitor()
        {
            Monitor.Enter(threadLock);
            try
            {
                // Display Thread info.
                Console.WriteLine("-> {0} is executing PrintNumbers()",
                Thread.CurrentThread.Name);
                // Print out numbers.
                Console.Write("Your numbers: ");
                for (int i = 0; i < 10; i++)
                {
                    Random r = new Random();
                    Thread.Sleep(1000 * r.Next(5));
                    Console.Write("{0}, ", i);
                }
                Console.WriteLine();
            }
            finally
            {
                Monitor.Exit(threadLock);
            }
        }
    }
}
