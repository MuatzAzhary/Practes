using Application_Core.Interfaces;
using Application_Core.Models;
using Application_UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Application_UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUniteOfWork<Student> _student;
        private readonly IUniteOfWork<Parent> _parent;
        private readonly IUniteOfWork<Teacher> _teacher;

        public HomeController(IUniteOfWork<Student> student,
            IUniteOfWork<Parent> parent
            , IUniteOfWork<Teacher> teacher)
        {
            _student = student;
            _parent = parent;
            _teacher = teacher;
        }
        public IActionResult Index()
        {
            var home = new HomeViewModel
            {
                Parents = _parent.Repository.GetAll().ToList(),
                Students = _student.Repository.GetAll().ToList(),
                Teachers = _teacher.Repository.GetAll().ToList()
            };
            return View(home);
        }
    }
}
