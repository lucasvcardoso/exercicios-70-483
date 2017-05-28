using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1.TaskClass
{
    public static class Example1_8
    {
        public static void TMain()
        {
            //This creates and immediatly starts a new Task.
            Task t = Task.Run(() =>
            {
                for (int x = 0; x < 100; x++)
                {
                    Console.Write('*');
                }
            });
            //Calling Wait() is the equivalent of calling Join() on a Thread object.
            t.Wait();
            //Console.ReadKey();
        }
    }
}
