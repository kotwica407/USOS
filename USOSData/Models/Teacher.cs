using System;
using System.Collections.Generic;
using System.Text;

namespace USOSData.Models
{
    public class Teacher : User
    {
        public ICollection<Activity> Activities { get; set; }
    }
}
