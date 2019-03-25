using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using USOSData;
using USOSData.Interfaces;
using USOSData.Models;

namespace USOSServices
{
    public class UsosStudentService : IUsosStudent
    {
        private USOSContext _context;

        public UsosStudentService(USOSContext context)
        {
            _context = context;
        }

        public void Add(Student newStudent)
        {
            _context.Add(newStudent);
            _context.SaveChanges();
        }

        public string GetAddress(int id)
        {
            return GetById(id).Address;
        }

        public IEnumerable<Student> GetAll()
        {
            return _context.Students
                .Include(a => a.Semester_Students)
                .Include(a => a.Student_Activities);
        }

        public Student GetById(int id)
        {
            return GetAll()
                .FirstOrDefault(a => a.Id == id);
        }

        public Student GetByIndexNumber(string indexNumber)
        {
            return GetAll()
                .FirstOrDefault(s => s.IndexNumber == indexNumber);
        }

        public string GetEmail(int id)
        {
            return GetById(id).Email;
        }

        public string GetFirstName(int id)
        {
            return GetById(id).FirstName;
        }

        public string GetIndexNumber(int id)
        {
            return GetById(id).IndexNumber;
        }

        public string GetLastName(int id)
        {
            return GetById(id).LastName;
        }

        public string GetPesel(int id)
        {
            return GetById(id).Pesel;
        }

        public string GetTelephoneNumber(int id)
        {
            return GetById(id).TelephoneNumber;
        }

        public void Remove(int id)
        {
            Student student = GetById(id);
            _context.Students.Remove(student);
            _context.SaveChanges();
        }

        public void Update(Student student)
        {
            Student s = GetById(student.Id);
            s.Address = student.Address;
            s.Email = student.Email;
            s.FirstName = student.FirstName;
            s.LastName = student.LastName;
            s.Login = student.Login;
            s.Password = student.Password;
            s.Pesel = student.Pesel;
            s.Semester_Students = student.Semester_Students;
            s.Student_Activities = student.Student_Activities;
            s.TelephoneNumber = student.TelephoneNumber;
            s.IndexNumber = student.IndexNumber;

            _context.SaveChanges();
        }
    }
}
