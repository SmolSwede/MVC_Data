using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data.Models
{
    public class InMemoryPerson
    {
        private static int idCounter = 0;
        private static List<Person> listOfPeople = new List<Person>();

        public Person Create(Person person)
        {
            Person newPerson = new Person();
            newPerson.Id = ++idCounter;
            newPerson.FirstName = person.FirstName;
            newPerson.LastName = person.LastName;
            newPerson.PhoneNumber = person.PhoneNumber;
            newPerson.City = person.City;

            listOfPeople.Add(newPerson);
            return newPerson;
        }

        public List<Person> Read()
        {
            return listOfPeople;
        }

        public Person Read(int id)
        {
            return listOfPeople.SingleOrDefault(c => c.Id == id);
        }

        public bool Delete(int id)
        {
            Person original = Read(id);

            if(original == null)
            {
                return false;
            }

            return listOfPeople.Remove(original);
        }
    }
}
