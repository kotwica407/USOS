using System;
using System.Collections.Generic;
using System.Text;
using USOSData.Models;

namespace USOSData.Interfaces
{
    public interface IUsosStudent
    {
        IEnumerable<Student> GetAll();
        Student GetById(int id);
        Student GetByIndexNumber(string indexNumber);

        void Add(Student newStudent);
        void Remove(int id);
        void Update(Student student);

        string GetFirstName(int id);
        string GetLastName(int id);
        string GetAddress(int id);
        string GetTelephoneNumber(int id);
        string GetPesel(int id);
        string GetEmail(int id);
        string GetIndexNumber(int id);
    }
}
