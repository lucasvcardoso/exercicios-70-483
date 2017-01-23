using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Chapter1.ThreadClass
{
    /// <summary>
    /// An example of how to use a background Thread
    /// </summary>
    class Example1_2
    {
        static void TMain(string[] args)
        {
            Thread t = new Thread(new ThreadStart(ThreadMethod));
            //t.IsBackground is used to define whether a thread if foreground or background.
            //If background, the program won't wait for the thread to finish before it exits.
            //If foreground, the program waits for the thread to finish before it exits.
            t.IsBackground = true;
            t.Start();
        }

        public static void ThreadMethod()
        {
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("ThreadProc: {0}", i);
                Thread.Sleep(1000);
            }
        }
    }
}
