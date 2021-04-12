using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Controllers
{
    public class ClientMVC : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
