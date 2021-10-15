using AirportManager.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportManagerProject.Controllers
{
    public class FlightController : Controller
    {
        private readonly IFlightDAO FlightDAO;
        private readonly ITicketDAO TicketDAO;


        public FlightController(IFlightDAO flightDAO, ITicketDAO tDAO)
        {
            this.FlightDAO = flightDAO;
            this.TicketDAO = tDAO;
        }

        public IActionResult DetailsFlight(Flight model)
        {
            return View(model);
        }


        [HttpGet]
        public IActionResult AddFlight(){

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddFlight([Bind] Flight flight)
        {
            if (ModelState.IsValid)
            {
                FlightDAO.AddFlight(flight);
                return RedirectToAction("Index");
            }

            return View(flight);            
        }

        [HttpGet]
        public IActionResult DeleteFlight(Flight flight)
        {
            return View(flight);
        }

        [HttpPost]
        [ActionName("DeleteFlight")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteFlightPost([Bind] Flight flight)
        {
            //Flight flight = FlightDAO.GetFlight(id);
            TicketDAO.DeleteFlight(flight);
            FlightDAO.DeleteFlight(flight);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditFlight(Flight model)
        {
            return View(model);
        }

        [HttpPost]
        [ActionName("EditFlight")]
        [ValidateAntiForgeryToken]
        public IActionResult EditFlightPost([Bind] Flight model)
        {
            
            if (ModelState.IsValid)
            {
                FlightDAO.UpdateFlight(model);
                return RedirectToAction("DetailsFlight", model);
            }

            return View(model);
        }

        public IActionResult Index()
        {
            IEnumerable<Flight> model = FlightDAO.GetFlights();//Passes model into View
            return View(model);
        }







        
        
        
    }
}
