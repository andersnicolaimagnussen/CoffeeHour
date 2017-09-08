using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeHour.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeHour.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        [HttpGet]
        public ViewResult CoffeeHour()
        {
            return View();
        }
        [HttpPost]
        public ViewResult CoffeeHour(GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                Repository.AddResponse(guestResponse);
                return View("Thanks", guestResponse);
            }
            else
            {
                //there is a validation error
                return View();
            }
            
            
        }

        public ViewResult ListResponses()
        {
            return View(Repository.Responses.Where(x => x.WillAttend == true));
        }
    }
}
