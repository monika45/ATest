using System;
using System.Globalization;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest
{
    public class WorkWithStrings
    {
        public WorkWithStrings()
        {
        }

        public enum Color
        {
            Red = 1,
            Green = 2,
            Blue = 3
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

            //standard numeric format strings
            Console.WriteLine("the object0 is a decimal number:{0:N2}", 12.9862423m);
            Console.WriteLine("the object0 is a integer:{0:N2}", 12986);
            Console.WriteLine("the format specifier is c and the precision specifier is the number of decimal digits:{0:C2}", 12.986);
            //用NumberFormatInfo.CurrencyDecimalDigits设置小数位数
            NumberFormatInfo numberFormat = new CultureInfo("en-US", false).NumberFormat;
            Console.WriteLine("use NumberFormatInfo.CurrentcyDecimalDigits,默认是2位:{0}", 12.789.ToString("C", numberFormat));
            numberFormat.CurrencyDecimalDigits = 4;
            Console.WriteLine("use NumberFormatInfo,设置为4位:{0}", 12112.789.ToString("c", numberFormat));

            Console.WriteLine("use d:{0:D6}", 234);
            Console.WriteLine("use d:{0:D6}", 2342434243243);
            Console.WriteLine("use f:{0:f2}", 12345.567);
            Console.WriteLine("use N:{0:n2}", 12345.567);
            Console.WriteLine("use X convert to hexadecimal:{0:x4}", 32);
            Console.WriteLine("use X convert to hexadecimal:{0:x4}", 9999999999999999);
            Console.WriteLine("toString:{0}", 234234.ToString("N2"));

            var MyColor = Color.Green;
            Console.WriteLine("enum to string:{0:F}", MyColor);
            Console.WriteLine("enum to string:{0:X}", MyColor);
            Console.WriteLine("enum to string:{0:D}", MyColor);

        }


        public static void StringFormatMethod()
        {
            Decimal pricePerOunce = 17.36m;
            String s = String.Format("The current price is {0} per ounce", pricePerOunce);
            Console.WriteLine(s);
            Console.WriteLine("The current price is {0:C2} per ounce", pricePerOunce);

            String s1 = String.Format("It is now {0:d} at {0:t}", DateTime.Now);
            Console.WriteLine(s1);
            Console.WriteLine("It is now {0:d} at {0:t}", DateTime.UtcNow);
            DateTimeOffset dateTimeOffset = new DateTimeOffset(DateTime.UtcNow);
            DateTimeOffset dateTimeOffset1 = new DateTimeOffset(DateTime.Now);
            Console.WriteLine("UTC to unixtimestamp is {0}, local to unixtimestamp is {1}", dateTimeOffset.ToUnixTimeSeconds(), dateTimeOffset1.ToUnixTimeSeconds());


            int[] years = { 2013, 2014, 2015 };
            int[] population = { 1526432, 2033223, 3033254 };
            var sb = new System.Text.StringBuilder();
            sb.Append(String.Format("{0, -20} {1,20}\n\n", "Year", "Population"));
            for (int index = 0; index < years.Length; index++)
                sb.Append(String.Format("{0,-20} {1,20}\n", years[index], population[index]));
            Console.WriteLine(sb);


            string[] cultureNames = { "en-US", "fr-FR", "de-DE", "es-ES" };
            DateTime dateToDisplay = new DateTime(2009, 9, 1, 18, 32, 0);
            double value = 9164.32;
            Console.WriteLine("{0,-20} {1,-10} {2,20}", "Culture", "Date", "Value");
            foreach (string cultureName in cultureNames)
            {
                CultureInfo culture = new CultureInfo(cultureName);
                string output = String.Format(culture, "{0,-20} {1,-10:d} {2,20:N2}", cultureName, dateToDisplay, value);
                Console.WriteLine(output);
            }
           

            Console.WriteLine(String.Format(CultureInfo.CurrentCulture, "{0,-20} {1,-10:d} {2,20:N2}", CultureInfo.CurrentCulture.Name, dateToDisplay, value));
        }

        public static void StringMethods()
        {
            String s = "Show me the code!";
            String[] a = s.Split(" ");
            foreach (var item in a)
            {
                Console.WriteLine(item);
            }
            char[] ca = s.ToCharArray();
            foreach (var item  in ca)
            {
                Console.Write($"{item}\n");
            }

            String s1 = "A";
            String s2 = "B";
            Console.WriteLine(String.Compare(s1, s2));


            List<object> myL = new List<object>();
            myL.Add("Eric");
            myL.Add("Alice");
            myL.Add("Goge");
            myL.Add("ABei");
            //myL.Add(5);
            //myL.Add(0.456m);
            PrintValues("Unsorted:", myL);

            myL.Sort();

            PrintValues("Sorted:", myL);

            myL.Sort(new ReverseStringComparer());

            PrintValues("Reverse:", myL);

            
        }

        public static void PrintValues(string title, List<object> list)
        {
            Console.WriteLine("{0,10}", title);
            StringBuilder sb = new StringBuilder();
            foreach (var o in list)
            {
                var item = o as string;
                sb.AppendFormat("{0}, ", item);
            }
            sb.Remove(sb.Length - 2, 2);
            Console.WriteLine(sb);
        }

       

    }

    public class ReverseStringComparer : IComparer<object>
    {
        public int Compare (object x, object y)
        {
            string s1 = x as string;
            string s2 = y as string;
            return -String.Compare(s1, s2);
        }

    }
}
