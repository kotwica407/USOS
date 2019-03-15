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
    public class UsosStudent_ActivityService : IUsosStudent_Activity
    {
        private USOSContext _context;

        public UsosStudent_ActivityService(USOSContext context)
        {
            _context = context;
        }

        public void AddStudentToActivity(Activity activity, Student student)
        {
            _context.Add(new Student_Activity
            {
                StudentId = student.Id,
                ActivityId = activity.Id,
                Student = student,
                Activity = activity,
            });
            _context.SaveChanges();
        }

        public IEnumerable<Activity> GetActivities(int StudentId)
        {
            return _context.Activities
                .FromSql("SELECT * FROM [dbo].[Activities] WHERE [dbo].[Students].[Id]==" + $"{StudentId}");
        }

        public IEnumerable<Student_Activity> GetAll()
        {
            return _context.Student_Activities
                .Include(s => s.Student)
                .Include(s => s.Activity);
        }

        public Student_Activity GetById(int StudentId, int ActivityId)
        {
            return GetAll()
                .Where(s => s.Activity.Id == ActivityId)
                .FirstOrDefault(s => s.Student.Id == StudentId);
        }

        public decimal GetGrade(int StudentId, int ActivityId)
        {
            return GetById(StudentId, ActivityId).Grade;
        }

        public IEnumerable<Student> GetStudents(int ActivityId)
        {
            return _context.Students
                .FromSql("SELECT * FROM [dbo].[Students] WHERE [dbo].[Activities].[Id]=="+$"{ActivityId}");
        }
    }
}
