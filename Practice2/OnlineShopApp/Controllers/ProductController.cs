using Microsoft.AspNetCore.Mvc;
using OnlineShopApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopApp.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepo;
        private readonly IEnumerable<IProductRepository> productRepos;
        private readonly ICategoryRepository categoryRepo;
        public ProductController(IProductRepository productRepository/*IEnumerable<IProductRepository> productRepository*/)
        {
            //productRepos = productRepository;
            //var p1 = productRepos.First().GetAllProducts();
            //var p2 = productRepos.Last().GetAllProducts();

            this.productRepo = productRepository;
        }

        [HttpGet]
        public IActionResult AllProducts()
        {
            var products = this.productRepo.GetAllProducts();
            //return View(products);
            return Ok(products);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult ProductById(int id)
        {
            var product = this.productRepo.GetProductById(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        // Prodcut/GetById?id=2
        [HttpGet]
        [Route("GetById")]
        public IActionResult ProductbyIdFromQuery([FromQuery] int id)
        {
            var product = this.productRepo.GetProductById(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        // localhost:5005/Categories
        [HttpGet("/Categories")]
        public IActionResult AllCategories([FromServices] ICategoryRepository categoryRepository)
        {
            return Ok(categoryRepository.Categories);
        }

        [HttpGet("Categories")]
        public IActionResult GetAllCategories()
        {
            var categoryRepository = (CategoryRepository)HttpContext.RequestServices.GetService(typeof(ICategoryRepository));
            return Ok(categoryRepository.Categories);
        }
    }
}
