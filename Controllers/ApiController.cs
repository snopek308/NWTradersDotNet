using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind.Models;

namespace Northwind.Controllers
{
    
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly INorthwindRepository _repository;

        public ApiController(INorthwindRepository repository)
        {
            _repository = repository;
        }

        [HttpGet, Route("api/product")]
        public IActionResult Get()
        {
           return Ok(_repository.Products.OrderBy(p => p.ProductName).ToList());
        }

        [HttpGet, Route("api/product/{id}")]
        public Product Get(int id)
        {
            //throw new SystemException();
            return _repository.Products.FirstOrDefault(p => p.ProductId == id);
        }

        [HttpGet, Route("api/product/discontinued/{discontinued}")]
        // returns all products where discontinued = true/false
        public IEnumerable<Product> GetDiscontinued(bool discontinued) => _repository.Products.Where(p => p.Discontinued == discontinued).OrderBy(p => p.ProductName);

        [HttpGet, Route("api/category/{CategoryId}/product")]
        // returns all products in a specific category
        public IEnumerable<Product> GetByCategory(int CategoryId) => _repository.Products.Where(p => p.CategoryId == CategoryId).OrderBy(p => p.ProductName);

        [HttpGet, Route("api/category/{CategoryId}/product/discontinued/{discontinued}")]
        // returns all products in a specific category where discontinued = true/false
        public IEnumerable<Product> GetByCategoryDiscontinued(int CategoryId, bool discontinued) => _repository.Products.Where(p => p.CategoryId == CategoryId && p.Discontinued == discontinued).OrderBy(p => p.ProductName);

    }
}