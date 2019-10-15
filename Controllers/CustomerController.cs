using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Northwind.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Northwind.Controllers
{
    public class CustomerController : Controller
    {
        private INorthwindRepository repository;

        public CustomerController(INorthwindRepository customerRepository)
        {
            repository = customerRepository;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Customer customer)
        {
            if (ModelState.IsValid)
            {
                repository.AddCustomer(customer);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
