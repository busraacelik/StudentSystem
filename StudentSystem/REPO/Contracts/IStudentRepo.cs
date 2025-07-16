using StudentSystem.Models;

namespace StudentSystem.REPO.Contracts
{
    public interface IStudentRepo:IBaseRepo<Student>
    {
        IQueryable<Student> GetStudentsByName(string name, bool track = true);
        Student? GetStudentId(int id, bool track = true);
        void Add(Student student);
    }
}
