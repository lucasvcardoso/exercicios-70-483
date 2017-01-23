using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Chapter1.ThreadClass
{
    /// <summary>
    /// An example of how to use the ParameterizedThreadStart
    /// </summary>
    class Example1_3
    {
        static void TMain(string[] args)
        {
            //Using the ParameterizedThreadStart delegate we can pass information to the 
            //worker code through the Start() method.
            Thread t = new Thread(new ParameterizedThreadStart(ThreadMethod));
            t.Start(5);
            t.Join();
            Console.ReadLine();
        }

        public static void ThreadMethod(object o)
        {
            for (int i = 0; i < (int)o; i++)
            {
                Console.WriteLine("ThreadProc: {0}", i);
                Thread.Sleep(0);
            }
        }
    }
}
