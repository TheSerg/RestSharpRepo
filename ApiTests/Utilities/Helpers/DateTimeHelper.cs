namespace ApiTests.Utilities
{
    using System;
    using System.Globalization;
    using NUnit.Framework;

    public class DateTimeHelper
    {
        public static DateTime GetStartOfDay(DateTime date)
        {
            return AdjustTimeOfTheDay(date, 0, 0, 0, 0);
        }

        public static DateTime GetEndOfDay(DateTime date)
        {
            return AdjustTimeOfTheDay(date, 23, 59, 59, 0);
        }

        public static DateTime AdjustTimeOfTheDay(DateTime date, int hour, int minute, int second, int milisecond)
        {
            DateTime dateTime = date;

            if (hour > -1 && hour < 24) { date.AddHours(hour); }
            if (minute > -1 && minute < 60) { date.AddMinutes(minute); }
            if (second > -1 && second < 60) { date.AddSeconds(second); }
            if (milisecond > -1 && milisecond < 1000) { date.AddMilliseconds(milisecond); }

            return dateTime;
        }

        public static DateTime AddUtcOffset(DateTime date)
        {
            TimeSpan offset = TimeZoneInfo.Local.GetUtcOffset(date);
            return date.AddSeconds(-offset.Seconds);
        }

        public static DateTime AdjustDateBySeconds(DateTime date, int seconds)
        {
            return AdjustDate(date, CalendarOption.SECOND, seconds);
        }

        public static DateTime AdjustDateByHours(DateTime date, int hours)
        {
            return AdjustDate(date, CalendarOption.HOUR, hours);
        }

        public static DateTime AdjustDateByDays(DateTime date, int days)
        {
            return AdjustDate(date, CalendarOption.DAY, days);
        }

        public static DateTime AdjustDateByYears(DateTime date, int years)
        {
            return AdjustDate(date, CalendarOption.YEAR, years);
        }

        public static DateTime AdjustDateByMonths(DateTime date, int months)
        {
            return AdjustDate(date, CalendarOption.MONTH, months);
        }

        public static int GetDateDay(DateTime date)
        {
            return date.DayOfYear;
        }

        public static int GetDateMonth(DateTime date)
        {
            return date.Month;
        }

        public static int GetDateYear(DateTime date)
        {
            return date.Year;
        }

        public static DateTime ConvertToDate(string dateString, string dateFormat)
        {
            try
            {
                DateTime date = DateTime.ParseExact(dateString, dateFormat, CultureInfo.CurrentCulture);
                return date;
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.StackTrace);
                return new DateTime();
            }
        }

        public static string ConvertToString(DateTime date, string dateFormat)
        {
            try
            {
                return date.ToString(dateFormat);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.StackTrace);
                return null;
            }
        }

        public static long DiffBetweenDates(DateTime startDate, DateTime endDate, CalendarOption calendarOption)
        {
            if (endDate > startDate)
            { return DiffBetweenDates(endDate, startDate, calendarOption); }

            TimeSpan duration = endDate - startDate;

            switch (calendarOption)
            {
                case CalendarOption.SECOND:
                    return duration.Seconds;
                case CalendarOption.MINUTE:
                    return duration.Minutes;
                case CalendarOption.HOUR:
                    return duration.Hours;
            }

            Assert.That(calendarOption, Is.EqualTo(CalendarOption.SECOND) | Is.EqualTo(CalendarOption.MINUTE) | Is.EqualTo(CalendarOption.HOUR), "Invalid variable used!");
            return 0L;
        }

        public enum CalendarOption
        {
            SECOND,
            MINUTE,
            HOUR,
            WEEK_OF_YEAR,
            DAY,
            MONTH,
            YEAR,
        }

        private static DateTime AdjustDate(DateTime date, CalendarOption calendarOption, int value)
        {
            switch (calendarOption)
            {
                case CalendarOption.SECOND:
                    date.AddSeconds(value);
                    break;
                case CalendarOption.HOUR:
                    date.AddHours(value);
                    break;
                case CalendarOption.DAY:
                    date.AddDays(value);
                    break;
                case CalendarOption.MONTH:
                    date.AddMonths(value);
                    break;
                case CalendarOption.YEAR:
                    date.AddYears(value);
                    break;
            }

            return date;
        }
    }
}