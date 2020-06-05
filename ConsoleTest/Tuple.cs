using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ConsoleTest
{
    public class TupleTest
    {
        public TupleTest()
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
            Console.WriteLine($"{accumulation.sum},{accumulation.Item1}");

            //元组投影初始值设定项,可以投影字段名
            var local1 = 5;
            var local2 = "some text";
            var tuple = (one: local1, two: local2);

            var str = "the answer to everything";
            var mixedTuple = (42, str);
            Console.WriteLine($"{mixedTuple.Item1},{mixedTuple.str}");
            Console.WriteLine(tuple.one);
            Console.WriteLine(tuple.Item1);

            var pt1 = (X: 3, Y: 4);
            var pt2 = (X: 5, Y: 6);
            //字段名有歧义时，不会投影语义名称
            var mixedp = (pt1.X, pt2.X);
            Console.WriteLine(mixedp.Item1);

            //元组比较
            var left = (a: 5, b: 10);
            var right = (a: 5, b: 10);
            Console.WriteLine(left == right);

            (int a, int b)? nullableTuple = right;
            Console.WriteLine(left == nullableTuple);

            //会对每个成员执行隐式转换
            (int? a, int? b) nullableTuple2 = right;
            Console.WriteLine(left == right);

            (long a, int b) longFirst = (5, 10);
            Console.WriteLine(longFirst == right);

            //成员名不参与比较
            var pair = (z: 5, n: 6);
            Console.WriteLine(pair == pt2);

            //析构
            var person = new Person("Li", "Ming");
            var (first, last) = person;
            Console.WriteLine($"析构：{first},{last}");

            var (_, _, age) = person;
            Console.WriteLine($"弃元：{person.Age}");

            //元组作为out参数
            Dictionary<int, (int, string)> dict = new Dictionary<int, (int, string)>();
            dict.Add(1, (234, "first"));
            dict.Add(2, (456, "second"));
            dict.Add(3, (789, "third"));

            dict.TryGetValue(2, out (int num, string place) pair2);
            Console.WriteLine($"{pair2.num},{pair2.place}");






        }


        //元组作为方法的结果返回
        public static double StandardDeviation(IEnumerable<double> sequence)
        {
            var computation = ComputeSumAndSumOfSquares(sequence);

            var variance = computation.SumOfSquares - computation.Sum * computation.Sum / computation.Count;

            return Math.Sqrt(variance / computation.Count);
        }

        private static (int Count, double Sum, double SumOfSquares) ComputeSumAndSumOfSquares(IEnumerable<double> sequence)
        {
            double sum = 0;
            double sumOfSquares = 0;
            int count = 0;

            foreach (var item in sequence)
            {
                count++;
                sum += item;
                sumOfSquares += item * item;
            }

            return (count, sum, sumOfSquares);
        }

        //析构
        public static double StandardDeviation2(IEnumerable<double> sequence)
        {
            (int count, double sum, double sumOfSquares) = ComputeSumAndSumOfSquares(sequence);

            //或者
            //var (count, sum, sumOfSquares) = ComputeSumAndSumOfSquares(sequence);

            var variance = sumOfSquares - sum * sum / count;

            return Math.Sqrt(variance / count);
        }

        
    }

    //使用现有声明析构元组
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y) => (X, Y) = (x, y);
    }

    //析构用户定义类型
    public class Person : IPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public Person(string first, string last)
        {
            FirstName = first;
            LastName = last;
        }

        public void Deconstruct(out string firstname, out string lastname)
        {
            firstname = FirstName;
            lastname = LastName;
        }

        public void Deconstruct(out string firstname, out string lastname, out int age)
        {
            firstname = FirstName;
            lastname = LastName;
            age = Age;
        }

        public string HTest()
        {
            return "";
        }
    }


    public interface IPerson
    {
        public string Hello()
        {
            return "Hi!";
        }

        public string HTest();

    }

    

    


}
