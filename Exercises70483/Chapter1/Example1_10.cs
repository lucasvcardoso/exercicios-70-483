using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1.TaskClass
{
    /// <summary>
    /// Because of the object-oriented nature of the Task object,
    /// one thing you can do is add a continuation task. This means
    /// that you want another operation to execute as soon as the Task finishes.
    /// </summary>
    public static class Example1_10
    {
        public static void TMain()
        {
            Task<int> t = Task.Run(() =>
            {
                return 42;
            }).ContinueWith((firstTask) =>  //In this case, firstTaks is the object of the first Task
            {
                return firstTask.Result * 2;
            });
            Console.WriteLine(t.Result); //This accesses the final result of t and displays 84;
            Console.ReadKey();
        }
    }
}
