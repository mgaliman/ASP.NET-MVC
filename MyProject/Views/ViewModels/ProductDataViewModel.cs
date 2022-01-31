using MyProject.AdventureWorksOBP;
using System.Collections.Generic;

namespace MyProject.Views.ViewModels
{
    public class ProductDataViewModel
    {
        public Proizvod Proizvod { get; set; }
        public IList<Potkategorija> Potkategorije { get; set; }
    }
}