using CarRental.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.DAL
{
    public class CarRentalDbContext: DbContext
    {
        public CarRentalDbContext(DbContextOptions<CarRentalDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
    }
}
