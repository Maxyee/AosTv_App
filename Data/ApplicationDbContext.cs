using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AosTv.Models;
using aostv_dotnet_core.Models;

namespace AosTv.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<ChennelCategory> ChennelCategories { get; set; }
        public DbSet<ChennelList> ChennelLists { get; set; }
        public DbSet<Link> Links { get; set; }
    }
}
