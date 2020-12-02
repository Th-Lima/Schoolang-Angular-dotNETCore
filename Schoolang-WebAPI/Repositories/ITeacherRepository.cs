using Schoolang_WebAPI.Models;
using System.Threading.Tasks;

namespace Schoolang_WebAPI.Repositories
{
    public interface ITeacherRepository
    {
        void Add(Teacher teacher);
        void Update(Teacher teacher);
        void Delete(Teacher teacher);
        Task<Teacher[]> GetAllTeachersAsync(bool includeLanguages);
        Task<Teacher> GetTeachersAsyncById(int teacherId, bool includeLanguages);
        Task<Teacher[]> GetTeachersAsyncByStudentId(int studentId, bool includeLanguage);
        Task<bool> SaveChangesAsync();
    }
}
