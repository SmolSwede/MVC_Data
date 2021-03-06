using MVC_Data.Models;
using MVC_Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data.Services
{
    public class PersonService
    {
        private readonly InMemoryPerson _inMemoryPerson;

        public PersonService()
        {
            _inMemoryPerson = new InMemoryPerson();
        }

        public Person Add(PersonCreateViewModel personVM)
        {
            if(string.IsNullOrWhiteSpace(personVM.FirstName) || string.IsNullOrWhiteSpace(personVM.LastName)
               || string.IsNullOrWhiteSpace(personVM.PhoneNumber) || string.IsNullOrWhiteSpace(personVM.City))
            {
                return null;
            }

            Person newPerson = new Person()
            {
                FirstName = personVM.FirstName,
                LastName = personVM.LastName,
                PhoneNumber = personVM.PhoneNumber,
                City = personVM.City
            };

            Person person = _inMemoryPerson.Create(newPerson);

            return person;
        }

        public List<Person> Search(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return new List<Person>();
            }

            var list = _inMemoryPerson.Read();

            List<Person> matches = new List<Person>();

            foreach (var item in list)
            {
                if(item.FirstName.Contains(text) || item.LastName.Contains(text) || item.PhoneNumber.Contains(text) || item.City.Contains(text))
                {
                    matches.Add(item);
                }
            }

            return matches;
        }

        public List<Person> GetPeople()
        {
            return _inMemoryPerson.Read();
        }

        public bool Delete(int id)
        {
            return _inMemoryPerson.Delete(id);
        }


    }
}
