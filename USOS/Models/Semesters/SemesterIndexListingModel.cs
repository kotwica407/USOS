using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace USOS.Models.Semesters
{
    public class SemesterIndexListingModel
    {
        public int Id { get; set; }
        public DateTime Since { get; set; }
        public DateTime Until { get; set; }
    }
}
