using StudentSystem.Models;

namespace StudentSystem.REPO.Contracts
{
    public interface ILessonRepo:IBaseRepo<Lesson>
    {
        void Add(Lesson lesson);
        Lesson? GetLessonCode(string code, bool track = true);
        IQueryable<Lesson>GetLessonsName(string name, bool track = true);
    }
}
