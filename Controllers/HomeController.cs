using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Northwind.Models;

namespace Northwind.Controllers
{
    public class HomeController : Controller
    {
        private readonly INorthwindRepository _repository;

        public HomeController(INorthwindRepository repo)
        {
            _repository = repo;
        }

        public ActionResult Index()
        {
            var results = _repository.Discounts
                .Where(d => d.StartTime <= DateTime.Now
                            && d.EndTime > DateTime.Now)
                .Take(3);

            return View(results);
        }

        [Authorize(Roles = "Users")]
        public IActionResult OtherAction()
        {
            return View("Index", GetData(nameof(OtherAction)));
        }

        private Dictionary<string, object> GetData(string actionName)
        {
            return new Dictionary<string, object>
            {
                ["Action"] = actionName,
                ["User"] = HttpContext.User.Identity.Name,
                ["Authenticated"] = HttpContext.User.Identity.IsAuthenticated,
                ["Auth Type"] = HttpContext.User.Identity.AuthenticationType,
                ["In Users Role"] = HttpContext.User.IsInRole("Users")
            };
        }
    }
}
