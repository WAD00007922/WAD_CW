using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.DAL.Repositories
{
    public abstract class BaseRepo
    {

            protected readonly CarRentalDbContext _context;

        protected BaseRepo(CarRentalDbContext context)
        {
            _context = context;
        }
       
     }
}
