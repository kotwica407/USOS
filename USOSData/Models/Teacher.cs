using System;
using System.Collections.Generic;
using System.Text;

namespace USOSData.Models
{
    public class Teacher : User
    {
        public IEnumerable<Activity> Activities { get; set; }
    }
}
