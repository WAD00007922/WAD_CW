using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRental.DAL.DBO;

namespace CarRental.DAL
{
    public class CarRentalDbContext: DbContext
    {
        public CarRentalDbContext(DbContextOptions<CarRentalDbContext> options)
            : base(options)
        {
            
        }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
    }
}
