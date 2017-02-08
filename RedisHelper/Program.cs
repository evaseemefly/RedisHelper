using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RedisHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            StringRWTest(10000);
            //StringRWbyThread(10000);
            Console.ReadLine();
        }       

        /// <summary>
        /// 测试单线程反复写入1w次35s
        /// </summary>
        /// <param name="count"></param>
        static void StringRWTest(int count)
        {
            //Common.Redis.StringRedisHelper redisHelper = new Common.Redis.StringRedisHelper();
            Common.StringReidsHelper_test stringHelper = new Common.StringReidsHelper_test();
            for (int i = 0; i < count; i++)
            {
                //Random random = new Random();                
                //redisHelper.Set(random.Next().ToString(), "1", DateTime.Now.AddSeconds(10));
                stringHelper.Set(i.ToString(), "ok", DateTime.Now.AddSeconds(10));
                Console.WriteLine(i + ":" + "ok");
            }

        }

        /// <summary>
        /// 测试多线程写入string操作（1w次，30s）
        /// </summary>
        /// <param name="count"></param>
        static void StringRWbyThread(int count)
        {
            int index_temp = 0;
            for (int i = 0; i < count; i++)
            {

                ThreadPool.QueueUserWorkItem(o =>
                {                   
                    //使用静态的RedisClient
                   // Common.StringReidsHelper_test stringHelper = new Common.StringReidsHelper_test();

                    //测试使用非静态的redisClient
                    Common.StringRedisHelper_NoStatic strHelper_NoStatic = new Common.StringRedisHelper_NoStatic();

                    //Random random = new Random();
                    //string radom_str = random.Next().ToString();

                    //var index = stringHelper.Set(i.ToString(), "1", DateTime.Now.AddSeconds(10));
                    var index = strHelper_NoStatic.Set(index_temp++.ToString(), "1", DateTime.Now.AddSeconds(10));
                    Console.WriteLine(index_temp + ":" + index);
                });

            }
        }
    }
}
