using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental
{
    public class Customer
    {
        public string Name { get; set; }
        public string ContactInfo { get; set; }

        public Customer(string name, string contactInfo)
        {
            Name = name;
            ContactInfo = contactInfo;
        }
    }
}
