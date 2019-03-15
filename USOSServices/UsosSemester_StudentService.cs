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
    public class UsosSemester_StudentService : IUsosSemester_Student
    {
        private USOSContext _context;

        public UsosSemester_StudentService(USOSContext context)
        {
            _context = context;
        }

        public void AddStudentToSemester(Semester semester, Student student)
        {
            _context.Add(new Semester_Student
            {
                StudentId = student.Id,
                SemesterId = semester.Id,
                Student = student,
                Semester = semester,
            });
            _context.SaveChanges();
        }

        public IEnumerable<Semester_Student> GetAll()
        {
            return _context.Semester_Students
                .Include(s => s.Semester)
                .Include(s => s.Student);
        }

        public Semester_Student GetById(int StudentId, int SemesterId)
        {
            return GetAll()
                .Where(s => s.Semester.Id == SemesterId)
                .FirstOrDefault(s => s.Student.Id == StudentId);
        }

        public IEnumerable<Semester> GetSemesters(int StudentId)
        {
            return _context.Semesters
                .FromSql("SELECT * FROM [dbo].[Semesters] WHERE [dbo].[Students].[Id]==" + $"{StudentId}");
        }

        public IEnumerable<Student> GetStudents(int SemesterId)
        {
            return _context.Students
                .FromSql("SELECT * FROM [dbo].[Students] WHERE [dbo].[Semesters].[Id]==" + $"{SemesterId}");
        }
    }
}
