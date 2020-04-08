using System;
namespace ConsoleTest
{
    //委托是一个类，定义了方法的类型。
    //在声明类的地方都可以声明委托。

    public delegate void GreetingDelegate(string name);
    public class Delegate
    {
        public Delegate()
        {
        }

        private static void EnglishGreeting(string name)
        {
            Console.WriteLine("Hi," + name);
        }

        private static void ChineseGreeting(string name)
        {
            Console.WriteLine("你好," + name);
        }

        private static void GreetingPeople(string name, GreetingDelegate greetingDelegate)
        {
            greetingDelegate(name);
        }

        public static void Example()
        {
            GreetingPeople("Lisa", EnglishGreeting);
            GreetingPeople("李白", ChineseGreeting);
        }
    }
}
