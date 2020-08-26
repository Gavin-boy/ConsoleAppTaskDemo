using System;
using System.Threading;
using System.Threading.Tasks;

namespace _2._7._2
{
    class Program
    {
        private delegate string AsynchronousTask(string threadName);

        private static string Test(string threadName)
        {
            Console.WriteLine("Starting...");
            Console.WriteLine("Is thread pool thread: {0}", Thread.CurrentThread.IsThreadPoolThread);
            Thread.Sleep(TimeSpan.FromSeconds(2));
            Thread.CurrentThread.Name = threadName;
            return string.Format("Thread name: {0}", Thread.CurrentThread.Name);
        }

        //执行的流程是 先执行Test--->task.ContinueWith
        static void Main(string[] args)
        {
            AsynchronousTask d = Test;
            Task<string> task = Task<string>.Factory.FromAsync(
                d.BeginInvoke, d.EndInvoke, "AsyncTaskThread", "a delegate asynchronous call");
            task.ContinueWith(t => Console.WriteLine("Task is completed, now running a continuation! Result: {0}",
                t.Result));
            while (!task.IsCompleted)
            {
                Console.WriteLine(task.Status);
                Thread.Sleep(TimeSpan.FromSeconds(0.5));
            }
            Console.WriteLine(task.Status);
            Console.ReadKey();
        }
    }
}
