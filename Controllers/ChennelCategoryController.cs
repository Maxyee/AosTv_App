using System;
using Microsoft.AspNetCore.Mvc;
using AosTv.Data;
using AosTv.Models;
using aostv_dotnet_core.Models;

namespace aostv_dotnet_core.Controllers
{
    public class ChennelCategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChennelCategoryController(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IActionResult AddCategory([Bind] ChennelCategory model)
        {
            if(ModelState.IsValid)
            {
                _context.ChennelCategories.Add(model);
                _context.SaveChanges();
                return View("Index");
            }
            return View("Index");
        }
    }
}