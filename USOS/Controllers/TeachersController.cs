using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using USOS.Models;
using USOS.Models.Teachers;
using USOSData;
using USOSData.Interfaces;
using USOSData.Models;

namespace USOS.Controllers
{
    public class TeachersController : Controller
    {
        private IUsosTeacher _teachers;

        public TeachersController(IUsosTeacher teacher)
        {
            _teachers = teacher;
        }

        public IActionResult Index()
        {
            var teacherModels = _teachers.GetAll();
            var listingResult = teacherModels
                .Select(result => new TeacherIndexListingModel
                {
                    Id = result.Id,
                    Address = _teachers.GetAddress(result.Id),
                    Email = _teachers.GetEmail(result.Id),
                    FirstName = _teachers.GetFirstName(result.Id),
                    LastName = _teachers.GetLastName(result.Id),
                    Login = result.Login,
                    Password = result.Password,
                    Pesel = _teachers.GetPesel(result.Id),
                    TelephoneNumber = _teachers.GetTelephoneNumber(result.Id)
                });
            var model = new TeacherIndexModel
            {
                Teachers = listingResult
            };
            return View(model);
        }

        public IActionResult Detail(int id)
        {
            var teacher = _teachers.GetById(id);

            var model = new TeacherDetailModel
            {
                Id = id,
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                Address = teacher.Address,
                Email = teacher.Email,
                Pesel = teacher.Pesel,
                TelephoneNumber = teacher.TelephoneNumber,
                Activities = teacher.Activities
            };
            return View(model);
        }
    }
}
