using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Chapter1.ThreadClass
{
    /// <summary>
    /// An example of how to stop a thread
    /// </summary>
    class Example1_4
    {
        public static void TMain()
        {
            //In this example we'll use a shared bool to signal to the Thread when to stop.
            //This technic is safer than use Thread.Abort(), because it could potentially leave the program in a
            //corrupt state, throwing an excpetion of the type ThreadAbort-Exception
            bool stopped = false;
            Thread t = new Thread(new ThreadStart(() =>
            {
                while (!stopped)
                {
                    Console.WriteLine("Running...");
                    Thread.Sleep(1000);
                }
            }
            ));

            t.Start();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();

            stopped = true;

            t.Join();
        }
    }
}
