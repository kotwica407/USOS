namespace USOSData.Models
{
    public class Semester_Student
    {
        public int StudentId { get; set; }
        public int SemesterId { get; set; }
        public virtual Student Student { get; set; }
        public virtual Semester Semester { get; set; }
    }
}