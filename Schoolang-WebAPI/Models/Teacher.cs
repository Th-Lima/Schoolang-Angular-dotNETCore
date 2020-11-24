using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schoolang_WebAPI.Models
{
    public class Teacher
    {
        public Teacher() { }
        public Teacher(int id, string name, string language)
        {
            Id = id;
            Name = name;
            Language = language;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
    }
}
