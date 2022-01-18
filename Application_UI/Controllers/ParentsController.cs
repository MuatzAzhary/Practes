using Application_Core.Interfaces;
using Application_Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Application_UI.Controllers
{
    public class ParentsController : Controller
    {
        private readonly IUniteOfWork<Parent> _parent;

        public ParentsController(IUniteOfWork<Parent> parent)
        {
            _parent = parent;

        }
        // GET: ParentsController
        public ActionResult Index()
        {
            return View(_parent.Repository.GetAll());
        }

        // GET: ParentsController/Details/5
        public ActionResult Details(Guid? id)
        {
            GetId(id);
            return View(_parent.Repository.GetById(id));
        }

        // GET: ParentsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ParentsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Parent parent)
        {
            try
            {
                _parent.Repository.Add(parent);
                _parent.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ParentsController/Edit/5
        public ActionResult Edit(Guid? id)
        {
            GetId(id);
            return View(_parent.Repository.GetById(id));
        }

        // POST: ParentsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid? id, Parent parent)
        {
            try
            {
                _parent.Repository.Update(parent);
                _parent.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ParentsController/Delete/5
        public ActionResult Delete(Guid? id)
        {
            GetId(id);
            return View(_parent.Repository.GetById(id));
        }

        // POST: ParentsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid? id, Parent parent)
        {
            try
            {
                GetId(id);
                _parent.Repository.Delete(id);
                _parent.Save();
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
