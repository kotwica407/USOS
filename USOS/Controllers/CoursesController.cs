using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using USOS.Models;
using USOS.Models.Activities;
using USOS.Models.Courses;
using USOSData.Interfaces;

namespace USOS.Controllers
{
    public class CoursesController : Controller
    {
        private IUsosCourse _courses;

        public CoursesController(IUsosCourse course)
        {
            _courses = course;
        }

        public IActionResult Index()
        {
            var courseModels = _courses.GetAll();
            var listingResult = courseModels
                .Select(result => new CourseIndexListingModel
                {
                    Id = result.Id,
                    Name = _courses.GetName(result.Id),
                    StartYear = _courses.GetStartYear(result.Id)
                });
            var model = new CourseIndexModel
            {
                Courses = listingResult
            };
            return View(model);
        }
    }
}
