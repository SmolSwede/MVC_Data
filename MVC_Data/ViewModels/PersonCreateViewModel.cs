using MVC_Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data.ViewModels
{
    public class PersonCreateViewModel
    {
        public int ID { get; set; }

        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "Phone Number")]
        [Required]
        public string PhoneNumber { get; set; }

        [Display(Name = "City")]
        [Required]
        public string City { get; set; }

        public string FilterString { get; set; }

        public List<Person> PeopleList = new List<Person>();

        public int InputID { get; set; }

        public PersonCreateViewModel()
        {
        }

        public PersonCreateViewModel(string firstName, string lastName, string phoneNumber, string city)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            City = city;
        }
    }
}
