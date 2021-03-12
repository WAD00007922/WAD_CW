using CarRental.DAL.DBO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DAL.Repositories
{
    public class ClientRepo : BaseRepo, IRepository<Client>
    {
        public ClientRepo(CarRentalDbContext context) : base(context)
        {
        }
        public async Task CreateAsync(Client entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Client>> GetAllAsync()
        {
            return await _context.Clients.Include(c => c.Car).ToListAsync(); 
        }

        public async Task<Client> GetByIdAsync(int id)
        {
            return await _context.Clients
                .Include(c => c.Car)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task UpdateAsync(Client entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public bool Exists(int id)
        {
            return _context.Clients.Any(p => p.Id == id);
        }
    }
}
