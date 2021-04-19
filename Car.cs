using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRental.DAL.DBO;
using Newtonsoft.Json;

namespace CarRental.DAL.DBO
{
    public class Car
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        
        [JsonIgnore]
        public virtual ICollection<Client> Clients { get; set; }
    }
}
