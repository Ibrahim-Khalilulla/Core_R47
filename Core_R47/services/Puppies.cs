using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_R47.services
{
    public class PuppyService
    {
        public Puppy Adopt()
        {
            return new Puppy { Name = "Clifford" };
        }
    }

    public class Puppy
    {
        public string Name { get; set; }
    }
}
