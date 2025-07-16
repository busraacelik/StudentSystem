
namespace StudentSystem.Abstract
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; internal set; }
        public DateTime UpdatedAt { get; internal set; }
    }
}
