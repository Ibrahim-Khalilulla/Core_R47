using Core_R47.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_R47.Repository
{
    public interface ITeachers
    {
        
            IEnumerable<teachers> GetAll();
            teachers Get(int id);
        }

    
}
