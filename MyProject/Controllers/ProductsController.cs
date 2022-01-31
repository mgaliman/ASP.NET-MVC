using MyProject.AdventureWorksOBP;
using MyProject.Views.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MyProject.Controllers
{
    public class ProductsController : Controller
    {
        private AdventureWorksOBPEntities _context;
        //object relation mapper - objekte iz baze pretvara dostupne u koristenje

        //spajanje na bazu => inicijalizacija
        public ProductsController()
        {
            _context = new AdventureWorksOBPEntities();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Products
        public ActionResult Index()
        {
            IList<Proizvod> proizvodi = _context.Proizvodi.ToList();
            return View(proizvodi);
        }

        public ActionResult Create(Proizvod proizvod)
        {
            if (!ModelState.IsValid)
            {
                ProductDataViewModel productData = new ProductDataViewModel
                {
                    Proizvod = proizvod,
                    Potkategorije = _context.Potkategorije.ToList()
                };
                return View("NewProduct", productData);
            }
            if (proizvod.IDProizvod == 0)
            {
                _context.Proizvodi.Add(proizvod);
            }
            else
            {
                Proizvod proizvodUBazi = _context.Proizvodi.Single(p => p.IDProizvod == proizvod.IDProizvod);
                proizvodUBazi.Naziv = proizvod.Naziv;
                proizvodUBazi.BrojProizvoda = proizvod.BrojProizvoda;
                proizvodUBazi.Boja = proizvod.Boja;
                proizvodUBazi.MinimalnaKolicinaNaSkladistu = proizvod.MinimalnaKolicinaNaSkladistu;
                proizvodUBazi.CijenaBezPDV = proizvod.CijenaBezPDV;
                proizvodUBazi.PotkategorijaID = proizvod.PotkategorijaID;
            }
            _context.SaveChanges();

            return RedirectToAction("index", "Products");
        }

        public ActionResult NewProduct()
        {
            ProductDataViewModel productView = new ProductDataViewModel
            {
                Proizvod = new Proizvod(),
                Potkategorije = _context.Potkategorije.ToList()
            };
            return View(productView);
        }

        public ActionResult ProductInfo(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }

            Proizvod proizvod = _context.Proizvodi.SingleOrDefault(p => p.IDProizvod == id);
            return View(proizvod);
        }

        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }

            Proizvod proizvod = _context.Proizvodi.SingleOrDefault(p => p.IDProizvod == id);
            ProductDataViewModel productDataView = new ProductDataViewModel
            {
                Proizvod = proizvod,
                Potkategorije = _context.Potkategorije.ToList()
            };
            return View("NewProduct", productDataView);
        }
    }
}