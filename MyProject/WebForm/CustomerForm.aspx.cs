using MyProject.AdventureWorksOBP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace MyProject.WebForm
{
    public partial class Customer : System.Web.UI.Page
    {
        private AdventureWorksOBPEntities _context = new AdventureWorksOBPEntities();
        public Kupac kupac = new Kupac();
        public int id = 0;
        public Grad grad = new Grad();
        public Drzava drzava = new Drzava();
        public IList<Grad> gradovi = new List<Grad>();
        public IList<Drzava> drzave = new List<Drzava>();

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            int.TryParse(HttpContext.Current.Session["kupacId"].ToString(), out id);
            kupac = _context.Kupci.SingleOrDefault(k => k.IDKupac == id);
            grad = _context.Gradovi.SingleOrDefault(g => g.IDGrad == kupac.GradID);
            drzava = _context.Drzave.SingleOrDefault(d => d.IDDrzava == grad.DrzavaID);
            gradovi = _context.Gradovi.ToList();
            drzave = _context.Drzave.ToList();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AddDdlDrzave();
                AddDdlGradovi();
            }
        }
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            txtIme.Text = kupac.Ime.ToString();
            txtPrezime.Text = kupac.Prezime.ToString();
            txtEmail.Text = kupac.Email.ToString();
            txtTelefon.Text = kupac.Telefon.ToString();
        }

        private void AddDdlGradovi()
        {
            int idDrzava = int.Parse(ddlDrzave.SelectedValue);
            ddlGradovi.DataSource = _context.Gradovi.ToList().Where(g => g.DrzavaID == idDrzava);
            ddlGradovi.DataTextField = "Naziv";
            ddlGradovi.DataValueField = "IDGrad";
            if (!IsPostBack)
            {
                ddlGradovi.SelectedValue = grad.IDGrad.ToString();
            }
            ddlGradovi.DataBind();
        }

        private void AddDdlDrzave()
        {
            ddlDrzave.DataSource = _context.Drzave.ToList();
            ddlDrzave.DataTextField = "Naziv";
            ddlDrzave.DataValueField = "IDDrzava";
            ddlDrzave.SelectedValue = drzava.IDDrzava.ToString();
            ddlDrzave.DataBind();
        }

        protected void ddlDrzave_SelectedIndexChanged(object sender, EventArgs e) => AddDdlGradovi();
        protected void btrnSpremi_Click(object sender, EventArgs e)
        {
            kupac.Ime = txtIme.Text;
            kupac.Prezime = txtPrezime.Text;
            kupac.Email = txtEmail.Text;
            kupac.Telefon = txtTelefon.Text;
            kupac.GradID = int.Parse(ddlGradovi.SelectedValue);
            _context.SaveChanges();
            Response.Redirect("https://localhost:44350/Customers");
        }
    }
}