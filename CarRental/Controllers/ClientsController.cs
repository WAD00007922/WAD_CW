using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarRental.DAL;
using CarRental.Models;
using CarRental.DAL.DBO;
using CarRental.DAL.Repositories;

namespace CarRental.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IRepository<Client> _clientRepo;
        private readonly IRepository<Car> _carRepo;
        public ClientsController(IRepository<Client> clientRepo, IRepository<Car> carRepo)
        {
            _clientRepo = clientRepo;
            _carRepo = carRepo;
        }

        // GET: Clients
        public async Task<IActionResult> Index()
        {
           return View(await _clientRepo.GetAllAsync());
        }

        // GET: Clients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _clientRepo.GetByIdAsync(id.Value);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // GET: Clients/Create
        public async Task<IActionResult> Create()
        {
            ViewData["CarId"] = new SelectList(await _carRepo.GetAllAsync(), "Id", "Name");
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,DateOfBirth,Gender,Email,Phone,AddressLine1,AddressLine2,CarId,DrivingLicesnsenNo")] Client client)
        {
            if (ModelState.IsValid)
            {
                await _clientRepo.CreateAsync(client);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarId"] = new SelectList(await _carRepo.GetAllAsync(), "Id", "Name", client.CarId);
            return View(client);
        }

        // GET: Clients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _clientRepo.GetByIdAsync(id.Value);
            if (client == null)
            {
                return NotFound();
            }
            ViewData["CarId"] = new SelectList(await _carRepo.GetAllAsync(), "Id", "Name", client.CarId);
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,DateOfBirth,Gender,Email,Phone,AddressLine1,AddressLine2,CarId,DrivingLicesnsenNo")] Client client)
        {
            if (id != client.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _clientRepo.UpdateAsync(client);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_clientRepo.Exists(client.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarId"] = new SelectList(await _carRepo.GetAllAsync(), "Id", "Name", client.CarId);
            return View(client);
        }

        // GET: Clients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _clientRepo.GetByIdAsync(id.Value);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _clientRepo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
