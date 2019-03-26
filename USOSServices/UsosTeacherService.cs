using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USOSData;
using USOSData.Interfaces;
using USOSData.Models;

namespace USOSServices
{
    public class UsosTeacherService : IUsosTeacher
    {
        private USOSContext _context;

        public UsosTeacherService(USOSContext context)
        {
            _context = context;
        }

        public void Add(Teacher newTeacher)
        {
            _context.Add(newTeacher);
            _context.SaveChanges();
        }

        public IEnumerable<Activity> GetActivities(int id)
        {
            return GetById(id).Activities;
        }

        public string GetAddress(int id)
        {
            return GetById(id).Address;
        }

        public IEnumerable<Teacher> GetAll()
        {
            return _context.Teachers.Include(a => a.Activities);
        }

        public Teacher GetById(int id)
        {
            return GetAll()
                .FirstOrDefault(a => a.Id == id);
        }

        public string GetEmail(int id)
        {
            return GetById(id).Email;
        }

        public string GetFirstName(int id)
        {
            return GetById(id).FirstName;
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
            Teacher teacher = GetById(id);
            _context.Teachers.Remove(teacher);
            _context.SaveChanges();
        }

        public void Update(Teacher teacher)
        {
            Teacher s = GetById(teacher.Id);
            s.Address = teacher.Address;
            s.Email = teacher.Email;
            s.FirstName = teacher.FirstName;
            s.LastName = teacher.LastName;
            s.Login = teacher.Login;
            s.Password = teacher.Password;
            s.Pesel = teacher.Pesel;
            s.TelephoneNumber = teacher.TelephoneNumber;
            s.Activities = teacher.Activities;

            _context.SaveChanges();
        }
    }
}
