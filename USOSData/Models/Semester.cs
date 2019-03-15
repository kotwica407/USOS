using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace USOSData.Models
{
    public class Semester
    { 

        public int Id { get; set; }

        [Required]
        public Course Course { get; set; }

        [Required]
        [Display(Name = "First day of semester")]
        public DateTime Since { get; set; }

        [Required]
        [Display(Name = "Last day of semester")]
        public DateTime Until { get; set; }

        public virtual IEnumerable<Semester_Student> Semester_Students { get; set; }

        public IEnumerable<Subject> Subjects { get; set; }
    }
}