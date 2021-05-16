using Microsoft.AspNetCore.Mvc;
using OnlineShopApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepo;
        public ProductController(IProductRepository productRepository)
        {
            this.productRepo = productRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public ViewResult AllProducts()
        {
            var products = this.productRepo.GetAllProducts();
            ViewBag.SectionName = "All Products";
            ViewData["Title"] = "Product Page";
            return View(products);
        }

        public IActionResult ProductById(int id)
        {
            var product = this.productRepo.GetProductById(id);

            if (product == null)
                return NotFound();

            return View(product);
        }

        public IActionResult ProductsByCategory([FromQuery] string category)
        {
            if (string.IsNullOrEmpty(category))
            {
                throw new Exception("some error");
                //return RedirectToAction(nameof(Error));
            }

            var products = this.productRepo.GetAllProducts();
            var productsByCategory = products.Where(x => x.Category.ToString() == category);
            ViewBag.SectionName = $"{category}";
            return View(productsByCategory);
        }

        public IActionResult Categories()
        {
            var products = this.productRepo.GetAllProducts();
            var groupProducts = products.GroupBy(x => x.Category).ToList();
            List<ProductViewModel> categories = new List<ProductViewModel>();
            foreach (var group in groupProducts)
            {
                categories.Add(new ProductViewModel()
                {
                    CurrentCategory = group.Key,
                    Products = group
                });
            }
            return View(categories);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
