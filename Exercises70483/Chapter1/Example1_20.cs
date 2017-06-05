using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1.AsyncAwait
{
    /// <summary>
    /// If we want, we can disable the flow of the SynchronizationContext.
    /// Maybe our continuation code can run on any thread because it doesn't
    /// need to update the UI after it's finished.
    /// By disabling the SynchronizationContext, our code performs better.
    /// This example shows a button event handler that downloads a website and then puts the 
    /// result in a variable (that would be a label in a WPF app).
    /// </summary>
    public class Example1_20
    { 
        private async void Button_Click(object sender, object args)
        {
            HttpClient httpClient = new HttpClient();

            string content = await httpClient
                .GetStringAsync("http://www.microsoft.com")
                .ConfigureAwait(false);//By doing this, the execution doesn't return to the calling context/thread.

            var Output = content;//In a WPF app, this line would throw an exception when trying to assign this string to a label,
                                 //because this execution would never return to the calling context, that in this case is the UI thread.
                                 //If doing something else, like writing to a text file, we wouldn't need this execution to 
                                 //go back to the UI thread (setting the SynchronizationContext)
        }

    }
}
