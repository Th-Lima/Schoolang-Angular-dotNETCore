using Microsoft.EntityFrameworkCore;
using Schoolang_WebAPI.Data;
using Schoolang_WebAPI.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Schoolang_WebAPI.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly DataContext _context;
        
        public TeacherRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(Teacher teacher)
        {
            _context.Add(teacher);
        }

        public void Update(Teacher teacher)
        {
            _context.Update(teacher);
        }

        public void Delete(Teacher teacher)
        {
            _context.Remove(teacher);
        }

        public async Task<Teacher[]> GetAllTeachersAsync(bool includeLanguages = true)
        {
            IQueryable<Teacher> query = _context.Teachers;

            if (includeLanguages)
            {
                query = query.Include(t => t.Languages);
            }

            query = query.AsNoTracking()
                         .OrderBy(teacher => teacher.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Teacher> GetTeachersAsyncById(int teacherId, bool includeLanguages)
        {
            IQueryable<Teacher> query = _context.Teachers;

            if (includeLanguages)
            {
                query = query.Include(t => t.Languages);
            }

            query = query.AsNoTracking()
                         .OrderBy(teacher => teacher.Id)
                         .Where(teacher => teacher.Id == teacherId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Teacher[]> GetTeachersAsyncByStudentId(int studentId, bool includeLanguage)
        {
            IQueryable<Teacher> query = _context.Teachers;

            if (includeLanguage)
            {
                query = query.Include(t => t.Languages)
                    .ThenInclude(sl => sl.StudentsLanguages)
                    .ThenInclude(l => l.Student);
            }

            query = query.AsNoTracking()
                         .OrderBy(student => student.Id)
                         .Where(student => student.Languages.Any(d =>
                            d.StudentsLanguages.Any(sl => sl.StudentId == studentId)));

            return await query.ToArrayAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
