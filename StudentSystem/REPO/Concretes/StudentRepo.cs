using Microsoft.EntityFrameworkCore;
using StudentSystem.Context;
using StudentSystem.Models;
using StudentSystem.REPO.Contracts;

namespace StudentSystem.REPO.Concretes
{
    public class StudentRepo : BaseRepo<Student>, IStudentRepo
    {
        private readonly AppDbContext _context;
        public StudentRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public Student? GetStudentId(int id, bool track = true)=>track? _context.Set<Student>().Find(id) : _context.Set<Student>().AsNoTracking().FirstOrDefault(s => s.Id == id);

        public IQueryable<Student> GetStudentsByName(string name, bool track = true) => track
       ? _context.Set<Student>().Where(s => s.FullName.Contains(name))
       : _context.Set<Student>().AsNoTracking().Where(s => s.FullName.Contains(name));


        public void Add(Student student)
        {
            _context.Students.Add(student);
            // SaveChanges burada ya da UnitOfWork'te yapılmalı.
        }

    }

}
    
