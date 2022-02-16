using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data.ViewModels
{
    public class PersonCreateViewModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public int Age { get; set; }

        public string Info { get; set; }

        public PersonCreateViewModel()
        {
        }

        public PersonCreateViewModel(string firstName, string lastName, int age, string info)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Info = info;
        }
    }
}
