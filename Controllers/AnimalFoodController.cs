using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AnimalManager.Models;

namespace AnimalManager.Controllers
{
    public class AnimalFoodController : Controller
    {
        private AnimalContext db = new AnimalContext();

        // GET: /AnimalFood/
        public ActionResult Index()
        {
            var animalfoods = db.AnimalFoods.Include(a => a.Animal).Include(a => a.Food);
            List<FoodTotal> totals = new List<FoodTotal>();
            foreach (AnimalFood animalFood in animalfoods)
            {
                FoodTotal foodTotal = new FoodTotal(animalFood);
                totals.Add(foodTotal);
            }
            List<FoodTotal> result = new List<FoodTotal>();
            var groupby = totals.GroupBy(x => x.Foodname);
            foreach (IGrouping<string, FoodTotal> foodtotals in groupby)
            {
                double totalprice = foodtotals.Sum(x => x.Totalprice);
                double totalquantity = foodtotals.Sum(x => x.Foodquantity);
                FoodTotal foodtotal = new FoodTotal()
                {
                    Foodname = foodtotals.Key,
                    Foodprice = foodtotals.First().Foodprice,
                    Totalprice = totalprice,
                    Foodquantity = totalquantity
                };
                result.Add(foodtotal);
            }
            ViewBag.Totalprice = result.Sum(x => x.Totalprice);
            return View(result);
        }


       
        // GET: /AnimalFood/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnimalFood animalfood = db.AnimalFoods.Find(id);
            if (animalfood == null)
            {
                return HttpNotFound();
            }
            return View(animalfood);
        }

        // GET: /AnimalFood/Create
        public ActionResult Create()
        {
            ViewBag.AnimalId = new SelectList(db.Animals, "Id", "Name");
            ViewBag.FoodId = new SelectList(db.Foods, "Id", "Name");
            return View();
        }

        // POST: /AnimalFood/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,AnimalId,FoodId,Quantity")] AnimalFood animalfood)
        {
            if (ModelState.IsValid)
            {
                db.AnimalFoods.Add(animalfood);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AnimalId = new SelectList(db.Animals, "Id", "Name", animalfood.AnimalId);
            ViewBag.FoodId = new SelectList(db.Foods, "Id", "Name", animalfood.FoodId);
            return View(animalfood);
        }

        // GET: /AnimalFood/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnimalFood animalfood = db.AnimalFoods.Find(id);
            if (animalfood == null)
            {
                return HttpNotFound();
            }
            ViewBag.AnimalId = new SelectList(db.Animals, "Id", "Name", animalfood.AnimalId);
            ViewBag.FoodId = new SelectList(db.Foods, "Id", "Name", animalfood.FoodId);
            return View(animalfood);
        }

        // POST: /AnimalFood/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,AnimalId,FoodId,Quantity")] AnimalFood animalfood)
        {
            if (ModelState.IsValid)
            {
                db.Entry(animalfood).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AnimalId = new SelectList(db.Animals, "Id", "Name", animalfood.AnimalId);
            ViewBag.FoodId = new SelectList(db.Foods, "Id", "Name", animalfood.FoodId);
            return View(animalfood);
        }

        // GET: /AnimalFood/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnimalFood animalfood = db.AnimalFoods.Find(id);
            if (animalfood == null)
            {
                return HttpNotFound();
            }
            return View(animalfood);
        }

        // POST: /AnimalFood/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AnimalFood animalfood = db.AnimalFoods.Find(id);
            db.AnimalFoods.Remove(animalfood);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
