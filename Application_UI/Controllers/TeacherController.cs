using Application_Core.Interfaces;
using Application_Core.Models;
using Application_Infrastructure.Data;
using Application_UI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Application_UI.Controllers
{
    public class TeacherController : Controller
    {
        private readonly IUniteOfWork<Teacher> _teacher;
        private readonly IUniteOfWork<General> _general;
        private readonly DataContext _db;

        public TeacherController(IUniteOfWork<Teacher> teacher, IUniteOfWork<General> general ,DataContext db)
        {
            _teacher = teacher;
            _general = general;
           _db = db;
        }
        // GET: TeacherController
        public ActionResult Index()
        {
            var teacher = _db.Teachers.Include(x => x.General);
            return View(teacher);
        }

        // GET: TeacherController/Details/5
        public ActionResult Details(Guid? id)
        {
            GetId(id);
            var teacher = _db.Teachers.Include(x => x.General).SingleOrDefault(x=>x.Id == id);
            return View();
        }

        // GET: TeacherController/Create
        public ActionResult Create()
        {
            var view = new TeacherViewModel
            {
                General = _general.Repository.GetAll().ToList()
            };
            return View(view);
        }

        // POST: TeacherController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TeacherViewModel view)
        {
            try
            {
                Teacher teacher = new Teacher
                {
                    Id = view.Id,
                    General = _general.Repository.GetById(view.GeneralId),
                    GeneralId = view.GeneralId,
                    Adress = view.Adress,
                     Birthday = view.Birthday,
                      Degree = view.Degree,
                      TeacherName = view.TeacherName
                };
                _teacher.Repository.Add(teacher);
                _teacher.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TeacherController/Edit/5
        public ActionResult Edit(Guid? id)
        {
            GetId(id);
           var item = _teacher.Repository.GetById(id);
            var view = new TeacherViewModel
            {
                Id = item.Id,
                GeneralId = item.GeneralId,
                Adress = item.Adress,
                 Birthday = item.Birthday,
                  Degree = item.Degree,
                   TeacherName = item.TeacherName,
                General = _general.Repository.GetAll().ToList()
            };
            return View(view);
        }

        // POST: TeacherController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid? id, TeacherViewModel view)
        {
            try
            {
                Teacher teacher = new Teacher
                {
                    Id = view.Id,
                    General = _general.Repository.GetById(view.GeneralId),
                    GeneralId = view.GeneralId,
                    Adress = view.Adress,
                    Birthday = view.Birthday,
                    Degree = view.Degree,
                    TeacherName = view.TeacherName
                };
                _teacher.Repository.Update(teacher);
                _teacher.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TeacherController/Delete/5
        public ActionResult Delete(Guid? id)
        {
            GetId(id);
            return View(_teacher.Repository.GetById(id));
        }

        // POST: TeacherController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid? id, Teacher teacher)
        {
            try
            {
                GetId(id);
                _teacher.Repository.Delete(id);
                _teacher.Save();
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
