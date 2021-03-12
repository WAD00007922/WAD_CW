using CarRental.DAL.DBO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DAL.Repositories
{
    public class CarRepo : BaseRepo, IRepository<Car>
    {
        public CarRepo(CarRentalDbContext context) 
            :base(context)
        {
        }

        public async Task CreateAsync(Car entity)
        {

            _context.Add(entity);
             await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            _context.Cars.Remove(car);
             await _context.SaveChangesAsync(); ;
        }

        public async Task<List<Car>> GetAllAsync()
        {
            return await _context.Cars.ToListAsync();
        }

        public async Task<Car> GetByIdAsync(int id)
        {
            return await _context.Cars
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task UpdateAsync(Car entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public bool Exists(int id)
        {
            return _context.Cars.Any(e => e.Id == id);
        }
    }
}
