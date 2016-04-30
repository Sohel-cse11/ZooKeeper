using AnimalManager.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnimalManager.Controllers
{
    public class Animal2Controller : Controller
    {
        private AnimalContext db = new AnimalContext();
        //
        // GET: /Animal2/
        public ActionResult Index()
        {
            return View(db.Animals.ToList());
        }

        public ActionResult Details(int id)
        {
            Animal animal = db.Animals.Find(id);
            return View(animal);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Animal animal)
        {
            db.Animals.Add(animal);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Animal animal = db.Animals.Find(id);
            return View(animal);
        }
        [HttpPost]
        public ActionResult Edit(Animal animal)
        {
            db.Entry(animal).State=EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Animal animal = db.Animals.Find(id);
            return View(animal);
        }
       [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id )
        {
            Animal animal = db.Animals.Find(id);
            db.Animals.Remove(animal);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
	}
}