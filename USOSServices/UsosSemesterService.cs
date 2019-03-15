using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USOSData;
using USOSData.Models;

namespace USOSServices
{
    public class UsosSemesterService : IUsosSemester
    {
        private USOSContext _context;

        public UsosSemesterService(USOSContext context)
        {
            _context = context;
        }

        public void Add(Semester newSemester)
        {
            _context.Add(newSemester);
            _context.SaveChanges();
        }

        public IEnumerable<Semester> GetAll()
        {
            return _context.Semesters
                .Include(a => a.Course)
                .Include(a => a.Subjects)
                .Include(a => a.Semester_Students);
        }

        public IEnumerable<Semester> GetByCourse(int courseId)
        {
            return GetAll()
                .Where(s => s.Course.Id == courseId);
        }

        public Semester GetById(int id)
        {
            return GetAll()
                .FirstOrDefault(s => s.Id == id);
        }

        public Course GetCourse(int id)
        {
            return GetById(id).Course;
        }

        public IEnumerable<Semester_Student> GetSemester_Students(int id)
        {
            return GetById(id).Semester_Students;
        }

        public DateTime GetSince(int id)
        {
            return GetById(id).Since;
        }

        public IEnumerable<Subject> GetSubjects(int id)
        {
            return GetById(id).Subjects;
        }

        public DateTime GetUntil(int id)
        {
            return GetById(id).Until;
        }
    }
}
