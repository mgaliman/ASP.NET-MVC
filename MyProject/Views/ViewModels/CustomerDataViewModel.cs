using MyProject.AdventureWorksOBP;
using System.Collections.Generic;

namespace MyProject.Views.ViewModels
{
    public class CustomerDataViewModel
    {
        public IEnumerable<Racun> Racuni { get; set; }
        public Kupac Kupac { get; set; }

    }
}