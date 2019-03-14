using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace USOSData.Models
{
    public class Activity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Type { get; set; }

        [Required]
        [Range(1, 15)]
        public int Group { get; set; }

        public Teacher Teacher { get; set; }

        public virtual ICollection<Student_Activity> Student_Activities { get; set; }
    }
}