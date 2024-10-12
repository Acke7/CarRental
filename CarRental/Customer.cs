using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental
{
    internal class Customer
    {
        public string Name { get; set; }
        public string ContactInfo { get; set; }
        public List<Rental> RentalHistory { get; set; }
    }
}
