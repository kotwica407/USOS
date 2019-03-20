using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using USOSData.Models;

namespace USOS.Models.Teachers
{
    public class TeacherDetailModel : UserDetailModel
    {
        public IEnumerable<Activity> Activities { get; set; }
    }
}
