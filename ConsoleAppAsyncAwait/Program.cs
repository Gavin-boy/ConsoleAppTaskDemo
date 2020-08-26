using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppAsyncAwait
{
    class Program
    {
        async static void AsyncFunction()
        {
            await Task.Delay(1);
            Console.WriteLine("使用System.Threading.Tasks.Task执行异步操作.");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(string.Format("AsyncFunction:i={0}",i));
            }
        }
        public static void Main(string[] args)
        {
            Console.WriteLine("主线程执行业务处理.");
            AsyncFunction();
            Console.WriteLine("主线程执行其他处理.");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(string.Format("Main:i={0}",i));
            }
            Console.ReadLine();
        }
    }
}
