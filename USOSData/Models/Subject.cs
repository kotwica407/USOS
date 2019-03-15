using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace USOSData.Models
{
    public class Subject
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Subject's name")]
        [StringLength(30)]
        public string Name { get; set; }

        public Semester Semester { get; set; }

        public IEnumerable<Activity> Activities { get; set; } 
    }
}