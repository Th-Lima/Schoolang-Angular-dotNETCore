using Schoolang_WebAPI.Models;
using System.Threading.Tasks;

namespace Schoolang_WebAPI.Repositories
{
    public interface IRepository
    {
        //GENERAL
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        //STUDENT
        Task<Student[]> GetAllStudentsAsync(bool includeTeacher);
        Task<Student[]> GetStudentsAsyncByLanguageId(int languageId, bool includeLanguage);
        Task<Student> GetStudentsAsyncById(int studentId, bool includeTeacher);

        //TEACHER
        Task<Teacher[]> GetAllTeachersAsync(bool includeStudent);
        Task<Teacher> GetTeachersAsyncById(int teacherId, bool includeStudent);
        Task<Teacher[]> GetTeacherssAsyncByStudentId(int studentId, bool includeLanguage);
    }
}
