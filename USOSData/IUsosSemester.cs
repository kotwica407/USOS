using System;
using System.Collections.Generic;
using System.Text;
using USOSData.Models;

namespace USOSData
{
    public interface IUsosSemester
    {
        IEnumerable<Semester> GetAll();
        Semester GetById(int id);
        IEnumerable<Semester> GetByCourse(int courseId);

        void Add(Semester newSemester);

        Course GetCourse(int id);
        DateTime GetSince(int id);
        DateTime GetUntil(int id);

        IEnumerable<Semester_Student> GetSemester_Students(int id);
        IEnumerable<Subject> GetSubjects(int id);
    }
}
