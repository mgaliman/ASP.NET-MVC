using MyProject.AdventureWorksOBP;
using System.Collections.Generic;

namespace MyProject.Views.ViewModels
{
    public class ReceiptInfoViewModel
    {
        public int IDRacuna { get; set; }
        public IEnumerable<Stavka> Stavke { get; set; }
        public IEnumerable<Proizvod> Proizvodi { get; set; }
        public IEnumerable<Potkategorija> Potkategorije { get; set; }
        public IEnumerable<Kategorija> Kategorije { get; set; }
        public IEnumerable<KreditnaKartica> KreditneKartice { get; set; }
        public IEnumerable<Komercijalist> Komercijalisti { get; set; }
    }
}