using System;
using System.Globalization;
namespace ConsoleTest
{
    public class WorkWithDateTime
    {
        public WorkWithDateTime()
        {
        }

        public static void toDatetime()
        {
            var s = "20200608102340";
            DateTime dateTime = DateTime.ParseExact(s, "yyyyMMddHHmmss", CultureInfo.CurrentCulture);
            Console.WriteLine(dateTime.ToString());
        }

        public static void unixTimeStampToDatetime()
        {
            var i = 1589298488;
            var dateTime = DateTimeOffset.FromUnixTimeSeconds(i).LocalDateTime;
            Console.WriteLine(dateTime);
        }

        public static void strToDatetime()
        {
            var s = "2020-06-08 10:23:40";
            DateTime dateTime = DateTime.ParseExact(s, "yyyy-MM-dd HH:mm:ss", CultureInfo.CurrentCulture);
            Console.WriteLine(dateTime);
        }
    }
}
