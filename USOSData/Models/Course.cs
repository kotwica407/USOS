using System.ComponentModel.DataAnnotations;

namespace USOSData.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        public int StartYear { get; set; }
    }
}