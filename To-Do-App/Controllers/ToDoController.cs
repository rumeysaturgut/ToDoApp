using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using To_Do_App.Enumerations;
using To_Do_App.Interfaces;
using To_Do_App.Models;
using To_Do_App.Repositories;

namespace To_Do_App.Controllers
{
    public class ToDoController : Controller
    {
        private IToDoRepository<ToDo> repository;

        public ToDoController()
        {
            repository = new MongoDbRepository<ToDo>();
        }

        public ToDoController(IToDoRepository<ToDo> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(repository.GetAll());
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Priorities = new SelectList(Enum.GetValues(typeof(Priority)));
            return View();
        }

        [HttpPost]
        public ActionResult Create(ToDo model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Priorities = new SelectList(Enum.GetValues(typeof(Priority)));
                repository.Add(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet, ActionName("Delete")]
        public ActionResult DeleteView(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDo model = repository.GetById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            repository.Remove(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDo model = repository.GetById(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(ToDo model, string id)
        {
            if(String.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.Priorities = new SelectList(Enum.GetValues(typeof(Priority)));
            model.Id = ObjectId.Parse(id);
            repository.Update(model, id);
            return RedirectToAction("Index");
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.Priorities = new SelectList(Enum.GetValues(typeof(Priority)));
            ToDo model = repository.GetById(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
    }
}