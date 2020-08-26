using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2._4._1
{
    class Program
    {
        static int TaskMethod(string name, int seconds)
        {
            Console.WriteLine("Task {0} is running on a thread id {1}. Is thread pool thread: {2}",
                name, Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.IsThreadPoolThread);
            Thread.Sleep(TimeSpan.FromSeconds(seconds));
            //throw new Exception("Boom!");
            return 42 * seconds;
        }

        static void Main(string[] args)
        {
            try
            {
                Task<int> task = Task.Run(() => TaskMethod("Task 2", 2));
                int result = task.GetAwaiter().GetResult();
                Console.WriteLine("Result: {0}", result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Task 2 Exception caught: {0}", ex.Message);
            }
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
