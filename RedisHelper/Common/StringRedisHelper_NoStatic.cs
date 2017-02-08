using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisHelper.Common
{
    public class StringRedisHelper_NoStatic
    {
        /// <summary>
        /// 设置key的value并设置过期时间
        /// </summary>
        public bool Set(string key, string value, DateTime dt)
        {
            var manager =new BaseRedisManagerByNoStatic();
            var client= manager.GetClient();
            var temp=client.Set<string>(key, value, dt);
            
            client.Dispose();
            return temp;
            //return BaseRedisOperatHelper.redis_client.Set<string>(key, value, dt);

        }
    }
}
