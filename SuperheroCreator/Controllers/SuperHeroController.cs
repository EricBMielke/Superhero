using SuperheroCreator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperheroCreator.Controllers
{
    public class SuperHeroController : Controller
    {
        ApplicationDbContext db;
        public SuperHeroController()
        {
            db = new ApplicationDbContext();
        }
        // GET: SuperHero
        public ActionResult Index()
        {
            var superheroList = db.SingleSuperhero.AsEnumerable();
            return View(superheroList);
        }

        // GET: SuperHero/Details/5
        public ActionResult Details(int id)
        {
            Superhero superHero = db.SingleSuperhero.Where(s => s.Id == id).FirstOrDefault();
            return View(superHero);
        }

        // GET: SuperHero/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SuperHero/Create
        [HttpPost]
        public ActionResult Create(Superhero superHero)
        {
            try
            {
                db.SingleSuperhero.Add(superHero);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperHero/Edit/5
        public ActionResult Edit(int id)
        {
            Superhero superHero = db.SingleSuperhero.Where(s => s.Id == id).FirstOrDefault();
            return View(superHero);
        }

        // POST: SuperHero/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Superhero superHero)
        {
            try
            {
                Superhero superHeroEdit = db.SingleSuperhero.Where(s => s.Id == id).FirstOrDefault();
                superHeroEdit.Id = superHero.Id;
                superHeroEdit.Name = superHero.Name;
                superHeroEdit.AlterEgo = superHero.AlterEgo;
                superHeroEdit.PrimaryAbility = superHero.PrimaryAbility;
                superHeroEdit.SecondaryAbility = superHero.SecondaryAbility;
                superHeroEdit.Catchphrase = superHero.Catchphrase;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            { 
                return View();
            }
        }

        // GET: SuperHero/Delete/5
        public ActionResult Delete(int id)
        {
            Superhero superHero = db.SingleSuperhero.Where(s => s.Id == id).FirstOrDefault();
            return View(superHero);
        }

        // POST: SuperHero/Delete/5
        [HttpPost]
        public ActionResult Delete(Superhero superHero)
        {

            try
            {
                db.SingleSuperhero.Remove(superHero);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
