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
    public class ProductsController : ApiController
    {
        private AdventureWorksOBPEntities _context;
        public ProductsController()
        {
            _context = new AdventureWorksOBPEntities();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpGet]
        public IEnumerable<ProductDTO> GetProizvodi()
        {
            return _context.Proizvodi.ToList().Select(Mapper.Map<Proizvod, ProductDTO>);
        }
        [HttpGet]
        public IHttpActionResult GetProizvod(int id)
        {
            Proizvod proizvod = _context.Proizvodi.Single(p => p.IDProizvod == id);
            if (proizvod == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Proizvod, ProductDTO>(proizvod));
        }
        // POST /api/customers
        [HttpPost]
        public IHttpActionResult NoviProizvod(ProductDTO productDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var proizvod = Mapper.Map<ProductDTO, Proizvod>(productDTO);
            _context.Proizvodi.Add(proizvod);
            _context.SaveChanges();
            productDTO.IDProizvod = proizvod.IDProizvod;
            return Created(new Uri(Request.RequestUri + "/" + proizvod.IDProizvod), productDTO);
        }
        [HttpPut]
        public void IzmjeniProizvod(int id, ProductDTO productDTO)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var databaseProduct = _context.Proizvodi.SingleOrDefault(p => p.IDProizvod == id);
            if (databaseProduct == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map(productDTO, databaseProduct);

            _context.SaveChanges();
        }
        [HttpDelete]
        public void IzbrisiProizvod(int id)
        {
            var databaseProduct = _context.Proizvodi.SingleOrDefault(p => p.IDProizvod == id);
            if (databaseProduct == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            var listaStavki = _context.Stavke.Where(s => s.ProizvodID == id).ToList();
            foreach (var racun in listaStavki)
            {
                _context.Stavke.RemoveRange(_context.Stavke.Where(s => s.ProizvodID == id));
            }
            _context.SaveChanges();
            _context.Proizvodi.Remove(databaseProduct);
            _context.SaveChanges();
        }
    }
}