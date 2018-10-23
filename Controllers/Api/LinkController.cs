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
    public class LinkController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public LinkController(ApplicationDbContext context)
        {
            this._context=context;

        }

        [HttpGet]
        public ActionResult<List<Link>> GetAll()
        {
            return _context.Links.ToList();
        }

        [HttpGet("{id}", Name = "GetLink")]
        public ActionResult<Link> GetById(int id)
        {
            var link = _context.Links.Find(id);
            if (link == null)
            {
                return NotFound();
            }
            return link;
        }


        [HttpPost]
        public ActionResult<Link>  CreateLink(Link model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            string link = model.LinkString;

            var searchdata = _context.Links.FirstOrDefault(x=>x.LinkString == link);

            if(searchdata == null)
            {
                _context.Links.Add(model);
                _context.SaveChanges();

                return model;
            }
            else
            {
                return NotFound();
            }
        }



        [HttpPut("{id}")]
        public IActionResult Update(int id, Link model)
        {
            var link = _context.Links.Find(id);
            if (link == null)
            {
                return NotFound();
            }

            link.LinkString = model.LinkString;
            link.Type = model.Type;
            link.Quality = model.Quality;
            
            _context.Links.Update(link);
            _context.SaveChanges();
            return NoContent();
        }



        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var link = _context.Links.Find(id);
            if (link == null)
            {
                return NotFound();
            }

            _context.Links.Update(link);
            _context.SaveChanges();
            return NoContent();
        }
    }
}