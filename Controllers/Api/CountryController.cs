using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AosTv.Models;
using AosTv.Data;
using aostv_dotnet_core.Models;

namespace aostv_dotnet_core.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CountryController(ApplicationDbContext context)
        {
            this._context=context;
        }

        [HttpGet]
        public ActionResult<List<Country>> GetAll()
        {
            return _context.Countries.ToList();
        }


        [HttpGet("{id}", Name = "GetCountry")]
        public ActionResult<Country> GetById(int id)
        {
            var country = _context.Countries.Find(id);
            if (country == null)
            {
                return NotFound();
            }
            return country;
        }



        [HttpPost]
        public ActionResult<Country> CreateCountryName(Country model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            string name = model.CountryName;

            var searchdata = _context.Countries.FirstOrDefault(x=>x.CountryName==name);

            if(searchdata == null)
            {
                _context.Countries.Add(model);
                _context.SaveChanges();

                return model;
            }else{
                return NotFound();
            }
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, Country model)
        {
            var country = _context.Countries.Find(id);
            if (country == null)
            {
                return NotFound();
            }

            country.CountryName = model.CountryName;
            country.LogoLink = model.LogoLink;
            
            _context.Countries.Update(country);
            _context.SaveChanges();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var country = _context.Countries.Find(id);
            if (country == null)
            {
                return NotFound();
            }

            _context.Countries.Remove(country);
            _context.SaveChanges();
            return NoContent();
        }
        

    }

}   
    