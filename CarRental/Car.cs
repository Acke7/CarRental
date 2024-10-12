using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental
{
    internal class Car : Vehicle
    {
        public int PricePerDay { get; set; }
        public bool IsAvailable { get; set; }

        public Car(string model, string brand, int year, int pricePerDay, bool isAvailable)
            : base(model, brand, year)
        {
            PricePerDay = pricePerDay;
            IsAvailable = isAvailable;
        }

        public override string ToString()
        {
            return $"Model: {Model}, Brand: {Brand}, Year: {Year}, PricePerDay: {PricePerDay}, IsAvailable: {IsAvailable}";
        }
    }
  
}
