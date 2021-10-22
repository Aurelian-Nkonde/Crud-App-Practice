using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using three.Models;
using MvcPhilosopher.Models;

namespace philosophers 
{
    public class PhilosopherController: Controller
    {

        //creating access to the database
        //its dependency injection
        private readonly ApplicationDbContext _db;
        public PhilosopherController(ApplicationDbContext db)
        {
            _db = db;
        }


        //the default rendered view
        public IActionResult Index()
        {
            IEnumerable<Philosopher> ListPhilosophers =  _db.philosophers; //query the database
            return View(ListPhilosophers);
        }


        // rendering the create form
        public IActionResult Create()
        {
            return View();
        }


        //action method to process the form and create a product
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Philosopher data) //data binding going on here
        {
            if (ModelState.IsValid) //checking if the passed data from form is valid
            {
                _db.philosophers.Add(data);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(data);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var philodata = _db.philosophers.Find(id);
            if (philodata == null)
            {
                return NotFound();
            }

            return View(philodata);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteData(int? id)
        {

            var dataphilo = _db.philosophers.Find(id);
            if (dataphilo == null)
            {
                return RedirectToAction("Cant");
            }
            else 
            {
                _db.philosophers.Remove(dataphilo);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            
        }

        // suppossed to render if the app cant delete a data
        public IActionResult Cant()
        {
            return View();
        }
        

        // the GET edit, renders the populated form
        public IActionResult Edit(int? id) //receiving id as parameter
        {
            if (id == null || id == 0) //checking if the id not empty
            {
                return NotFound();
            }

            var dataId  = _db.philosophers.Find(id); //querying the value with id from db
            if (dataId == null) //check if it exists
            {
                return NotFound();
            }

            return View(dataId); //render form with populated fields
        }
 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Philosopher data)
        {
           if (ModelState.IsValid)
           {
               _db.philosophers.Update(data);
               _db.SaveChanges();
               return RedirectToAction("Index");
           }
        else 
        {
            return View(data);
        }

        }
    }
}