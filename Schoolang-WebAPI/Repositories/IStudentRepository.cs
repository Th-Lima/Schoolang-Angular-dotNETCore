using Schoolang_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schoolang_WebAPI.Repositories
{
    public interface IStudentRepository
    {
        void Add(Student student);
        void Update(Student student);
        void Delete(Student student);
        Task<bool> SaveChangesAsync();

        Task<Student[]> GetAllStudentsAsync(bool includeTeacher);
        Task<Student[]> GetStudentsAsyncByLanguageId(int languageId, bool includeLanguage);
        Task<Student> GetStudentsAsyncById(int studentId, bool includeTeacher);
    }
}
