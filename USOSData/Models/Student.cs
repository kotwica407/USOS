using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace USOSData.Models
{
    public class Student : User
    {
        [Required]
        [Display(Name = "Index Number")]
        [StringLength(6)]
        [RegularExpression(@"^[0-9]+$")]
        public string IndexNumber { get; set; }

        public virtual IEnumerable<Semester_Student> Semester_Students { get; set; }
        
        public virtual IEnumerable<Student_Activity> Student_Activities { get; set; }
    }
}
