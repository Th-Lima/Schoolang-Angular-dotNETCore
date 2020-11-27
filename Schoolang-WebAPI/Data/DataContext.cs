using Microsoft.EntityFrameworkCore;
using Schoolang_WebAPI.Models;
using System.Collections.Generic;

namespace Schoolang_WebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<StudentLanguage> StudentLanguages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<StudentLanguage>()
                .HasKey(AD => new { AD.StudentId, AD.LanguageId });

            builder.Entity<Teacher>()
                .HasData(new List<Teacher>(){
                    new Teacher(1, "Lauro"),
                    new Teacher(2, "Roberto"),
                    new Teacher(3, "Ronaldo"),
                    new Teacher(4, "Rodrigo"),
                    new Teacher(5, "Alexandre"),
                });

            builder.Entity<Language>()
                .HasData(new List<Language>{
                    new Language(1, "Francês", 1),
                    new Language(2, "Italiano", 2),
                    new Language(3, "Português", 3),
                    new Language(4, "Inglês", 4),
                    new Language(5, "Alemão", 5),
                });

            builder.Entity<Student>()
                .HasData(new List<Student>(){
                    new Student(1, "Marta", "Kent", "33225555"),
                    new Student(2, "Paula", "Isabela", "3354288"),
                    new Student(3, "Laura", "Antonia", "55668899"),
                    new Student(4, "Luiza", "Maria", "6565659"),
                    new Student(5, "Lucas", "Machado", "565685415"),
                    new Student(6, "Pedro", "Alvares", "456454545"),
                    new Student(7, "Paulo", "José", "9874512")
                });

            builder.Entity<StudentLanguage>()
                .HasData(new List<StudentLanguage>() {
                    new StudentLanguage() {StudentId = 1, LanguageId = 2 },
                    new StudentLanguage() {StudentId = 1, LanguageId = 4 },
                    new StudentLanguage() {StudentId = 1, LanguageId = 5 },
                    new StudentLanguage() {StudentId = 2, LanguageId = 1 },
                    new StudentLanguage() {StudentId = 2, LanguageId = 2 },
                    new StudentLanguage() {StudentId = 2, LanguageId = 5 },
                    new StudentLanguage() {StudentId = 3, LanguageId = 1 },
                    new StudentLanguage() {StudentId = 3, LanguageId = 2 },
                    new StudentLanguage() {StudentId = 3, LanguageId = 3 },
                    new StudentLanguage() {StudentId = 4, LanguageId = 1 },
                    new StudentLanguage() {StudentId = 4, LanguageId = 4 },
                    new StudentLanguage() {StudentId = 4, LanguageId = 5 },
                    new StudentLanguage() {StudentId = 5, LanguageId = 4 },
                    new StudentLanguage() {StudentId = 5, LanguageId = 5 },
                    new StudentLanguage() {StudentId = 6, LanguageId = 1 },
                    new StudentLanguage() {StudentId = 6, LanguageId = 2 },
                    new StudentLanguage() {StudentId = 6, LanguageId = 3 },
                    new StudentLanguage() {StudentId = 6, LanguageId = 4 },
                    new StudentLanguage() {StudentId = 7, LanguageId = 1 },
                    new StudentLanguage() {StudentId = 7, LanguageId = 2 },
                    new StudentLanguage() {StudentId = 7, LanguageId = 3 },
                    new StudentLanguage() {StudentId = 7, LanguageId = 4 },
                    new StudentLanguage() {StudentId = 7, LanguageId = 5 }
                });
        }
    }
}

