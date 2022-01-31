using System;

namespace DateModifier
{
    public static class DateModifier
    {
        public static double CalculateDates(DateTime StartDate, DateTime EndDate)
        {
            return (EndDate - StartDate).TotalDays;
        }
    }
}
