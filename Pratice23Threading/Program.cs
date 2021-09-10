using System;
using System.Threading;
namespace Pratice23Threading
{
    class Program
    {
        public static void FunctionCall1()
        {

            try
            {
                Thread.Sleep(Timeout.Infinite);
            }
            catch (ThreadInterruptedException )
            {
                Console.WriteLine("cannot sleep, interrupted by main()");
            }
            finally
            {

                for (int i = 1; i <= 10; i++)
                {
                    Console.WriteLine(i);
                }
            }
        }

        public static void FunctionCall2()
        {
            Console.WriteLine("=========Child begins here======");

            for (int i = 11; i <= 20; i++)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("============ Child Ends here=======");
        }

        static void Main(string[] args)
        {
            {
                Console.WriteLine("======== Main begins here========");
                Thread th = Thread.CurrentThread;
                th.Name = "Main Thread";
                Console.WriteLine("Current Thread {0}", th.Name);

                // object of thread 
                Console.WriteLine("====Main calling child thread=====");

                ThreadStart ts1 = new ThreadStart(FunctionCall1);
                Thread t1 = new Thread(ts1);
                t1.Start();                 // runnable mode
                t1.Interrupt();      //main thread is interrupting the thread which is sleeping infinitely

                ThreadStart ts2 = new ThreadStart(FunctionCall2);
                Thread t2 = new Thread(ts2);
                t2.Start();



                Console.WriteLine("======== Main Loaded completely====");

            }

        }
    }
}
