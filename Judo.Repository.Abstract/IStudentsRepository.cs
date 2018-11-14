using Judo.Models;
using System.Collections.Generic;

namespace Judo.Repository.Abstract
{
    public interface IStudentsRepository
    {
        List<Student> GetAll();

        List<Student> GetAllForTable();

        Student GetById(int? id);

        bool Create(Student newObject);

        bool Delete(int id);
    }
}
