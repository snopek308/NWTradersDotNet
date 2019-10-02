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
        private INorthwindRepository _repository;

        public ProductController(INorthwindRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Category() => View(_repository.Categories);

        public IActionResult Index(int id)
        {
            //returns a page where you can search just a single page
            //if you add .ToList() at the end, you can't do it anymore, nail in the coffin bc its enumerable now
            //don't do .ToLists unless you need to enumerate over the data
            var products = _repository.Products;

            if (id != 0)
            {
                products = _repository.Products.Where(p => p.ProductId == id);
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