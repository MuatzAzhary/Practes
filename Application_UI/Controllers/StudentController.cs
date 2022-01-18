using Application_Core.Interfaces;
using Application_Core.Models;
using Application_Infrastructure.Data;
using Application_UI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;

namespace Application_UI.Controllers
{
    public class StudentController : Controller
    {
        private readonly IUniteOfWork<Student> _student;
        private readonly IUniteOfWork<Parent> _parent;
        private readonly IUniteOfWork<Classes> _classes;
        private readonly IUniteOfWork<General> _general;
        private readonly DataContext _db;

        public StudentController(IUniteOfWork<Student> student ,
            IUniteOfWork<Parent> parent 
            , IUniteOfWork<Classes> classes 
            , IUniteOfWork<General> general,
            DataContext db)
        {
            _student = student;
            _parent = parent;
            _classes = classes;
            _general = general;
            _db = db;
        }
        // GET: StudentController
        public ActionResult Index()
        {
            var student = _db.Students.Include(x=>x.Classes).Include(y=>y.General).Include(x=>x.Parent);
            return View(student);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(Guid? id)
        {
            GetId(id);
            var student = _db.Students.Include(x => x.Classes).Include(y => y.General).Include(x => x.Parent).SingleOrDefault(x=>x.Id ==id);
            return View(student);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            var studentview = new StudentViewModel
            {
                classes = _classes.Repository.GetAll().ToList(),
                General  = _general.Repository.GetAll().ToList(),
                Parent = _parent.Repository.GetAll().ToList()
            };
            return View(studentview);
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentViewModel view)
        {
            try
            {
                Student student = new Student
                {
                    Id = view.Id,
                    Adress = view.Adress,
                    Age = view.Age,
                    Birthday = view.Birthday,
                    Classes = _classes.Repository.GetById(view.ClassesId),
                    ClassesId = view.ClassesId,
                    General = _general.Repository.GetById(view.GeneralId),
                    GeneralId = view.GeneralId,
                    Parent = _parent.Repository.GetById(view.ParentId),
                    ParentId = view.ParentId,
                    StudentName = view.StudentName
                };
                _student.Repository.Add(student);
                _student.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(Guid? id)
        {
            GetId(id);
          var student = _student.Repository.GetById(id);
            var view = new StudentViewModel
            {
                Id = student.Id,
                Adress = student.Adress,
                 Age = student.Age,
                 Birthday = student.Birthday,
                classes = _classes.Repository.GetAll().ToList(),
                General = _general.Repository.GetAll().ToList(),
                Parent = _parent.Repository.GetAll().ToList(),
                ClassesId = student.ClassesId,
                GeneralId = student.GeneralId,
                 ParentId = student.ParentId,
                 StudentName = student.StudentName

            };
            return View(view);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid? id, StudentViewModel view)
        {
            try
            {
                Student student = new Student
                {
                    Id = view.Id,
                    Adress = view.Adress,
                    Age = view.Age,
                    Birthday = view.Birthday,
                    Classes = _classes.Repository.GetById(view.ClassesId),
                    ClassesId = view.ClassesId,
                    General = _general.Repository.GetById(view.GeneralId),
                    GeneralId = view.GeneralId,
                    Parent = _parent.Repository.GetById(view.ParentId),
                    ParentId = view.ParentId,
                    StudentName = view.StudentName
                };
                _student.Repository.Update(student);
                _student.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(Guid? id)
        {
            GetId(id);
            var student = _student.Repository.GetById(id);
            return View(student);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid? id, Student student)
        {
            try
            {
                GetId(id);
                _student.Repository.Delete(id);
                _student.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        //Get Id
        object GetId(object id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return id;
        }
    }
}
