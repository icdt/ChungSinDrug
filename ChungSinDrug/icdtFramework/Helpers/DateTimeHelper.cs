using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace icdtFramework.Helpers
{
    public static class DateTimeHelper
    {

        public static DateTime StartOfDay(DateTime theDate)
        {
            return new DateTime(theDate.Year, theDate.Month, theDate.Day, 0, 0, 0);
        }


        public static DateTime EndOfDay(DateTime theDate)
        {
            return new DateTime(theDate.Year, theDate.Month, theDate.Day, 23, 59, 59);
        }
    }
}