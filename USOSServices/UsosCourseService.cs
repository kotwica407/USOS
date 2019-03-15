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
    public class UsosCourseService : IUsosCourse
    {
        private USOSContext _context;

        public UsosCourseService(USOSContext context)
        {
            _context = context;
        }

        public void Add(Course newCourse)
        {
            _context.Add(newCourse);
            _context.SaveChanges();
        }

        public IEnumerable<Course> GetAll()
        {
            return _context.Courses;
        }

        public Course GetById(int id)
        {
            return GetAll()
                .FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Course> GetByName(string name)
        {
            return GetAll()
                .Where(c => c.Name == name);
        }

        public IEnumerable<Course> GetByStartYear(int startyear)
        {
            return GetAll()
                .Where(c => c.StartYear == startyear);
        }

        public string GetName(int id)
        {
            return GetById(id).Name;
        }

        public int GetStartYear(int id)
        {
            return GetById(id).StartYear;
        }
    }
}
