using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1.AsynAwait
{
    public static class Example1_18
    {
        /// <summary>
        /// Because the entry method of an application can't be marked as async,
        /// the example accesses the Result property in the Main method which blocks
        /// the code until the async method DownloadContent() is finished. This class uses both
        /// the async and await keywords in the DownloadContent() method.
        /// The GetStringAsync() uses asynchronous code internally and returns a Task<string>
        /// to the caller that will finish when the data is retrieved. In the meantime,
        /// your thread can do other work.
        /// </summary>
        public static void AMain()
        {
            string result = DownloadContent().Result;
            Console.WriteLine(result);
            Console.ReadKey();
        }

        public static async Task<string> DownloadContent()
        {
            using (HttpClient client = new HttpClient())
            {
                string result = await client.GetStringAsync("http://www.microsoft.com");
                return result;
            }
        }
    }
}
