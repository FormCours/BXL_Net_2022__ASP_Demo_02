using ASP_MVC_02_Formulaire.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP_MVC_02_Formulaire.Controllers
{
    public class ProductController : Controller
    {
        private static ICollection<Product> _Products = new List<Product>
        {
            new Product() { Id= 1, Name= "Table", Price= 42 },
            new Product() { Id= 2, Name= "Chaise", Price= 24.99 },
            new Product() { Id= 3, Name= "Lampe", Price= 99.99 },
        };
        private static int _LastId = 3;

        public IActionResult Index()
        {
            return View(_Products);
        }

        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Add([FromForm] ProductForm productForm)
        {
            // ↓ Validation "a la main" -> Nope !!!!!!!!!
            /*
            if (productForm.Price < 0)
            {
                ModelState.AddModelError(nameof(productForm.Price), "Pas de prix negatif :o");
            }
            */

            // ↓ Les données seront validé a l'aide d'attirbut dans le model
            if (ModelState.IsValid)
            {
                // Ajout le nouveau produit (-> DB) 
                Product newProduct = new Product()
                {
                    Id = ++_LastId,
                    Name = productForm.Name,
                    Price = productForm.Price
                };
                _Products.Add(newProduct);

                return RedirectToAction(nameof(Index));
            }

            return View();
        }
    }
}
