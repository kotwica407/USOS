﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using USOSData.Models;

namespace USOS.Models.Subjects
{
    public class SubjectIndexListingModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Activity> Activities { get; set; }
        public Semester Semester { get; set; }
    }
}
