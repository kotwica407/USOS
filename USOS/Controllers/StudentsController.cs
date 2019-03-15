using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using USOS.Models;
using USOSData;
using USOSData.Models;

namespace USOS.Controllers
{
    public class StudentsController : Controller
    {
        private IUsosStudent _students;

        public StudentsController(IUsosStudent student)
        {
            _students = student;
        }

        public IActionResult Index()
        {
            var studentModels = _students.GetAll();
            var listingResult = studentModels
                .Select(result => new StudentIndexListingModel
                {
                    Id = result.Id,
                    Address = _students.GetAddress(result.Id),
                    Email = _students.GetEmail(result.Id),
                    FirstName = _students.GetFirstName(result.Id),
                    IndexNumber = _students.GetIndexNumber(result.Id),
                    LastName = _students.GetLastName(result.Id),
                    Login = result.Login,
                    Password = result.Password,
                    Pesel = _students.GetPesel(result.Id),
                    TelephoneNumber = _students.GetTelephoneNumber(result.Id)
                });
            var model = new StudentIndexModel
            {
                Students = listingResult
            };
            return View(model);
        }
    }
}