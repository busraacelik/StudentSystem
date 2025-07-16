using StudentSystem.Abstract;
using StudentSystem.Enums;

namespace StudentSystem.Models
{
    public class Student:BaseEntity
    {
		
        private string _fullName;

       public string FullName
		{
			get { return _fullName; }
			set 
			{ if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException("Full name cannot be null or empty.", nameof(value));
                }

                _fullName = value; }
		}

		private string _phoneNumber;

		public string PhoneNumber
		{
			get { return _phoneNumber; }
			set { _phoneNumber = value; }
		}

		private string _email;

		public string EMail
		{
			get { return _email; }
			set
			{ 
				if(string.IsNullOrWhiteSpace(value) || !value.Contains("@"))
				{
					throw new ArgumentException("Email cannot be null, empty, or invalid.", nameof(value));
                }
                _email = value; }
		}

		public Status Status { get; set; } = Status.Passed;

        public int Grade { get; set; } // Assuming Grade is an integer, you can change the type if needed

		public virtual ICollection<StudentLesson> StudentLessons { get; set; }



    }
}
