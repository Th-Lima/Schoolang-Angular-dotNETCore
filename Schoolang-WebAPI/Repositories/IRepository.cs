using Schoolang_WebAPI.Models;
using System.Threading.Tasks;

namespace Schoolang_WebAPI.Repositories
{
    interface IRepository
    {
        //GENERAL
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        //STUDENT
        Task<Student[]> GetAllAlunosAsync(bool includeTeacher);
        Task<Student[]> GetAlunosAsyncByDisciplinaId(int languageId, bool includeLanguage);
        Task<Student> GetAlunoAsyncById(int studentId, bool includeTeacher);

        //TEACHER
        Task<Teacher[]> GetAllProfessoresAsync(bool includeStudent);
        Task<Teacher> GetProfessorAsyncById(int teacherId, bool includeStudent);
        Task<Teacher[]> GetProfessoresAsyncByAlunoId(int studentId, bool includeLanguage);
    }
}
