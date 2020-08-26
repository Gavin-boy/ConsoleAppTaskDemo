using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2._4._3
{
    class Program
    {
        static async Task ThrowNotImplementedExceptionAsync()
        {
            throw new NotImplementedException();
        }
        static async Task ThrowInvalidOperationExceptionAsync()
        {
            throw new InvalidOperationException();
        }
        static async Task Normal()
        {
            await Fun();
        }
        static Task Fun()
        {
            return Task.Run(() =>
            {
                for (int i = 1; i <= 10; i++)
                {
                    Console.WriteLine("i={0}", i);
                    Thread.Sleep(200);
                }
            });
        }
        static async Task ObserveOneExceptionAsync()
        {
            var task1 = ThrowNotImplementedExceptionAsync(); 
            var task2 = ThrowInvalidOperationExceptionAsync(); 
            var task3 = Normal();
            try
            {   //异步的方式
                Task allTasks = Task.WhenAll(task1, task2, task3);
                await allTasks;
                //同步的方式                
                //Task.WaitAll(task1, task2, task3);            
            }
            catch (NotImplementedException ex)
            {
                Console.WriteLine("task1 任务报错!");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("task2 任务报错!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("任务报错!");
            }
            Console.ReadKey();

        }
        public static void Main()
        {
            Task task = ObserveOneExceptionAsync();
            Console.WriteLine("主线程继续运行........");
            task.Wait();
        }
    }
}
