using System;
namespace ConsoleTest
{
    public class RefExam
    {
        public RefExam()
        {
        }

        static void Swap(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }

        public static void SwapExam()
        {
            int i = 1, j = 2;
            Swap(ref i, ref j);
            Console.WriteLine($"{i},{j}");
        }
    }
}
