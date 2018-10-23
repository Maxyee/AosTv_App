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
    public class ChennelListController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ChennelListController(ApplicationDbContext context)
        {
            this._context=context;
        }


        [HttpGet]
        public ActionResult<List<ChennelList>> GetAll()
        {
            return _context.ChennelLists.ToList();
        }

        [HttpGet("{id}", Name = "GetChennelListById")]
        public ActionResult<ChennelList> GetById(int id)
        {
            var chennellist = _context.ChennelLists.Find(id);
            if (chennellist == null)
            {
                return NotFound();
            }
            return chennellist;
        }


        [HttpPost]
        public ActionResult<ChennelList>  CreateChennelList(ChennelList model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            string chennelName = model.ChennelName;

            var searchdata = _context.ChennelLists.FirstOrDefault(x=>x.ChennelName == chennelName);

            if(searchdata == null)
            {
                _context.ChennelLists.Add(model);
                _context.SaveChanges();

                return model;
            }
            else
            {
                return NotFound();
            }
        }





        [HttpPut("{id}")]
        public IActionResult Update(int id, ChennelList model)
        {
            var chennellist = _context.ChennelLists.Find(id);
            if (chennellist == null)
            {
                return NotFound();
            }

            chennellist.ChennelName = model.ChennelName;
            chennellist.LogoLink = model.LogoLink;
            
            _context.ChennelLists.Update(chennellist);
            _context.SaveChanges();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var chennelList = _context.ChennelLists.Find(id);
            if (chennelList == null)
            {
                return NotFound();
            }

            _context.ChennelLists.Remove(chennelList);
            _context.SaveChanges();
            return NoContent();
        }

    }
}