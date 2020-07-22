using System;
namespace ConsoleTest
{
    public class IsKeyword
    {
        public IsKeyword()
        {
        }

        public static void PatternMatching()
        {
            var a = 3 + 2;

            Console.WriteLine(a is double);
            Console.WriteLine(a.GetType());

            var h = new Hero()
            {
                name = "sbd",
                role = "tank"
            };

            var d = new Diaochan()
            {
                name = "diaochan",
                role = "mage",
                difficulty = 7
            };
            Console.WriteLine(h is Hero);
            Console.WriteLine(h is Diaochan);
            Console.WriteLine(d is Diaochan);
            Console.WriteLine(d is Hero);
            Console.WriteLine(d.GetType());
        }
    }

    public class Hero
    {
        public string name { get; set; }

        public string role { get; set; }
    }

    public class Diaochan : Hero
    {
        public int difficulty { get; set; }
    }
}
