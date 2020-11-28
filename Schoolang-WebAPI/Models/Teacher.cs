using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schoolang_WebAPI.Models
{
    public class Teacher
    {
        public Teacher() { }
        public Teacher(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Language> Languages { get; set; }
    }
}
