namespace USOSData.Models
{
    public class Student_Activity
    {
        public int StudentId { get; set; }
        public int ActivityId { get; set; }
        public virtual Activity Activity { get; set; }
        public virtual Student Student { get; set; }

        public decimal Grade { get; set; }
    }
}