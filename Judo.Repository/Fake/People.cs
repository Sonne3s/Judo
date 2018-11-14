using Judo.Models.Fake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Judo.Repository.Concrete.Fake
{
    public static class People
    {
        public static List<Person> Persons { get; set; } = new List<Person>() { new Person() {Id = 1, FirstName = "Иван", MiddleName = "Иванович", LastName = "Иванов" } };

        public static List<Group> Groups { get; set; }

        public static List<Person> GetPeople()
        {
            return Persons;
        }

        public static IDictionary<int, string> GetPeopleToString()
        {
            return GetPeople().ToDictionary(Key => Key.Id, Value => $"{Value.FirstName} {Value.LastName} {Value.MiddleName}");
        }

        public static void AddPerson(Person person)
        {
            Persons.Add(person);
        }

        public static Person GetPerson(int id)
        {
            return Persons.FirstOrDefault(p => p.Id == id);
        }

        public static void AddGroup(Group group)
        {
            Groups.Add(group);
        }
    }
}
