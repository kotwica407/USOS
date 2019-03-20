using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using USOS.Models;
using USOS.Models.Subjects;
using USOSData.Interfaces;
using USOSData.Models;

namespace USOS.Controllers
{
    public class SubjectsController : Controller
    {
        private IUsosSubject _subjects;

        public SubjectsController(IUsosSubject subject)
        {
            _subjects = subject;
        }

        public IActionResult Index()
        {
            var subjectModels = _subjects.GetAll();
            var listingResult = subjectModels
                .Select(result => new SubjectIndexListingModel
                {
                    Id = result.Id,
                    Name = _subjects.GetName(result.Id)
                });
            var model = new SubjectIndexModel
            {
                Subjects = listingResult
            };
            return View(model);
        }
    }
}
