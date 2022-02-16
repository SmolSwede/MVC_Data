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
        string searchText;
        public DataController()
        {
            _personService = new PersonService();
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.personServiceGetPeople = _personService.GetPeople();
            ViewBag.personServiceSearch = _personService.Search(searchText);
            ViewBag.searchText = searchText;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(PersonCreateViewModel createViewModel)
        {
            ViewBag.personServiceGetPeople = _personService.GetPeople();
            ViewBag.personServiceSearch = _personService.Search(searchText);
            ViewBag.searchText = searchText;

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

        [HttpGet]
        public IActionResult Search(string inputSearchText)
        {
            searchText = inputSearchText;

            return RedirectToAction(nameof(Index));
        }
    }
}
