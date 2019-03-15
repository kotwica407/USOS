using System;
using System.Collections.Generic;
using System.Text;
using USOSData.Models;

namespace USOSData
{
    public interface IUsosStudent_Activity
    {
        void AddStudentToActivity(Activity activity, Student student);

        IEnumerable<Student_Activity> GetAll();
        Student_Activity GetById(int StudentId, int ActivityId);
        IEnumerable<Activity> GetActivities(int StudentId);
        IEnumerable<Student> GetStudents(int ActivityId);

        decimal GetGrade(int StudentId, int ActivityId);
    }
}
