using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schoolang_WebAPI.Models
{
    public class StudentLanguage
    {
        public StudentLanguage() { }

        public StudentLanguage(int studentId, int languageId)
        {
            StudentId = studentId;
            LanguageId = languageId;
        }

        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }
    }
}
