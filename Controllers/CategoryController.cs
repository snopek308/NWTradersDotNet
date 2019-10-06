using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Northwind.Models;

namespace Northwind.Controllers
{
    public class CategoryController : Controller
    {

        private INorthwindRepository categoryRepository;

        //constructor, creating a new product controller and when they do, we make a new repository
        public CategoryController(INorthwindRepository repository)
        {
            categoryRepository = repository;
        }

        //controller method defined in the controller interface
        //the action resurlt is going to happen whenever you call categories, showing you all the categories in the repo we made
        public IActionResult Category() => View(categoryRepository.Categories);





        public IActionResult Index()
        {
            return View();
        }
    }
}