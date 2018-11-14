using Judo.Models;
using Judo.Models.Mapped;
using Judo.Repository.Abstract;
using Judo.Repository.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Judo
{
    public static class Dependencies
    {
        public static void UseModels(IServiceCollection services)
        {
            services.AddTransient<IJudoDBContext, JudoDBContext>();
            services.AddTransient<IPeopleRepository, PeopleRepository>();
            services.AddTransient<IStudentsRepository, StudentsRepository>();
            services.AddTransient<IСurriculumRepository, СurriculumRepository>();
        }
    }
}
