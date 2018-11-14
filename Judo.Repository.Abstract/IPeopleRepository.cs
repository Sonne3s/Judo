using Judo.Models;
using Judo.Models.Mapped;
using System;
using System.Collections.Generic;
using System.Text;

namespace Judo.Repository.Abstract
{
    public interface IPeopleRepository
    {
        List<People> GetAllPeople();
    }
}
