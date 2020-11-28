using Microsoft.EntityFrameworkCore;
using Schoolang_WebAPI.Data;
using Schoolang_WebAPI.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Schoolang_WebAPI.Repositories
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Student[]> GetAllStudentsAsync(bool includeTeacher = false)
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
        public async Task<Student> GetStudentsAsyncById(int studentId, bool includeLanguage)
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

        public async Task<Teacher[]> GetTeachersAsyncByStudentId(int studentId, bool includeLanguage)
        {
            IQueryable<Teacher> query = _context.Teachers;

            if (includeLanguage)
            {
                query = query.Include(t => t.Languages);
            }

            query = query.AsNoTracking()
                         .OrderBy(student => student.Id)
                         .Where(student => student.Languages.Any(d =>
                            d.StudentsLanguages.Any(sl => sl.StudentId == studentId)));

            return await query.ToArrayAsync();
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
        public async Task<Teacher> GetTeachersAsyncById(int teacherId, bool includeLanguages = true)
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
    }
}
