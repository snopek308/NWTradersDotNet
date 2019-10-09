using Microsoft.AspNetCore.Mvc;
using Northwind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Northwind.Controllers
{
    public class ContactController : Controller
    {
        private INorthwindRepository repository;
        public ContactController(INorthwindRepository repo)
        {
            repository = repo;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        //The Contact is holding the data
        public IActionResult Index(Contact contact)
        {
            if(ModelState.IsValid)
            {
                repository.AddContact(contact);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}

