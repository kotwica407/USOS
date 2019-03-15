using System.Collections.Generic;
using USOSData.Models;

namespace USOSData
{
    public interface IUsosActivity
    {
        IEnumerable<Activity> GetAll();
        Activity GetById(int id);

        void Add(Activity newActivity);

        string GetType(int id);
        int GetGroup(int id);
        Teacher GetTeacher(int id);
    }
}
