using MyProject.AdventureWorksOBP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace MyProject.WebForm
{
    public partial class NewCustomer : System.Web.UI.Page
    {
        private AdventureWorksOBPEntities _context = new AdventureWorksOBPEntities();
        public Kupac kupac = new Kupac();
        public Grad grad = new Grad();
        public Drzava drzava = new Drzava();
        public IList<Grad> gradovi = new List<Grad>();
        public IList<Drzava> drzave = new List<Drzava>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AddDdlDrzave();
                AddDdlGradovi();
            }
        }
        private void AddDdlGradovi()
        {
            int idDrzava = int.Parse(ddlDrzave.SelectedValue);
            ddlGradovi.DataSource = _context.Gradovi.ToList().Where(g => g.DrzavaID == idDrzava);
            ddlGradovi.DataTextField = "Naziv";
            ddlGradovi.DataValueField = "IDGrad";
            ddlGradovi.DataBind();
        }

        private void AddDdlDrzave()
        {

            ddlDrzave.DataSource = _context.Drzave.ToList();
            ddlDrzave.DataTextField = "Naziv";
            ddlDrzave.DataValueField = "IDDrzava";
            ddlDrzave.DataBind();
        }
        protected void ddlDrzave_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddDdlGradovi();
        }
        protected void btrnSpremi_Click(object sender, EventArgs e)
        {
            kupac.Ime = txtIme.Text;
            kupac.Prezime = txtPrezime.Text;
            kupac.Email = txtEmail.Text;
            kupac.Telefon = txtTelefon.Text;
            kupac.GradID = int.Parse(ddlGradovi.SelectedValue);
            _context.Kupci.Add(kupac);
            _context.SaveChanges();
            Response.Redirect("https://localhost:44350/Customers/Index");
        }
    }
}