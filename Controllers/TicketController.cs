using AirportManager.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportManagerProject.Controllers
{
    public class TicketController : Controller
    {
        private readonly ITicketDAO TicketDAO;
        private readonly IFlightDAO FlightDAO;
        private readonly IPassengerDAO PassengerDAO;

        public TicketController(ITicketDAO ticketDAO, IFlightDAO flightDAO, IPassengerDAO pDAO)
        {
            this.TicketDAO = ticketDAO;
            this.FlightDAO = flightDAO;
            this.PassengerDAO = pDAO;
        }



        // POST: TicketController/Create
        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePost([Bind] Ticket tik)
        {
            try
            {
                TicketDAO.BookTicket(tik);
                return RedirectToAction(nameof(Index), tik);
            }
            catch
            {
                return View(tik);
            }
        }

        [HttpGet]
        public ActionResult Create(Flight f, Ticket t)
        {
            
                Ticket tik = new Ticket() { FlightN = f.Id_Flight };
                return View(tik);
            
        }


        // GET: TicketController
        public ActionResult Index(Flight f)
        {
            return View(f);
        }

        // GET: TicketController/Create


        //Moved to occur when a flight is deleted
        //// GET: TicketController/Delete/5
        //public ActionResult Delete(Flight f)
        //{
        //    return View(f);
        //}

        //// POST: TicketController/Delete/5
        //[HttpPost]
        //[ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeletePost([Bind]Flight f)
        //{
        //    try
        //    {
        //        TicketDAO.DeleteFlight(f);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View(f);
        //    }
        //}
    }
}
