using System;
namespace ConsoleTest
{
    public class OutExam
    {
        public OutExam()
        {
        }

        public static void Divide(int x, int y, out int result, out int remainder)
        {
            result = x / y;
            remainder = x % y;
        }

        public static void OutUsage()
        {
            Divide(10, 3, out int res, out int rem);
            Console.WriteLine($"{res}, {rem}");
        }
    }
}
