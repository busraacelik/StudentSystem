namespace StudentSystem.Models
{
    public class StudentLesson
    {
        public StudentLesson(){}
        public StudentLesson(int studentid,int lessonid)
        {
            StudentId = studentid;
            LessonId = lessonid;
        }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
        

    }
}
