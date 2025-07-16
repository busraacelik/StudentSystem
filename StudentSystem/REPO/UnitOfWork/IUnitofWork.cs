using StudentSystem.REPO.Contracts;

namespace StudentSystem.REPO.UnitOfWork
{
    public interface IUnitofWork
    {
        IStudentRepo Students { get; }
        ILessonRepo Lessons { get; }
        int Complete();
        

    }
}
