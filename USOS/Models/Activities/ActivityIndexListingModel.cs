using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using USOSData.Models;

namespace USOS.Models.Activities
{
    public class ActivityIndexListingModel
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int Group { get; set; }
        public Subject Subject { get; set; }
    }
}
