using StudentSystem.Context;
using StudentSystem.REPO.Concretes;
using StudentSystem.REPO.Contracts;

namespace StudentSystem.REPO.UnitOfWork
{
    public class UnitofWork : IUnitofWork
    {
        private readonly AppDbContext _context;
        private readonly Lazy<IStudentRepo> _studentRepo;
        private readonly Lazy<ILessonRepo> _lessonRepo;

        public UnitofWork(AppDbContext context)
        {
            _context = context;
            _studentRepo = new Lazy<IStudentRepo>(() => new StudentRepo(_context));
            _lessonRepo = new Lazy<ILessonRepo>(() => new LessonRepo(_context));
        }
        public IStudentRepo Students => _studentRepo.Value;

        public ILessonRepo Lessons => _lessonRepo.Value;
        public int Complete()
        {
            return _context.SaveChanges();
        }
       
    }
}
