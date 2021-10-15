using AirportManager.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportManagerProject.Controllers
{
    public class PassengerController : Controller
    {
        private readonly IPassengerDAO PassengerDAO;

        public PassengerController(IPassengerDAO pDAO)
        {
            this.PassengerDAO = pDAO;
        }

        // GET: PassengerController
        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Passenger> model = PassengerDAO.GetPassengers();
            return View(model);
        }

        // GET: PassengerController/Details/5
        [HttpGet]
        public IActionResult Details(Passenger p)
        {
            return View(p);
        }

        // GET: PassengerController/Create
        [HttpGet]
        public IActionResult Create()
        {
            
            return View();
        }

        // POST: PassengerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Passenger p)
        {
            try
            {
                PassengerDAO.AddPassenger(p); 
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(p);
            }
        }

        // GET: PassengerController/Delete/5
        [HttpGet]
        public IActionResult Delete(Passenger p)
        {
            return View(p);
        }

        // POST: PassengerController/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost([Bind] Passenger p)
        {
            try
            {
                PassengerDAO.DeletePassenger(p);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(p);
            }
        }

        // GET: PassengerController/Edit/5
        [HttpGet]
        public IActionResult Edit(Passenger p)
        {
            return View(p);
        }

        // POST: PassengerController/Edit/5
        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult EditPost([Bind] Passenger p)
        {
            try
            {
                PassengerDAO.UpdatePassenger(p);
                return RedirectToAction(nameof(Details), p);
            }
            catch
            {
                return View(p);
            }
        }


    }
}
