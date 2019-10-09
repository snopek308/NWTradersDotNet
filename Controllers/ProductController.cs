using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Northwind.Models;

namespace Northwind.Controllers
{
    public class ProductController : Controller
    {

        // this controller depends on the NorthwindRepository
        //this is his _repository
        private INorthwindRepository banana;


        //constructor, creating a new product controller and when they do, we make a new repository
        public ProductController(INorthwindRepository repository)
        {
            banana = repository;
        }


        //controller method defined in the controller interface
        //the action result is going to happen whenever you call categories, showing you all the categories in the repo we made
        public IActionResult Category()
        {
            var results = banana.Categories;
            results = banana.Categories.OrderBy(c => c.CategoryName);
            return View(results);   
        }




        //=> View(banana.Categories); <--this was above before like this;
        //public IActionResult Category()=> View(banana.Categories);

        //method
        public IActionResult Index(int id)
        {
            //returns a page where you can search just a single page
            //if you add .ToList() at the end, you can't do it anymore, nail in the coffin bc its enumerable now
            //don't do .ToLists unless you need to enumerate over the data
            var products = banana.Products;

            if (id != 0)
            {
                products = banana.Products.Where(p => p.CategoryId == id);
            }
            return View(products);
        }

        //public IActionResult Id(int id)
        //{
        //    //returns a specific ID
        //   var results = _repository.Products.Where(p => p.ProductId == id);
        //   return View(results);
        //}
    }
}