using Microsoft.AspNetCore.Mvc;
using projectManagement.Data;
using projectManagement.Models;

namespace projectManagement.Controllers
{
    public class ProductController : Controller

    {
        private readonly ProductDbContext _Context;
        public ProductController(ProductDbContext context)
        {
            _Context = context; 
        }
        public IActionResult Index()
        {
          IEnumerable<Product> products = _Context.Products.ToList();
            return View(products);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create( [Bind("Name, Price, Description, Stock")] Product model)
        {
            if(ModelState.IsValid)
            {
                _Context.Products.Add(model);
                _Context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
          var  product = _Context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product model)
        {
            if (ModelState.IsValid)
            {
                _Context.Products.Update(model);
                _Context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            var product = _Context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            _Context.Products.Remove(product);
            _Context.SaveChanges();
            return RedirectToAction("Index");
        }
      

    }
}
