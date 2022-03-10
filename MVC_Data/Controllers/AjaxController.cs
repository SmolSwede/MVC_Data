using Microsoft.AspNetCore.Mvc;
using MVC_Data.Services;
using MVC_Data.Models;
using MVC_Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data.Controllers
{
    public class AjaxController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetPeople()
        {
            InMemoryPerson inMemoryPerson = new InMemoryPerson();
            List<Person> peopleList = inMemoryPerson.Read();

            return PartialView("PeopleListPartialView", peopleList);
        }

        [HttpPost]
        public IActionResult FindPersonById(int personId)
        {
            InMemoryPerson inMemoryPerson = new InMemoryPerson();
            Person targetPerson = inMemoryPerson.Read(personId);
            List<Person> people = new List<Person>();
            if(targetPerson != null)
            {
                people.Add(targetPerson);
            }

            return PartialView("PeopleListPartialView", people);
        }

        [HttpPost]
        public IActionResult DeletePersonById(int personId)
        {
            InMemoryPerson inMemoryPerson = new InMemoryPerson();
            Person targetPerson = inMemoryPerson.Read(personId);
            bool success = false;
            if(targetPerson != null)
            {
                success = inMemoryPerson.Delete(personId);
            }
            if (success)
            {
                return StatusCode(200);
            }
            return StatusCode(404);
        }
    }
}
