using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental
{
    internal class Vehicle
    {
        public string Model { get; set; }
        public string Brand { get; set; }
        public int Year { get; set; }

        public Vehicle(string model, string brand, int year)
        {
            Model = model;
            Brand = brand;
            Year = year;
        }

        public override string ToString()
        {
            return $"Model: {Model}, Brand: {Brand}, Year: {Year}";
        }
    }
}
