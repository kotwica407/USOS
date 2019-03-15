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
    public class UsosSubjectService : IUsosSubject
    {
        private USOSContext _context;

        public UsosSubjectService(USOSContext context)
        {
            _context = context;
        }

        public void Add(Subject newSubject)
        {
            _context.Add(newSubject);
            _context.SaveChanges();
        }

        public IEnumerable<Activity> GetActivities(int id)
        {
            return GetById(id).Activities;
        }

        public IEnumerable<Subject> GetAll()
        {
            return _context.Subjects
                .Include(s => s.Activities)
                .Include(s => s.Semester);
        }

        public Subject GetById(int id)
        {
            return GetAll()
                .FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<Subject> GetBySemester(int semesterId)
        {
            return GetAll()
                .Where(s => s.Semester.Id == semesterId);
        }

        public string GetName(int id)
        {
            return GetById(id).Name;
        }

        public Semester GetSemester(int id)
        {
            return GetById(id).Semester;
        }
    }
}
