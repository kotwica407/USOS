using System;
using System.Collections.Generic;
using System.Text;
using USOSData.Models;

namespace USOSData.Interfaces
{
    public interface IUsosSubject
    {
        IEnumerable<Subject> GetAll();
        Subject GetById(int id);
        IEnumerable<Subject> GetBySemester(int semesterId);

        void Add(Subject newSubject);

        string GetName(int id);
        Semester GetSemester(int id);
        IEnumerable<Activity> GetActivities(int id);
    }
}
