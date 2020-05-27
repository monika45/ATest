using System;
using System.Globalization;

namespace ConsoleTest
{
    public class WorkWithStrings
    {
        public WorkWithStrings()
        {
        }
        /// <summary>
        /// 逗号隔开，负数表示左对齐，正数表示右对齐，补空格。
        /// 当字符串长度大于对齐长度时，以字符串长度为准
        /// </summary>
        public static void AlignmentComponent()
        {
            string[] names = { "adam", "Damo", "Mary"};
            decimal[] hours = { 40, 6.687m, 6.887m};
            Console.WriteLine("{0,-20} {1,5} {2,20}", "Names", "Hours", "FormatHours");
            for (int ctr = 0; ctr < names.Length; ctr++)
            {
                
                Console.WriteLine("{0,-20} {1,5} {2,20:N2}", names[ctr], hours[ctr], hours[ctr]);
            }
        }

        public static void FormatStringComponent()
        {
            var time = DateTime.Now;
            Console.WriteLine("{0:d}", time);

            DateTime dateTime = new DateTime(2020, 5, 20);
            Console.WriteLine(dateTime.ToString("d"));
            CultureInfo cultureInfo = new CultureInfo("hr-HR");
            Console.WriteLine(dateTime.ToString("d", cultureInfo.DateTimeFormat));

            Console.WriteLine(time.ToString("yyyy-MM-dd HH:mm:ss"));


            string[] dates = { "30-12-2020", "05-12-19", "2019/01/01", "2020/05/01 12:00:30"};
            //string pattern = "MM-dd-yy";
            DateTime parsedDate;
            //foreach (var date in dates)
            //{
            //    if (DateTime.TryParseExact(date, pattern, null, DateTimeStyles.None, out parsedDate))
            //    {
            //        Console.WriteLine("converted {0} to {1}", date, parsedDate);
            //    }
            //    else
            //    {
            //        Console.WriteLine("unable to convert {0} to a date and time", date);
            //    }
            //}
            Console.WriteLine("DateTime.TryParse:");
            foreach (var date in dates)
            {
                if (DateTime.TryParse(date, out parsedDate))
                {
                    Console.WriteLine("converted {0} to {1:yyyy-MM-dd HH:mm:ss}", date, parsedDate);
                }
                else
                {
                    Console.WriteLine("unable to convert {0} to a date and time", date);
                }
            }


            DateTime thisDate1 = new DateTime(2020, 5, 7);
            Console.WriteLine("今天是" + thisDate1.ToString("yyyy年M月d日"));

            DateTimeOffset thisDate2 = new DateTimeOffset(2020,5,1,10,25,5, TimeSpan.Zero);
            Console.WriteLine("当前时间{0:yyyy-MM-dd HH:mm:ss zzz}", thisDate2);

        }


    }
}
