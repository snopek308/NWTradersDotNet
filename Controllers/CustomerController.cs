﻿using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Northwind.Models;

namespace Northwind.Controllers
{
    public class CustomerController : Controller
    {
        // this controller depends on the NorthwindRepository & the UserManager
        private readonly INorthwindRepository _repository;
        private readonly UserManager<AppUser> _userManager;
        public CustomerController(INorthwindRepository repo, UserManager<AppUser> usrMgr)
        {
            _repository = repo;
            _userManager = usrMgr;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async System.Threading.Tasks.Task<IActionResult> Register(CustomerWithPassword customerWithPassword)
        {
            if (ModelState.IsValid)
            {
                Customer customer = customerWithPassword.Customer;
                if (_repository.Customers.Any(c => c.CompanyName == customer.CompanyName))
                {
                    ModelState.AddModelError("", "Company Name must be unique");
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        AppUser user = new AppUser
                        {
                            // email and username are synced - this is by choice
                            Email = customer.Email,
                            UserName = customer.Email
                        };
                        // Add user to Identity DB
                        IdentityResult result = await _userManager.CreateAsync(user, customerWithPassword.Password);
                        if (!result.Succeeded)
                        {
                            AddErrorsFromResult(result);
                        }
                        else
                        {
                            // Assign user to customers Role
                            result = await _userManager.AddToRoleAsync(user, "Customer");

                            if (!result.Succeeded)
                            {
                                // Delete User from Identity DB
                                await _userManager.DeleteAsync(user);
                                AddErrorsFromResult(result);
                            }
                            else
                            {
                                // Create customer (Northwind)
                                _repository.AddCustomer(customer);
                                return RedirectToAction("Index", "Home");
                            }
                        }
                    }
                }
            }
            return View();
        }

        [Authorize(Roles = "Customer")]
        public IActionResult Account() => View(_repository.Customers.FirstOrDefault(c => c.Email == User.Identity.Name));

        [Authorize(Roles = "Customer"), HttpPost, ValidateAntiForgeryToken]
        public IActionResult Account(Customer customer)
        {
            // Edit customer info
            _repository.EditCustomer(customer);
            return RedirectToAction("Index", "Home");
        }

        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }
    }
}
