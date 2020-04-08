using System;
using Newtonsoft.Json;

namespace ConsoleTest
{
    public class Tuple
    {
        public Tuple()
        {
        }

        public static void Exam()
        {
            //未命名元组
            var unnamed = ("one", "two");
            //命名元组
            var named = (first: "one", second: "two");

            //用变量名初始化元组
            var sum = 12.5;
            var count = 5;
            var accumulation = (sum, count);

            Console.WriteLine(JsonConvert.SerializeObject(named));
            Console.WriteLine(accumulation.ToString());
        }
    }
}
