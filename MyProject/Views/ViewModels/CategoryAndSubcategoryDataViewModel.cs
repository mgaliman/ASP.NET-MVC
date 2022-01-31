using MyProject.AdventureWorksOBP;
using System.Collections.Generic;

namespace MyProject.Views.ViewModels
{
    public class CategoryAndSubcategoryDataViewModel
    {
        public Potkategorija Potkategorija { get; set; }
        public Kategorija Kategorija { get; set; }
        public IEnumerable<Kategorija> Kategorije { get; set; }
        public string Naslov { get; set; }
    }
}