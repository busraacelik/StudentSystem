using Microsoft.EntityFrameworkCore;
using StudentSystem.Context;
using StudentSystem.Models;
using StudentSystem.REPO.Contracts;

namespace StudentSystem.REPO.Concretes
{
    public class LessonRepo : BaseRepo<Lesson>, ILessonRepo
    {
        private readonly AppDbContext _context;
        public LessonRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public Lesson? GetLessonCode(string code, bool track = true)=> track ? 
            _context.Set<Lesson>().FirstOrDefault(l => l.LessonCode.ToString() == code) : 
            _context.Set<Lesson>().AsNoTracking().FirstOrDefault(l => l.LessonCode.ToString() == code);

        public IQueryable<Lesson> GetLessonsName(string name, bool track = true) => track ? 
            _context.Set<Lesson>().Where(l => l.Name.Contains(name)) : 
            _context.Set<Lesson>().AsNoTracking().Where(l => l.Name.Contains(name));
        public void Add(Lesson lesson)
        {
            _context.Lessons.Add(lesson);
        }

    }
}
