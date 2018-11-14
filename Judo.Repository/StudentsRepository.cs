using Judo.Models;
using Judo.Models.Mapped;
using Judo.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Judo.Repository.Concrete
{
    public class StudentsRepository : IStudentsRepository
    {
        IJudoDBContext context;

        public StudentsRepository(IJudoDBContext _context)
        {
            context = _context;
        }

        public List<Student> GetAll()
        {
            return context.Students.Select(s => new Student()
            {
                StudentId = s.Id,
                RankId = s.RankId,
                PeopleId = s.PeopleId,
                First = context.People.Find(s.PeopleId).First,
                Last = context.People.Find(s.PeopleId).Last,
                Middle = context.People.Find(s.PeopleId).Middle,
                BirthDate = context.People.Find(s.PeopleId).BirthDate,
                Sex = context.People.Find(s.PeopleId).Sex,
                RankName = context.Ranks.Find(s.RankId).Name,
                CharacteristicToStudent = s.CharacteristicToStudent.ToList()
            }).ToList();
        }

        public List<Student> GetAllForTable()
        {
            return context.Students.Select(s => new Student()
            {
                StudentId = s.Id,
                First = context.People.FirstOrDefault(p => p.Id == s.PeopleId).First,
                Last = context.People.FirstOrDefault(p => p.Id == s.PeopleId).Last,
                Middle = context.People.FirstOrDefault(p => p.Id == s.PeopleId).Middle,
                Sex = context.People.FirstOrDefault(p => p.Id == s.PeopleId).Sex,
                RankName = context.Ranks.FirstOrDefault(r => r.Id == s.RankId).Name,
            }).ToList();
        }

        public Student GetById(int? id)
        {
            try
            {
                var student = context.Students.Find(id);
                var people = context.People.Find(student.PeopleId);
                var rank = context.Ranks.Find(student.RankId);

                return new Student()
                {
                    First = people.First,
                    Middle = people.Middle,
                    Last = people.Last,
                    BirthDate = people.BirthDate,
                    Sex = people.Sex,
                    PeopleId = student.PeopleId,
                    RankId = student.RankId,
                    StudentId = student.Id,
                    RankName = rank.Name,

                    CharacteristicToStudent = student.CharacteristicToStudent.ToList()
                };
            }
            catch
            {
                return new Student();
            }
        }

        public bool Create(Student newObject)
        {
            try
            {
                context.People.Add(new People()
                {
                    First = newObject.First,
                    Middle = newObject.Middle,
                    Last = newObject.Last,
                    BirthDate = newObject.BirthDate,
                    Sex = newObject.Sex,
                });
                context.SaveChanges();
                context.Students.Add(new Students()
                {
                    PeopleId = context.People.FirstOrDefault(p =>
                        p.First == newObject.First &&
                        p.Middle == newObject.Middle &&
                        p.Last == newObject.Last &&
                        p.Sex == newObject.Sex &&
                        p.BirthDate == newObject.BirthDate
                    ).Id,
                    RankId = newObject.RankId,
                });
                context.SaveChanges();
                return true;
            }
            catch
            {
                try
                {
                    context.People.Remove(context.People.FirstOrDefault(p =>
                        p.First == newObject.First &&
                        p.Middle == newObject.Middle &&
                        p.Last == newObject.Last &&
                        p.Sex == newObject.Sex &&
                        p.BirthDate == newObject.BirthDate
                    ));
                }
                catch { }
                return false;
            }
        }

        public bool Delete(int id)
        {
            var student = context.Students.Find(id);
            int peopleId = student.PeopleId;
            var people = context.People.Find(peopleId);

            try
            {
                context.Students.Remove(student);
                try
                {
                    context.People.Remove(people);
                    return true;
                }
                catch
                {
                    context.Students.Add(student);
                    return false;
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                context.SaveChanges();
            }
        }
    }
}
