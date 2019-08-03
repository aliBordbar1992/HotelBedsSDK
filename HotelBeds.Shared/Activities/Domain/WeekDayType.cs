using System;
using System.Collections.Generic;

namespace HotelBeds.Shared.Activities.Domain
{
    public class WeekDayType
    {
        public static readonly WeekDayType Sunday = new WeekDayType(DayOfWeek.Sunday);
        public static readonly WeekDayType Monday = new WeekDayType(DayOfWeek.Monday);
        public static readonly WeekDayType Tuesday = new WeekDayType(DayOfWeek.Tuesday);
        public static readonly WeekDayType Wednesday = new WeekDayType(DayOfWeek.Wednesday);
        public static readonly WeekDayType Thursday = new WeekDayType(DayOfWeek.Thursday);
        public static readonly WeekDayType Friday = new WeekDayType(DayOfWeek.Friday);
        public static readonly WeekDayType Saturday = new WeekDayType(DayOfWeek.Saturday);

        public static IEnumerable<WeekDayType> Values
        {
            get
            {
                yield return Sunday;
                yield return Monday;
                yield return Tuesday;
                yield return Wednesday;
                yield return Thursday;
                yield return Friday;
                yield return Saturday;
            }
        }

        private readonly int _dayCode;

        WeekDayType(DayOfWeek day)
        {
            _dayCode = (int)day;
        }

        public int GetDayCode()
        {
            return _dayCode;
        }

        public static WeekDayType FromDayCode(int dayCode)
        {
            foreach (WeekDayType dayOfWeek in Values)
            {
                if (dayOfWeek.GetDayCode() == dayCode)
                {
                    return dayOfWeek;
                }
            }

            throw new ArgumentException("Unknown day of week code: " + dayCode);
        }


        public static WeekDayType FromDate(DateTime date)
        {
            if (date == null)
            {
                throw new ArgumentException("Null date is not allowed in DayOfWeek");
            }

            int dayOfWeek = (int)date.DayOfWeek;
            return FromDayCode(dayOfWeek);
        }
    }
}