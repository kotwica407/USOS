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
    public class UsosActivityService : IUsosActivity
    {
        private USOSContext _context;

        public UsosActivityService(USOSContext context)
        {
            _context = context;
        }

        public void Add(Activity newActivity)
        {
            _context.Add(newActivity);
            _context.SaveChanges();
        }

        public IEnumerable<Activity> GetAll()
        {
            return _context.Activities
                .Include(a => a.Student_Activities);
        }

        public Activity GetById(int id)
        {
            return GetAll()
                .FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Activity> GetByTeacher(int teacherId)
        {
            return GetAll()
                .Where(a => a.Teacher.Id == teacherId);
        }

        public int GetGroup(int id)
        {
            return GetById(id).Group;
        }

        public Teacher GetTeacher(int id)
        {
            return GetById(id).Teacher;
        }

        public string GetType(int id)
        {
            return GetById(id).Type;
        }
    }
}
