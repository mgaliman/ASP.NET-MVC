//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyProject.AdventureWorksOBP
{
    using System;
    using System.Collections.Generic;
    
    public partial class Stavka
    {
        public int IDStavka { get; set; }
        public int RacunID { get; set; }
        public short Kolicina { get; set; }
        public int ProizvodID { get; set; }
        public decimal CijenaPoKomadu { get; set; }
        public decimal PopustUPostocima { get; set; }
        public decimal UkupnaCijena { get; set; }
    
        public virtual Proizvod Proizvod { get; set; }
        public virtual Racun Racun { get; set; }
    }
}
