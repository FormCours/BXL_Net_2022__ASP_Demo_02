using ASP_MVC_02_Formulaire.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASP_MVC_02_Formulaire.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult Contact()
        {
            return View();
        }

        #region Récuperation de donnée via "IFormCollection" (Peu utiliser)
        /*
        [HttpPost]
        public IActionResult Contact(IFormCollection data)
        {
            // Les clefs ne sont pas casse sensitive
            string pseudo = data["pseudo"];
            string email = data["Email"];
            string message = data["mEssAGe"];

            Console.WriteLine("Donnée du formulaire...");
            Console.WriteLine($"- {pseudo} {email}\n  {message}");

            return View("ContactSuccess");
        }
        */
        #endregion

        #region Récuperation de donnée via des parametres
        /*
        [HttpPost]
        public IActionResult Contact([FromForm]string pseudo, [FromForm] string email, [FromForm] string message)
        {
            Console.WriteLine("Donnée du formulaire...");
            Console.WriteLine($"- {pseudo} {email}\n  {message}");

            return View("ContactSuccess");
        }
        */
        #endregion

        [HttpPost]
        public IActionResult Contact([FromForm] ContactForm contactForm)
        {
            Console.WriteLine("Donnée du formulaire...");
            Console.WriteLine($"- {contactForm.Pseudo} {contactForm.Email}\n  {contactForm.Message}");

            return View("ContactSuccess");
        }
    }
}