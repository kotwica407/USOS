using System.Collections.Generic;
using USOSData.Models;

namespace USOSData.Interfaces
{
    public interface IUsosActivity
    {
        IEnumerable<Activity> GetAll();
        Activity GetById(int id);
        IEnumerable<Activity> GetByTeacher(int teacherId);
        IEnumerable<Activity> GetBySubject(int subjectId);

        void Add(Activity newActivity);

        string GetType(int id);
        int GetGroup(int id);
        Teacher GetTeacher(int id);
        Subject GetSubject(int id);
    }
}
