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
    public class ChennelCategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ChennelCategoryController(ApplicationDbContext context){
            this._context=context;

        }

        [HttpGet]
        public ActionResult<List<ChennelCategory>> GetAll()
        {
            return _context.ChennelCategories.ToList();
        }

        [HttpGet("{id}", Name = "GetChennelCategory")]
        public ActionResult<ChennelCategory> GetById(int id)
        {
            var chennel = _context.ChennelCategories.Find(id);
            if (chennel == null)
            {
                return NotFound();
            }
            return chennel;
        }



        [HttpPost]
        public ActionResult<ChennelCategory>  CreateChennelCategory(ChennelCategory model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            string categoryType = model.CategoryType;

            var searchdata = _context.ChennelCategories.FirstOrDefault(x=>x.CategoryType == categoryType);

            if(searchdata == null)
            {
                _context.ChennelCategories.Add(model);
                _context.SaveChanges();

                return model;
            }
            else
            {
                return NotFound();
            }
        }




        [HttpPut("{id}")]
        public IActionResult Update(int id, ChennelCategory model)
        {
            var chennel = _context.ChennelCategories.Find(id);
            if (chennel == null)
            {
                return NotFound();
            }

            chennel.CategoryType = model.CategoryType;
            chennel.LogoLink = model.LogoLink;
            
            _context.ChennelCategories.Update(chennel);
            _context.SaveChanges();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var chennel = _context.ChennelCategories.Find(id);
            if (chennel == null)
            {
                return NotFound();
            }

            _context.ChennelCategories.Remove(chennel);
            _context.SaveChanges();
            return NoContent();
        }


        
    }
}