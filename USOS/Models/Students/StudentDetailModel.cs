using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using USOSData.Models;

namespace USOS.Models.Students
{
    public class StudentDetailModel : UserDetailModel
    {
        public string IndexNumber { get; set; }

        public IEnumerable<Semester_Student> Semester_Students { get; set; }
        public IEnumerable<Student_Activity> Student_Activities { get; set; }
    }
}
