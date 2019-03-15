using System;
using System.Collections.Generic;
using System.Text;
using USOSData.Models;

namespace USOSData.Interfaces
{
    public interface IUsosTeacher
    {
        IEnumerable<Teacher> GetAll();
        Teacher GetById(int id);

        void Add(Teacher newTeacher);

        string GetFirstName(int id);
        string GetLastName(int id);
        string GetAddress(int id);
        string GetTelephoneNumber(int id);
        string GetPesel(int id);
        string GetEmail(int id);

        IEnumerable<Activity> GetActivities(int id);
    }
}
