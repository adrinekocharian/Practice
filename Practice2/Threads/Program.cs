using System;
using System.Threading;
using System.Threading.Tasks;

namespace Threads
{
    class Program
    {
        static void Main(string[] args)
        {            
            ThreadPool.GetAvailableThreads(out int availWorkerThreads, out int cThreads);
            ThreadPool.GetMinThreads(out int minWorkerThreads, out int cminThreads);
            ThreadPool.GetMaxThreads(out int maxWorkerThreads, out int cmaxThreads);
            Console.WriteLine($"GetAvailableThreads {availWorkerThreads} {cThreads}");
            Console.WriteLine($"GetMinThreads {minWorkerThreads} {cminThreads}");
            Console.WriteLine($"GetMaxThreads {maxWorkerThreads} {cmaxThreads}");

            FileProcessing fp = new FileProcessing();
            fp.ReadFile("numbers.txt");
            //fp.ProcessFile();
            fp.PrintNumbersFreq();

            string text = "t1";
            Thread t1 = new Thread(() => Console.WriteLine(text));
            t1.Priority = ThreadPriority.Normal;
            t1.Start();
            Thread.Sleep(200);
            
            text = "t2";
            Thread t2 = new Thread(() => Console.WriteLine(text));

            t2.Start();

            for (int i = 0; i < 10; i++)
            {
                Thread thread = new Thread(() => Console.Write(i));
                thread.Start();
                thread.Join();
                int temp = i;
                new Thread(() => Console.Write(temp)).Start();
            }

            Console.ReadLine();
            Console.WriteLine("Parallel foreach");

            Parallel.For(0, 10, (i) => { Console.Write(i); });

            Console.ReadLine();

            #region lock
            Counter counter = new Counter();
            Thread incThread = new Thread(() =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                    counter.Increment();
                }
            });

            Thread decThread = new Thread(() =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                    counter.Dencrement();
                }
            });

            incThread.Start();
            decThread.Start();
            incThread.Join();
            decThread.Join();

            Console.WriteLine($"Count is {counter.GetCount()}");
            #endregion

            #region thread bascis
            //Console.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}] Main Thread");
            //Console.WriteLine("IsBackground: {0}", Thread.CurrentThread.IsBackground);
            //Thread anotherThread = new Thread(SomeMethod);
            //anotherThread.Start();
            //anotherThread.Join();

            //ThreadPool.QueueUserWorkItem(WorkItemMethod, 12);

            //Thread threadTwo = new Thread(Print);
            //threadTwo.Name = "Thread2";
            //threadTwo.Start("hello from thread two.");
            //threadTwo.IsBackground = true;
            ////threadTwo.Join();

            //Thread thirdThread = new Thread(
            //    (a) => 
            //    { 
            //        Console.WriteLine(a); 
            //    });
            //Thread thread4 = new Thread(_ => 
            //{ 
            //    Console.WriteLine("no args"); 
            //});
            //thread4.IsBackground = true;
            //thread4.Name = "Thread4";
            //thread4.Start();
            //thirdThread.Start("Hello from thread 3");

            //Console.WriteLine("Hello World from Main!");
            #endregion
            //Console.ReadLine();
        }

        private static void WorkItemMethod(object obj)
        {
            Thread.Sleep(5000);
            Console.WriteLine("passed data {0}", obj);
            Console.WriteLine("Hello from user work item");
        }

        private static void Print(object obj)
        {
            Thread.Sleep(5000);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(obj);
            //Thread.CurrentThread.Name = "Thread2_";
            Console.ResetColor();            
        }

        private static void SomeMethod()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}] another thread.");
            Console.WriteLine("Isbackground: {0}", Thread.CurrentThread.IsBackground);
            Console.WriteLine("Hello world from another thread.");
            Console.ResetColor();
        }
    }
}