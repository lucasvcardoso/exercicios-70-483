using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Chapter1.ThreadClass
{
    /// <summary>
    /// An example of how to create a Thread using the Thread class
    /// </summary>
    class Example1_1
    {
        static void TMain(string[] args)
        {
            Thread t = new Thread(new ThreadStart(ThreadMethod));
            t.Start();

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Main Thread: Do some work.");
                //We use Thread.Sleep(0) to tell Windows that this Thread can be paused already, 
                //and another thread can be switched back into execution
                Thread.Sleep(0);
            }
            //t.Join() to make the program wait for the t Thread before it continues execution
            t.Join();
            Console.ReadLine();
        }

        public static void ThreadMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("ThreadProc: {0}", i);
                Thread.Sleep(0);
            }
        }
    }
}
