using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Chapter1.ThreadClass
{
    /// <summary>
    /// Using the <i>ThreadStaticAttribute</i>
    /// </summary>
    class Example1_5
    {
        //In this example the attribute ThreadStaticAttribute is used to mark a global field
        //as a field that is static for each Thread using it.
        [ThreadStatic]
        public static int _field;

        public static void TMain()
        {
            new Thread(() =>
                {
                    for (int x = 0; x < 10; x++)
                    {
                        _field++;
                        Console.WriteLine("Thread A: {0}", _field);
                    }
                }
            ).Start();

            new Thread(() =>
            {
                for (int x = 0; x < 10; x++)
                {
                    _field++;
                    Console.WriteLine("Thread B: {0}", _field);
                }
            }).Start();

            Console.ReadKey();
        }
    }
}
