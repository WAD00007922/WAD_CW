﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Client> Clients { get; set; }

    }
}
