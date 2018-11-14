using Judo.Models;
using Judo.Models.Mapped;
using Judo.Repository.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace Judo.Repository.Concrete
{
    public class PeopleRepository : IPeopleRepository
    {
        IJudoDBContext context;

        public PeopleRepository(IJudoDBContext _context)
        {
            context = _context;
        }

        public List<People> GetAllPeople()
        {
            return context.People.ToList();
        }
    }
}
