using MyProject.AdventureWorksOBP;
using MyProject.Views.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MyProject.Controllers
{
    public class CategoriesController : Controller
    {
        private AdventureWorksOBPEntities _context;
        //object relation mapper - objekte iz baze pretvara dostupne u koristenje

        //spajanje na bazu => inicijalizacija
        public CategoriesController()
        {
            _context = new AdventureWorksOBPEntities();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Categories
        public ActionResult Index()
        {
            IList<Kategorija> kategorije = _context.Kategorije.ToList();
            return View(kategorije);
        }
        public ActionResult Create(Kategorija kategorija)
        {
            if (!ModelState.IsValid)
            {
                CategoryAndSubcategoryDataViewModel categoryAndSubcategoryDataViewMode = new CategoryAndSubcategoryDataViewModel
                {
                    Kategorija = kategorija
                };
                return View("NewCategory", categoryAndSubcategoryDataViewMode);
            }
            if (kategorija.IDKategorija == 0)
            {
                _context.Kategorije.Add(kategorija);
            }
            else
            {
                Kategorija kategorijaUBazi = _context.Kategorije.Single(p => p.IDKategorija == kategorija.IDKategorija);
                kategorijaUBazi.Naziv = kategorija.Naziv;
            }
            _context.SaveChanges();

            return RedirectToAction("index", "Categories");
        }
        public ActionResult NewCategory()
        {
            CategoryAndSubcategoryDataViewModel naslov = new CategoryAndSubcategoryDataViewModel
            {
                Kategorija = new Kategorija(),
                Naslov = "New Category"
            };

            return View(naslov);
        }
        public ActionResult Save(Kategorija kategorija)
        {
            if (!ModelState.IsValid)
            {
                List<Kategorija> cat = _context.Kategorije.ToList();
                return View("NewCategory", cat);
            }
            if (kategorija.IDKategorija == 0)
            {
                _context.Kategorije.Add(kategorija);
            }
            else
            {
                Kategorija kategorijaUBazi = _context.Kategorije.Single(k => k.IDKategorija == kategorija.IDKategorija);
                kategorijaUBazi.Naziv = kategorija.Naziv;
            }
            _context.SaveChanges();

            return RedirectToAction("index", "Categories");
        }
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }
            Kategorija kategorija = _context.Kategorije.SingleOrDefault(k => k.IDKategorija == id);
            CategoryAndSubcategoryDataViewModel categoriesData = new CategoryAndSubcategoryDataViewModel
            {
                Kategorija = kategorija,
                Naslov = "Edit Category"
            };
            return View("NewCategory", categoriesData);
        }
    }
}