using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using USOS.Models;
using USOS.Models.Students;
using USOSData;
using USOSData.Interfaces;
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

        public IActionResult Detail(int id)
        {
            var student = _students.GetById(id);

            var model = new StudentDetailModel
            {
                Id = id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Address = student.Address,
                Email = student.Email,
                IndexNumber = student.IndexNumber,
                Pesel = student.Pesel,
                TelephoneNumber = student.TelephoneNumber,
                Semester_Students = student.Semester_Students,
                Student_Activities = student.Student_Activities
            };
            return View(model);
        }

        public IActionResult Create()
        {
            return View("Create", new Student());
        }

        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            _students.Add(student);
            return RedirectToAction("Index", "Students");
        }

        [HttpPost]
        public bool Delete(int id)
        {
            try
            {
                _students.Remove(id);
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public IActionResult Update(int id)
        {
            return View("Update", _students.GetById(id));
        }

        [HttpPost]
        public IActionResult UpdateStudent(Student student)
        {
            _students.Update(student);

            return RedirectToAction("Index", "Students");
        }
    }
}