using MyProject.AdventureWorksOBP;
using MyProject.Views.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MyProject.Controllers
{
    public class SubcategoriesController : Controller
    {
        private AdventureWorksOBPEntities _context;
        //object relation mapper - objekte iz baze pretvara dostupne u koristenje

        //spajanje na bazu => inicijalizacija
        public SubcategoriesController()
        {
            _context = new AdventureWorksOBPEntities();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: SubCategories
        public ActionResult Index()
        {
            IList<Potkategorija> potkategorije = _context.Potkategorije.ToList();
            return View(potkategorije);
        }

        public ActionResult New()
        {
            CategoryAndSubcategoryDataViewModel naslov = new CategoryAndSubcategoryDataViewModel
            {
                Potkategorija = new Potkategorija(),
                Kategorije = _context.Kategorije.ToList(),
                Naslov = "Nova Potkategorija"
            };

            return View(naslov);
        }
        public ActionResult Save(Potkategorija potkategorija)
        {
            if (!ModelState.IsValid)
            {
                CategoryAndSubcategoryDataViewModel subcategoriesData = new CategoryAndSubcategoryDataViewModel
                {
                    Potkategorija = new Potkategorija(),
                    Kategorije = _context.Kategorije.ToList(),
                    Naslov = "Uredi potkategoriju"
                };
                return View("New", subcategoriesData);
            }
            if (potkategorija.IDPotkategorija == 0)
            {
                _context.Potkategorije.Add(potkategorija);
            }
            else
            {
                Potkategorija potkategorijaUBazi = _context.Potkategorije.Single(p => p.IDPotkategorija == potkategorija.IDPotkategorija);
                potkategorijaUBazi.Naziv = potkategorija.Naziv;
                potkategorijaUBazi.KategorijaID = potkategorija.KategorijaID;
            }
            _context.SaveChanges();

            return RedirectToAction("index", "products");
        }
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }
            Potkategorija potkategorija = _context.Potkategorije.SingleOrDefault(p => p.IDPotkategorija == id);
            CategoryAndSubcategoryDataViewModel subcategoriesData = new CategoryAndSubcategoryDataViewModel
            {
                Potkategorija = potkategorija,
                Kategorije = _context.Kategorije.ToList(),
                Naslov = "Uredi potkategoriju"
            };
            return View("New", subcategoriesData);
        }
    }
}