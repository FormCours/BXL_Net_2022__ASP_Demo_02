using ASP_MVC_02_Formulaire.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASP_MVC_02_Formulaire.Controllers
{
    public class ClothesController : Controller
    {
        #region Static data (Fake DB)
        private static ICollection<Clothes> _Clothes = new List<Clothes>
        {
            new Clothes { Id= 1, Name= "Test", Color="Cyan", Size=ClothesSize.M, WashTemp=30, DryerAllow=false, Price=42 },
            new Clothes { Id= 2, Name= "T-Shirt", Color="Noir", Size=ClothesSize.L, WashTemp=45, DryerAllow=true, Price=24.99 }
        };
        public static int _LastId = 2;
        #endregion

        public IActionResult Index()
        {
            return View(_Clothes);
        }

        private IEnumerable<SelectListItem> GetSizeSelectList()
        {
            IEnumerable<SelectListItem> sizeSelectList = Enum.GetValues<ClothesSize>()
                .Select(s => new SelectListItem(
                    s.ToString(),
                    ((int)s).ToString()
                ));

            return sizeSelectList;
        }


        public IActionResult Add()
        {
            ViewBag.SizeSelectList = GetSizeSelectList();
            return View(new ClothesForm());
        }

        [HttpPost]
        public IActionResult Add(ClothesForm clothesForm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.SizeSelectList = GetSizeSelectList();
                return View(clothesForm);
            }

            _Clothes.Add(new Clothes()
            {
                Id = ++_LastId,
                Name = clothesForm.Name,
                Color = clothesForm.Color,
                Size = clothesForm.Size,
                WashTemp = clothesForm.WashTemp,
                DryerAllow = clothesForm.DryerAllow,
                Price = clothesForm.Price
            });

            return RedirectToAction(nameof(Index));
        }
    }
}
