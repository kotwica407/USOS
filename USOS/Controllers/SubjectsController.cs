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
        private IUsosActivity _activities;

        public SubjectsController(IUsosSubject subject, IUsosActivity activity)
        {
            _subjects = subject;
            _activities = activity;
        }

        public IActionResult Index()
        {
            var subjectModels = _subjects.GetAll();
            var listingResult = subjectModels
                .Select(result => new SubjectIndexListingModel
                {
                    Id = result.Id,
                    Name = _subjects.GetName(result.Id),
                    Activities = _subjects.GetActivities(result.Id),
                    Semester = _subjects.GetSemester(result.Id)
                });
            var model = new SubjectIndexModel
            {
                Subjects = listingResult
            };
            return View(model);
        }

        public IActionResult Detail(int id)
        {
            var subject = _subjects.GetById(id);
            var model = new SubjectDetailModel
            {
                Id = id,
                Activities = _activities.GetBySubject(id),
                Name = subject.Name,
                Semester = subject.Semester
            };

            return View(model);
        }
    }
}
