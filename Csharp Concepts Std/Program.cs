using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Csharp_Concepts_Std.MemberShadowing;
using Csharp_Concepts_Std.Threading;
using Csharp_Concepts_Std.ValueReferenceType;

namespace Csharp_Concepts_Std
{
    // Asyc nature of delegates
    public delegate int BinaryOp(int a, int b);

    class Program
    {
        // Using The AutoResetEvent Class for Thread suspension
        private static AutoResetEvent waitHandler = new AutoResetEvent(false);

        static void Main(string[] args)
        {
            #region System.Environment class
            //ShowEnvironmentDetails();
            #endregion

            #region Value Types, References Types, and the Assignment Operator

            #region Value Types containing Reference Types
            //ValTypesContainingRefTypes();
            #endregion

            #region Passing Reference Types by Reference
            // Passing ref-types by ref.
            PassingRefTypesAsRefTypes();
            #endregion

            #endregion

            #region MemberShadowing

            //ThreeDCircle obj3DCircle = new ThreeDCircle();
            //obj3DCircle.Draw();
            //((Circle)obj3DCircle).Draw();

            #endregion

            #region Asyc nature of delegates
            //AsyncNatureOfDelegates();
            #endregion

            #region System.Threading : Threading Stats
            //ThreadingStats();
            #endregion

            #region System.Threading with steps
            //1.Create a method to be the entry point for the new thread.
            //2.Create a new ParameterizedThreadStart(or ThreadStart) delegate, 
            //passing the address of the method defined in step 1 to the constructor.
            //3.Create a Thread object, passing the ParameterizedThreadStart / ThreadStart
            //delegate as a constructor argument.
            //4.Establish any initial thread characteristics(name, priority, etc.).
            //5.Call the Thread.Start() method.This starts the thread at the method
            //referenced by the delegate created in step 2 as soon as possible.

            #region Using ThreadStart delegate
            //UsingThreadStartDelegate();
            #endregion

            #region Using ParameterizedThreadStart delegate
            //UsingParameterizedThreadStartDelegate();
            #endregion

            #region Using The AutoResetEvent Class for Thread suspension
            //UsingAutoResetEventClassForThreadSuspension();
            #endregion

            #region Create concurrency and then solve concurrency using lock keyword and Monitor type
            //Concurrency();
            #endregion

            #endregion

            #region Task Parallel Library
            // The TPL handles the partitioning of the work, thread
            // scheduling, state management, and other low-level details.
            // TPL will automatically distribute your application’s workload across 
            // available CPUs dynamically, using the CLR thread pool.

            #endregion

            Console.ReadLine();
        }

        private static void PassingRefTypesAsRefTypes()
        {
            Console.WriteLine("***** Passing Person object by reference *****");
            Person mel = new Person("Mel", 23);
            Console.WriteLine("Before by ref call, Person is:");
            mel.Display();
            SendAPersonByReference(ref mel);
            Console.WriteLine("After by ref call, Person is:");
            mel.Display();
        }


        // System.Environment class
        private static void ShowEnvironmentDetails()
        {
            // Print out the drives on this machine,
            // and other interesting details.
            foreach (string drive in Environment.GetLogicalDrives())
                Console.WriteLine("Drive: {0}", drive);
            Console.WriteLine("OS: {0}", Environment.OSVersion);
            Console.WriteLine("Number of processors: {0}",
            Environment.ProcessorCount);
            Console.WriteLine(".NET Version: {0}",
            Environment.Version);
        }

        // Value Types containing Reference Types
        private static void ValTypesContainingRefTypes()
        {
            // Create the first Rectangle.
            Console.WriteLine("-> Creating r1");
            Rectangle r1 = new Rectangle("First Rect", 10, 10, 50, 50);
            // Now assign a new Rectangle to r1.
            Console.WriteLine("-> Assigning r2 to r1");
            Rectangle r2 = r1;
            // Change some values of r2.
            Console.WriteLine("-> Changing values of r2");
            r2.rectInfo.infoString = "This is new Rect";
            r2.rectBottom = 4444;
            // Print values of both rectangles.
            r1.Display();
            r2.Display();
        }

        // 
        private static void SendAPersonByReference(ref Person p)
        {
            // Change some data of "p".
            p.Age = 555;
            // "p" is now pointing to a new object on the heap!
            p = new Person("Nikki", 999);
        }


        // Create concurrency and then solve concurrency using lock keyword and Monitor type
        private static void Concurrency()
        {
            Console.WriteLine("*****Concurrency & Synchronizing Threads *****\n");
            Threading.Printer p = new Threading.Printer();

            // Make 10 threads that are all pointing to the same
            // method on the same object.
            Thread[] threads = new Thread[10];
            for (int i = 0; i < 10; i++)
            {
                //threads[i] = new Thread(new ThreadStart(p.PrintNumbersConcurrency));  // Creates concurrency issues.
                //threads[i] = new Thread(new ThreadStart(p.PrintNumbersLock));         // Locks the shared resource using lock keyword.
                threads[i] = new Thread(new ThreadStart(p.PrintNumbersWithMonitor));    // Locks the shared resource using Monitor type which offers 
                                                                                        // more control. Check MS SDK documentation for more.
                threads[i].Name = string.Format("Worker thread #{0}", i);
            }


            // Now start each one.
            foreach (Thread t in threads)
                t.Start();
        }

