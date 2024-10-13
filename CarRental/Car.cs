using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public decimal PricePerDay { get; set; }
        public bool IsAvailable { get; set; }

        public Car(int id, string model, string brand, decimal pricePerDay)
        {
            Id = id;
            Model = model;
            Brand = brand;
            PricePerDay = pricePerDay;
            IsAvailable = true; // By default, a car is available
        }
    }

}
