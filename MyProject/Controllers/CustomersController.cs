using MyProject.AdventureWorksOBP;
using MyProject.Views.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MyProject.Controllers
{
    public class CustomersController : Controller
    {
        private AdventureWorksOBPEntities _context;
        //object relation mapper - objekte iz baze pretvara dostupne u koristenje

        //spajanje na bazu => inicijalizacija
        public CustomersController()
        {
            _context = new AdventureWorksOBPEntities();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Kupac
        public ActionResult Index()
        {
            IList<Kupac> kupci = _context.Kupci.ToList();
            return View(kupci);
        }

        public ActionResult CustomerInfo(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }
            CustomerDataViewModel customerDataView = new CustomerDataViewModel
            {
                Kupac = _context.Kupci.SingleOrDefault(k => k.IDKupac == id),
                Racuni = _context.Racuni.Where(r => r.KupacID == id)
            };
            string idkupac = customerDataView.Kupac.IDKupac.ToString();
            Session["kupacId"] = idkupac;
            return View(customerDataView);
        }

        public ActionResult ReceiptInfo(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }
            ReceiptInfoViewModel receiptInfoView = new ReceiptInfoViewModel();

            Racun temp = _context.Racuni.SingleOrDefault(r => r.IDRacun == id);
            receiptInfoView.IDRacuna = temp.IDRacun;

            foreach (var racun in _context.Racuni.ToList())
            {
                if (racun.IDRacun == id)
                {
                    receiptInfoView.Stavke = _context.Stavke.Where(s => s.RacunID == id).ToList();
                    receiptInfoView.KreditneKartice = _context.KreditneKartice.Where(k => k.IDKreditnaKartica == racun.KreditnaKarticaID).ToList();
                    receiptInfoView.Komercijalisti = _context.Komercijalisti.Where(k => k.IDKomercijalist == racun.KomercijalistID).ToList();
                }
            }
            foreach (var stavka in receiptInfoView.Stavke)
            {
                receiptInfoView.Proizvodi = _context.Proizvodi.Where(p => p.IDProizvod == stavka.ProizvodID).ToList();
            }
            foreach (var proizvod in receiptInfoView.Proizvodi)
            {
                receiptInfoView.Potkategorije = _context.Potkategorije.Where(p => p.IDPotkategorija == proizvod.PotkategorijaID).ToList();
            }
            foreach (var potkategorija in receiptInfoView.Potkategorije)
            {
                receiptInfoView.Kategorije = _context.Kategorije.Where(p => p.IDKategorija == potkategorija.KategorijaID).ToList();
            }



            return View(receiptInfoView);
        }
    }
}