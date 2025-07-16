namespace StudentSystem.Models.VMs
{
    public class StudentLessonVm
    {
        //bunları daha sonra tekrar kontrol et
        public int Id { get; set; }
        public string Name { get; set; }
        public List <int> LessonCode { get; set; }
        public int Grade { get; set; }
        public List<Student> AllStudents { get; set; }
        public List<Lesson> AllLessons { get; set; }
    }
}