        // Using The AutoResetEvent Class for Thread suspension
        private static void UsingAutoResetEventClassForThreadSuspension()
        {
            Console.WriteLine("***** Adding with Thread objects *****");
            Console.WriteLine("ID of thread in Main(): {0}",
            Thread.CurrentThread.ManagedThreadId);

            // Make an AddParams object to pass to the secondary thread.
            Threading.AddParams ap = new Threading.AddParams(10, 10);
            Thread t = new Thread(new ParameterizedThreadStart(Add));
            t.Start(ap);

            // Force a wait to let other thread finish.
            Console.WriteLine("Main Thread Sleeps.");
            //Thread.Sleep(5000);
            waitHandler.WaitOne();
            Console.WriteLine("Main Thread Resumes.");
        }

        // Using ParameterizedThreadStart delegate
        private static void UsingParameterizedThreadStartDelegate()
        {
            Console.WriteLine("***** Adding with Thread objects *****");
            Console.WriteLine("ID of thread in Main(): {0}",
            Thread.CurrentThread.ManagedThreadId);

            // Make an AddParams object to pass to the secondary thread.
            Threading.AddParams ap = new Threading.AddParams(10, 10);
            Thread t = new Thread(new ParameterizedThreadStart(Add));
            t.Start(ap);

            // Force a wait to let other thread finish.
            Console.WriteLine("Main Thread Sleeps.");
            Thread.Sleep(5000);
            Console.WriteLine("Main Thread Resumes.");
        }

        // Using ParameterizedThreadStart delegate
        private  static void Add(object data)
        {
            if (data is Threading.AddParams)
            {
                Console.WriteLine("ID of thread in Add(): {0}",
                Thread.CurrentThread.ManagedThreadId);

                Threading.AddParams ap = (Threading.AddParams)data;
                Console.WriteLine("{0} + {1} is {2}", ap.a, ap.b, ap.a + ap.b);

                // Tell other thread that this thread is done
                Console.WriteLine("This thread {0} is done.", Thread.CurrentThread.ManagedThreadId);
                waitHandler.Set();
            }
        }

        // Using ThreadStart delegate
        private static void UsingThreadStartDelegate()
        {
            Console.WriteLine("***** The Amazing Thread App *****\n");
            Console.Write("Do you want [1] or [2] threads? ");
            string threadCount = Console.ReadLine();

            // Name the current thread.
            Thread primaryThread = Thread.CurrentThread;
            primaryThread.Name = "Primary";

            // Display Thread info.
            Console.WriteLine("-> {0} is executing Main()",
            Thread.CurrentThread.Name);

            // Make worker class.
            Threading.Printer p = new Threading.Printer();

            switch (threadCount)
            {
                case "2":
                    // Now make the thread.
                    Thread backgroundThread = new Thread(new ThreadStart(p.PrintNumbers))
                    {
                        Name = "Secondary"
                    };
                    backgroundThread.Start();
                    break;
                case "1":
                    p.PrintNumbers();
                    break;
                default:
                    Console.WriteLine("I don't know what you want...you get 1 thread.");
                    goto case "1";
            }

            // Do some additional work.
            MessageBox.Show("I'm busy!", "Work on main thread...");
        }

        // System.Threading : Threading Stats
        private static void ThreadingStats()
        {
            Console.WriteLine("***** Primary Thread stats *****\n");

            // Obtain and name the current thread.
            Thread primaryThread = Thread.CurrentThread;
            primaryThread.Name = "ThePrimaryThread";

            // Show details of hosting AppDomain/Context.
            Console.WriteLine("Name of current AppDomain: {0}",
            Thread.GetDomain().FriendlyName);
            Console.WriteLine("ID of current Context: {0}",
            Thread.CurrentContext.ContextID);

            // Print out some stats about this thread.
            Console.WriteLine("Thread Name: {0}",
            primaryThread.Name);                          // Name is not set then returns empty string.
            Console.WriteLine("Has thread started?: {0}",
            primaryThread.IsAlive);
            Console.WriteLine("Priority Level: {0}",
            primaryThread.Priority);                      // We can set using System.Threading.ThreadPriority enumeration
            Console.WriteLine("Thread State: {0}",
            primaryThread.ThreadState);
        }

        // Asyc nature of delegates
        private static void AsyncNatureOfDelegates()
        {
            Console.WriteLine("***** Async Delegate Invocation *****");

            // Print out the ID of the executing thread.
            Console.WriteLine("Main() invoked on thread {0}.", Thread.CurrentThread.ManagedThreadId);

            // Invoke Add() on a secondary thread.
            BinaryOp b = new BinaryOp(Add);
            IAsyncResult iftAR = b.BeginInvoke(10, 10, null, null);

            //// Do other work on primary thread...
            //Console.WriteLine("Before Add : Doing more work in Main()!");

            // This message will keep printing until
            // the Add() method is finished.
            while (!iftAR.IsCompleted)
            {
                Console.WriteLine("Doing more work in Main()! while Add() is getting executed.");
                Thread.Sleep(1000);
            }

            // Obtain the result of the Add()
            // method when ready.
            int answer = b.EndInvoke(iftAR);
            Console.WriteLine("10 + 10 is {0}.", answer);

            // Do other work on primary thread...
            Console.WriteLine("After Add : Doing more work in Main()!");
        }

        // Asyc nature of delegates
        private static int Add(int x, int y)
        {
            // Print out the ID of the executing thread.
            Console.WriteLine("Add() invoked on thread {0}.", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(7000);

            return x + y;
        }

        

    }

    
}
