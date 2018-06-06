using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MacMickeyWeb.Models;
using MacMickey.Dal;
using MacMickey.DomainModel;

namespace MacMickeyWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly MacContext _context;

        public HomeController(MacContext context)
        {
            _context = context;
        }

    
        public IActionResult Index()
        {
            List<Burger> burgers = _context.Burgers.ToList();
            List<Beverage> beverages = _context.Beverages.ToList();
            List<Side> sides = _context.Sides.ToList();
            List<Dessert> desserts = _context.Desserts.ToList();
            List<Menu> menus = _context.Menus.ToList();
            return View(menus);
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
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
