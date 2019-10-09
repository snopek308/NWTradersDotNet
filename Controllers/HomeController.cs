using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Northwind.Models;

namespace Northwind.Controllers
{
    public class HomeController : Controller
    {
        //add this in, use the first suggestion to add in INorthWindRepository
        private INorthwindRepository apple;

        //constructor, creating a new product controller and when they do, we make a new repository
        public HomeController(INorthwindRepository repository)
        {
            apple = repository;
        }
        public ActionResult Index()
        {
            //Add the System.Linq when the .Where reds out &.Take
            var results = apple.Discounts
            .Where(d => d.StartTime <= DateTime.Now && d.EndTime > DateTime.Now)
            .Take(3);
            return View(results);
        }

    }
}
