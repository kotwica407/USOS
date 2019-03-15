using System;
using System.Collections.Generic;
using System.Text;
using USOSData.Models;

namespace USOSData.Interfaces
{
    public interface IUsosCourse
    {
        IEnumerable<Course> GetAll();
        Course GetById(int id);
        IEnumerable<Course> GetByName(string name);
        IEnumerable<Course> GetByStartYear(int startyear);

        void Add(Course newCourse);

        string GetName(int id);
        int GetStartYear(int id);
    }
}
