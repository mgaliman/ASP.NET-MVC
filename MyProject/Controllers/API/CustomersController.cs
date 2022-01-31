using AutoMapper;
using MyProject.AdventureWorksOBP;
using MyProject.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace MyProject.Controllers.API
{
    public class CustomersController : ApiController
    {
        private AdventureWorksOBPEntities _context;
        public CustomersController()
        {
            _context = new AdventureWorksOBPEntities();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpGet]
        public IEnumerable<CustomerDTO> GetKupci() => _context.Kupci.ToList().Select(Mapper.Map<Kupac, CustomerDTO>);
        [HttpGet]
        public IHttpActionResult GetKupac(int id)
        {
            Kupac kupac = _context.Kupci.Single(k => k.IDKupac == id);
            if (kupac == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Kupac, CustomerDTO>(kupac));
        }
        // POST /api/customers
        [HttpPost]
        public IHttpActionResult NoviKupac(CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var kupac = Mapper.Map<CustomerDTO, Kupac>(customerDTO);
            _context.Kupci.Add(kupac);
            _context.SaveChanges();
            customerDTO.IDKupac = kupac.IDKupac;
            return Created(new Uri(Request.RequestUri + "/" + kupac.IDKupac), customerDTO);
        }
        [HttpPut]
        public void IzmjeniKupca(int id, CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var databaseCustomer = _context.Kupci.SingleOrDefault(k => k.IDKupac == id);
            if (databaseCustomer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map(customerDTO, databaseCustomer);

            _context.SaveChanges();
        }
        [HttpDelete]
        public void IzbrisiKupca(int id)
        {
            var databaseCustomer = _context.Kupci.SingleOrDefault(k => k.IDKupac == id);
            if (databaseCustomer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            var listaRacuna = _context.Racuni.Where(r => r.KupacID == id).ToList();
            foreach (var racun in listaRacuna)
            {
                _context.Stavke.RemoveRange(_context.Stavke.Where(s => s.RacunID == racun.IDRacun));
            }
            _context.SaveChanges();
            _context.Racuni.RemoveRange(_context.Racuni.Where(r => r.KupacID == id));
            _context.SaveChanges();
            _context.Kupci.Remove(databaseCustomer);
            _context.SaveChanges();
        }
    }
}