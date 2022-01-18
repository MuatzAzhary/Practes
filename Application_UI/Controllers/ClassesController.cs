using Application_Core.Interfaces;
using Application_Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Application_UI.Controllers
{
    public class ClassesController : Controller
    {
        private readonly IUniteOfWork<Classes> _classes;

        public ClassesController(IUniteOfWork<Classes> classes)
        {
            _classes = classes;
        }
        // GET: ClassesController
        public ActionResult Index()
        {
            return View(_classes.Repository.GetAll());
        }

        // GET: ClassesController/Details/5
        public ActionResult Details(Guid? id)
        {
            GetId(id);
            return View(_classes.Repository.GetById(id));
        }

        // GET: ClassesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClassesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Classes classes)
        {
            try
            {
                _classes.Repository.Add(classes);
                _classes.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClassesController/Edit/5
        public ActionResult Edit(Guid? id)
        {
            GetId(id);

            return View(_classes.Repository.GetById(id));
        }

        // POST: ClassesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid? id, Classes classes)
        {
            try
            {
                GetId(id);
                _classes.Repository.Update(classes);
                _classes.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClassesController/Delete/5
        public ActionResult Delete(Guid? id)
        {
            GetId(id);
            return View(_classes.Repository.GetById(id));
        }

        // POST: ClassesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid? id, Classes classes)
        {
            try
            {
                GetId(id);
                _classes.Repository.Delete(id);
                _classes.Save();
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
