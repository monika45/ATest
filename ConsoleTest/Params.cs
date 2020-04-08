using System;
namespace ConsoleTest
{
    public class Params
    {
        public Params()
        {
        }

        //参数数组，传数量不定的自变量
        public static void ParamExam(params object[] args)
        {
            foreach (var p in args)
            {
                Console.WriteLine(p);
            }
        }

        
    }



   
}
