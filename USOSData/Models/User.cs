using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace USOSData.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Login { get; set; }

        [Required]
        [StringLength(30)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(30)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(30)]
        public string LastName { get; set; }

        [StringLength(45)]
        public string Address { get; set; }

        [StringLength(9)]
        [RegularExpression(@"^[0-9]+$")]
        public string TelephoneNumber { get; set; }

        [Required]
        [StringLength(11)]
        [RegularExpression(@"^[0-9]{11}$")]
        public string Pesel { get; set; }

        [Required]
        [StringLength(45)]
        [EmailAddress]
        public string Email { get; set; }
    }
}
