using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace USOS.Models.Semesters
{
    public class SemesterIndexModel
    {
        public IEnumerable<SemesterIndexListingModel> Semesters { get; set; }
    }
}
