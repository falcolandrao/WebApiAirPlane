using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApp_AirPlane.Controllers;

namespace WebApp_AirPlane.Models
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Airplane> AirPlane { get; set; }
        public DbSet<Passengers> Passengers { get; set; }
    }
}
