using StudentSystem.Abstract;

namespace StudentSystem.Models
{
    public class Lesson:BaseEntity
    {

		//exceptionları kendim yazacağım
		private string _name;

		public string Name
		{
			get { return _name; }
			set 
			{ if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException("Name cannot be null or empty.", nameof(value));
                }

                _name = value; 
			}
		}
		private int _lessonCode;

		public int LessonCode
		{
			get { return _lessonCode; }
			set 
			{ if (value <= 0)
				{
					throw new ArgumentException("Lesson code must be a positive integer.", nameof(value));
                }

                _lessonCode = value; }
		}

		public virtual ICollection<StudentLesson> StudentLessons { get; set; }
    }
}
