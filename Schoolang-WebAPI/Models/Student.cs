using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schoolang_WebAPI.Models
{
    public class Student
    {
        public Student(){ }
        public Student(int id, string name, string surname, string cellphone)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Cellphone = cellphone;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Cellphone { get; set; }
    }
}
