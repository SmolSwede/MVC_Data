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
    public class DataController : Controller
    {
        private PersonService _personService;

        public DataController()
        {
            _personService = new PersonService();
        }

        [HttpGet]
        public IActionResult Index()
        {
            InMemoryPerson inMemoryPerson = new InMemoryPerson();
            PersonCreateViewModel createViewModel = new PersonCreateViewModel();
            if (inMemoryPerson.Read().Count() > 0)
            {
                createViewModel.PeopleList = inMemoryPerson.Read();
            }
            
            return View(createViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(PersonCreateViewModel createViewModel)
        {

            if (ModelState.IsValid)
            {
                Person person = _personService.Add(createViewModel);

                if(person != null)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError("Storage", "Failed to save person");
            }
            
            return View(createViewModel);
        }

        public IActionResult Remove(int id)
        {
            _personService.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Search(PersonCreateViewModel createViewModel)
        {
            if (string.IsNullOrWhiteSpace(createViewModel.FilterString))
            {
                createViewModel.PeopleList = _personService.GetPeople();
            }
            else
            {
                createViewModel.PeopleList = _personService.Search(createViewModel.FilterString);
            }

            return View("Index", createViewModel);
        }
    }
}
