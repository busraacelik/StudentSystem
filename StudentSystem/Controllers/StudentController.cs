using Microsoft.AspNetCore.Mvc;
using StudentSystem.Models;
using StudentSystem.Models.VMs;
using StudentSystem.REPO.UnitOfWork;

namespace StudentSystem.Controllers
{
    public class StudentController : Controller
    {
        private readonly ILogger<StudentController> _logger;
        private readonly IUnitofWork _unitOfWork;
        public StudentController(IUnitofWork unitofWork, ILogger<StudentController> logger)
        {
            _unitOfWork = unitofWork;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var students = _unitOfWork.Students.GetAll();
            var lessons = _unitOfWork.Lessons.GetAll();
            var model = new { Students = students, Lessons = lessons };
            return View(model);

        }
        [HttpGet] 
        public IActionResult Create()
        {
            var students = _unitOfWork.Students.GetAll();
            var viewModel = new StudentLessonVm { AllStudents = students.ToList() };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Create(StudentLessonVm studentLessonVm)
        {
            if (!ModelState.IsValid)
            {
               studentLessonVm.AllStudents = _unitOfWork.Students.GetAll().ToList();
                return View(studentLessonVm);   
            }
            var student = new Student
            {
                FullName = studentLessonVm.Name,
                Grade = studentLessonVm.Grade,
                StudentLessons = studentLessonVm.AllStudents.Select(s => new StudentLesson
                {

                    StudentId = s.Id // Assuming StudentId is the Id of the student
                }).ToList()
            };
            _unitOfWork.Students.Add(student);
            _unitOfWork.Complete();
            return RedirectToAction("Index");
        }
        public IActionResult Complete(int id)
        { 
            var student = _unitOfWork.Students.GetById(id);
            _unitOfWork.Students.Update(student);
            _unitOfWork.Complete();
            return RedirectToAction("Index");
        }
        }
}
