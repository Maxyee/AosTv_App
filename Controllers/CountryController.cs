using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AosTv.Models;
using AosTv.Data;
using aostv_dotnet_core.Models;
using Newtonsoft.Json;


namespace aostv_dotnet_core.Controllers
{
    public class CountryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CountryController(ApplicationDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public IActionResult AllCountry()
        {
            List<Country> data = _context.Countries.ToList();
            return new JsonResult(data);
        }

        [HttpGet]
        public IActionResult CountryById(int id)
        {
            Country data = _context.Countries.Find(id);
            return new JsonResult(data);
        }


        [HttpPost]
        public ActionResult<Country> CreateCountryName(Country model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            string name = model.CountryName;

            var searchdata = _context.Countries.FirstOrDefault(x => x.CountryName == name);

            if (searchdata == null)
            {
                _context.Countries.Add(model);
                _context.SaveChanges();

                return model;
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public dynamic AddCountry([Bind] Country model)
        {
            if (ModelState.IsValid)
            {
                _context.Countries.Add(model);
                _context.SaveChanges();
                return new
                {
                    res = true,
                    payload = model
                };
            }
            return new
            {
                res = false
            };
        }

        [HttpPost]
        public IActionResult EditCountry(int id, [Bind]Country model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.Countries.Update(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult DeleteCountry(int id)
        {
            var con = _context.Countries.Find(id);
            _context.Countries.Remove(con);
            _context.SaveChanges();
            return new JsonResult("Country Deleted Successfully!");
        }
    }
}