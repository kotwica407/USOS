using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using USOS.Models;
using USOS.Models.Semesters;
using USOSData.Interfaces;

namespace USOS.Controllers
{
    public class SemestersController : Controller
    {
        private IUsosSemester _semesters;

        public SemestersController(IUsosSemester semester)
        {
            _semesters = semester;
        }

        public IActionResult Index()
        {
            var semesterModels = _semesters.GetAll();
            var listingResult = semesterModels
                .Select(result => new SemesterIndexListingModel
                {
                    Id = result.Id,
                    Since = _semesters.GetSince(result.Id),
                    Until = _semesters.GetUntil(result.Id)
                });
            var model = new SemesterIndexModel
            {
                Semesters = listingResult
            };
            return View(model);
        }
    }
}
