using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vavatech.DesignPatterns
{
    class DateTimeHelper
    {
        public static bool IsHoliday(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Sunday
                || date.DayOfWeek == DayOfWeek.Saturday;
        }
    }


    static class DateTimeExtensions
    {
        public static bool IsHoliday(this DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Sunday
                || date.DayOfWeek == DayOfWeek.Saturday;
        }


        public static DateTime AddWorkDays(this DateTime date, int days)
        {
            return date.AddDays(days);
        }
    }

    class DateTimeTests
    {
        public static void Test()
        {
         //   var isHoliday = DateTimeHelper.IsHoliday(DateTime.Now);

            var isHoliday = DateTime.Now.IsHoliday();


            DateTime.Now.AddWorkDays(10);
        }
    }
}
