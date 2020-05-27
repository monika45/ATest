using System;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Pair<int, string> pair = new Pair<int, string>() { First = 1, Second = "two"};

            //int i = pair.First;

            //string s = pair.Second;

            //Console.WriteLine(s + i);

            //RefExam.SwapExam();

            //OutExam.OutUsage();

            //Params.ParamExam(1, 3, 4, "3srew");

            //double[] a = { 0.0, 0.5, 1.0 };
            //double[] squares = DelegateExample.Apply(a, DelegateExample.Square);
            //double[] sines = DelegateExample.Apply(a, Math.Sin);

            //Multiplier m = new Multiplier(2.0);
            //double[] doubles = DelegateExample.Apply(a, m.Multiply);

            //委托
            //Delegate.Example();

            //特性
            //Example.e1();

            //引用类型
            //Customer c1 = new Customer();
            //Customer c2 = c1;
            //c1.Name = "L1";
            //Console.WriteLine(c2.Name);


            //元组
            //Tuple.Exam();

            //WorkWithStrings.AlignmentComponent();
            WorkWithStrings.FormatStringComponent();


        }
    }

    public class Pair<TFirst, TSecond>
    {
        public TFirst First;

        public TSecond Second;
    }


    delegate double Function(double x);
    class Multiplier
    {
        double factor;
        public Multiplier(double factor)
        {
            this.factor = factor;
        }

        public double Multiply(double x)
        {
            return x * factor;
        }

    }

    class DelegateExample
    {
        public static double Square(double x)
        {
            return x * x;
        }

        public static double[] Apply(double[] a, Function f)
        {
            double[] result = new double[a.Length];
            for (int i = 0; i < a.Length; i++) result[i] = f(a[i]);
            return result;
        }


    }

   class Customer
   {
        public string Name { get; set; }
   }


}
