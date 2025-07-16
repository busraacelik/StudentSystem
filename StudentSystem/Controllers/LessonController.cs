using Microsoft.AspNetCore.Mvc;
using StudentSystem.Models;
using StudentSystem.Models.VMs;
using StudentSystem.REPO.UnitOfWork;

namespace StudentSystem.Controllers
{
    public class LessonController : Controller
    {
        private readonly ILogger<LessonController> _logger;
        private readonly IUnitofWork _unitOfWork;
        public LessonController(IUnitofWork unitofWork,ILogger<LessonController>logger)
        {
            _unitOfWork = unitofWork;
            _logger = logger;

        }
        [HttpGet]
        public IActionResult Index()
        {
            var lessons = _unitOfWork.Lessons.GetAll();
            return View(lessons);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var lesson = _unitOfWork.Lessons.GetAll().FirstOrDefault();
            var viewModel = new StudentLessonVm
            {
                AllLessons = _unitOfWork.Lessons.GetAll().ToList()
            };


            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(StudentLessonVm model)
        {
            if (!ModelState.IsValid)
            {
                model.AllLessons = _unitOfWork.Lessons.GetAll().ToList();
                return View(model);
            }

            var lesson = new Lesson
            {
                Name = model.Name,
                LessonCode = model.LessonCode.FirstOrDefault(),

            };
            _unitOfWork.Lessons.Add(lesson);
            _unitOfWork.Complete(); // veritabanına işle

            return RedirectToAction("Index");
        }
          


    }
    }

