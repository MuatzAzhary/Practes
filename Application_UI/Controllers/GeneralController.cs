using Application_Core.Interfaces;
using Application_Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Application_UI.Controllers
{
    public class GeneralController : Controller
    {
        private readonly IUniteOfWork<General> _general;

        public GeneralController(IUniteOfWork<General> general)
        {
            _general = general;
        }
        // GET: GeneralController
        public ActionResult Index()
        {
            return View(_general.Repository.GetAll());
        }

        // GET: GeneralController/Details/5
        public ActionResult Details(Guid? id)
        {
            GetId(id);

            return View(_general.Repository.GetById(id));
        }

        // GET: GeneralController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GeneralController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(General general)
        {
            try
            {
                _general.Repository.Add(general);
                _general.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GeneralController/Edit/5
        public ActionResult Edit(Guid? id)
        {
            GetId(id);

            return View(_general.Repository.GetById(id));
        }

        // POST: GeneralController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid? id, General general)
        {
            try
            {
                GetId(id);
                _general.Repository.Update(general);
                _general.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GeneralController/Delete/5
        public ActionResult Delete(Guid? id)
        {
            GetId(id);
            return View(_general.Repository.GetById(id));
        }

        // POST: GeneralController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid? id, General general)
        {
            try
            {
                GetId(id);
                _general.Repository.Delete(id);
                _general.Save();
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
