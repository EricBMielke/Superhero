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
        public ActionResult Edit()
        {
            return View();
        }

        // POST: SuperHero/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Superhero superHero, string updateField, string newValue)
        {
            try
            {
                switch (updateField)
                {
                    case ("Name"):
                        superHero.Name = newValue;
                        break;
                    case ("AlterEgo"):
                        superHero.AlterEgo = newValue;
                        break;
                    case ("PrimaryAbility"):
                        superHero.PrimaryAbility = newValue;
                        break;
                    case ("SecondaryAbility"):
                        superHero.SecondaryAbility = newValue;
                        break;
                    case ("Catchphrase"):
                        superHero.Catchphrase = newValue;
                        break;
                    default:
                        Console.WriteLine("Invalid field type to be updated");
                        break;
                }
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
            var superHero = db.SingleSuperhero.Where(s => s.Id == id);
            return View();
        }

        // POST: SuperHero/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Superhero superHero)
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
