using System;
using System.Collections.Generic;
using System.Text;
using USOSData.Models;

namespace USOSData.Interfaces
{
    public interface IUsosSemester_Student
    {
        void AddStudentToSemester(Semester semester, Student student);

        IEnumerable<Semester_Student> GetAll();
        Semester_Student GetById(int StudentId, int SemesterId);
        IEnumerable<Semester> GetSemesters(int StudentId);
        IEnumerable<Student> GetStudents(int SemesterId);
    }
}
