using System;
using System.Collections.Generic;
using System.Text;

namespace Judo.Repository.Abstract
{
    public interface IСurriculumRepository
    {
        IDictionary<DateTime, int> GetCalendar(int? _month, int? _year);
    }
}
