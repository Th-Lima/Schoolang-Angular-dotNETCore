using Microsoft.EntityFrameworkCore;
using Schoolang_WebAPI.Data;
using Schoolang_WebAPI.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Schoolang_WebAPI.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DataContext _context;

        public StudentRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(Student student)
        {
            _context.Add(student);
        }

        public void Update(Student student)
        {
            _context.Update(student);
        }

        public void Delete(Student student)
        {
            _context.Remove(student);
        }

        public async Task<Student[]> GetAllStudentsAsync(bool includeTeacher)
        {
            IQueryable<Student> query = _context.Students;

            if (includeTeacher)
            {
                query = query.Include(s => s.StudentLanguages)
                             .ThenInclude(sl => sl.Language)
                             .ThenInclude(l => l.Teacher);
            }

            query = query.AsNoTracking()
                         .OrderBy(c => c.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Student> GetStudentsAsyncById(int studentId, bool includeTeacher)
        {
            IQueryable<Student> query = _context.Students;

            if (includeTeacher)
            {
                query = query.Include(s => s.StudentLanguages)
                             .ThenInclude(sl => sl.Language)
                             .ThenInclude(l => l.Teacher);
            }

            query = query.AsNoTracking()
                         .OrderBy(student => student.Id)
                         .Where(student => student.Id == studentId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Student[]> GetStudentsAsyncByLanguageId(int languageId, bool includeLanguage)
        {
            IQueryable<Student> query = _context.Students;

            if (includeLanguage)
            {
                query = query.Include(s => s.StudentLanguages)
                             .ThenInclude(sl => sl.Language)
                             .ThenInclude(l => l.Teacher);
            }

            query = query.AsNoTracking()
                         .OrderBy(student => student.Id)
                         .Where(student => student.StudentLanguages.Any(sl => sl.LanguageId == languageId));

            return await query.ToArrayAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
