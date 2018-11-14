using Judo.Models.Mapped;
using Judo.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Judo.Repository.Concrete
{
    public class СurriculumRepository : IСurriculumRepository
    {
        IJudoDBContext context;

        public СurriculumRepository(IJudoDBContext _context)
        {
            context = _context;
        }

        private int GetMonthPosition(int calendarMonth, int currentMonth)
        {
            if (calendarMonth == 1)
            {
                if (currentMonth == 12)
                {
                    return -1;
                }
                else if (currentMonth == 1)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            else if (calendarMonth == 12)
            {
                if (currentMonth == 11)
                {
                    return -1;
                }
                else if (currentMonth == 12)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                if (currentMonth < calendarMonth)
                {
                    return -1;
                }
                else if (currentMonth == calendarMonth)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
        }

        public IDictionary<DateTime, int> GetCalendar(int? _month, int? _year)
        {
            int month = _month ?? DateTime.Now.Month;
            int year = _year ?? DateTime.Now.Year;
            int start = 0;
            int daysInCalendar;
            DateTime firstDayInMonth = new DateTime(year, month, 1);
            DateTime currentDay = firstDayInMonth;
            Dictionary<DateTime, int> calendar = new Dictionary<DateTime, int>();
            switch (firstDayInMonth.DayOfWeek)
            {
                case DayOfWeek.Monday: calendar.Add(firstDayInMonth, 0); start = 0; break;
                case DayOfWeek.Tuesday: calendar.Add(firstDayInMonth.AddDays(-1), -1); start = 1; break;
                case DayOfWeek.Wednesday: calendar.Add(firstDayInMonth.AddDays(-2), -1); start = 2; break;
                case DayOfWeek.Thursday: calendar.Add(firstDayInMonth.AddDays(-3), -1); start = 3; break;
                case DayOfWeek.Friday: calendar.Add(firstDayInMonth.AddDays(-4), -1); start = 4; break;
                case DayOfWeek.Saturday: calendar.Add(firstDayInMonth.AddDays(-5), -1); start = 5; break;
                case DayOfWeek.Sunday: calendar.Add(firstDayInMonth.AddDays(-6), -1); start = 6; break;
            }
            daysInCalendar = DateTime.DaysInMonth(year, month) + start;
            for (int i = 0; i < daysInCalendar || currentDay.DayOfWeek != DayOfWeek.Sunday; i++)
            {
                currentDay = calendar.Last().Key.AddDays(1);
                calendar.Add(currentDay, GetMonthPosition(month, currentDay.Month));
            }
            return calendar;
        }
    }
}
