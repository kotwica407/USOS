using System;
using System.Collections.Generic;
using System.Text;
using USOSData.Models;

namespace USOSData
{
    public interface IUsosStudent
    {
        IEnumerable<Student> GetAll();
        Student GetById(int id);

        void Add(Student newStudent);

        string GetFirstName(int id);
        string GetLastName(int id);
        string GetAddress(int id);
        string GetTelephoneNumber(int id);
        string GetPesel(int id);
        string GetEmail(int id);
        string GetIndexNumber(int id);
    }
}
