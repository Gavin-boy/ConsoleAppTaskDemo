using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2._5
{
    class Program
    {
        static IDictionary<string, string> cache = new Dictionary<string, string>()
        {
            {"0001","A"},
            {"0002","B"},
            {"0003","C"},
            {"0004","D"},
            {"0005","E"},
            {"0006","F"},
        }; public static void Main()
        {
            Task<string> task = GetValueFromCache("0006");
            Console.WriteLine("主程序继续执行。。。。"); string result = task.Result;
            Console.WriteLine("result={0}", result);
            Console.ReadKey();
        }
        private static Task<string> GetValueFromCache(string key)
        {
            Console.WriteLine("GetValueFromCache开始执行。。。。"); 
            string result = string.Empty;            
            //Task.Delay(5000);
            Thread.Sleep(3000);
            Console.WriteLine("GetValueFromCache继续执行。。。。"); 
            if (cache.TryGetValue(key, out result))
            {
                return Task.FromResult(result);
            }
            return Task.FromResult("");
        }

    }
}
