using Core_R47.Data;
using Core_R47.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_R47.Repository
{
    public class teacherscls:ITeachers
    {
        DBContextContext db;
        public teacherscls(DBContextContext a)
        {
            db = a;
        }
        public IEnumerable<teachers> GetAll()
        {
            var a = db.teachers.ToList();
            return a;
        }
        public teachers Get(int id)
        {
            var a = db.teachers.ToList();
            return a.FirstOrDefault(x => x.ID == id);
        }

    }
}
