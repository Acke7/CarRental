using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental
{
    public class Rental
    {
        public Car RentedCar { get; set; }
        public Customer Customer { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Rental(Car car, Customer customer, DateTime startDate, DateTime endDate)
        {
            RentedCar = car;
            Customer = customer;
            StartDate = startDate;
            EndDate = endDate;
        }

        public decimal CalculateTotalPrice()
        {
            int rentalDays = (EndDate - StartDate).Days;
            return rentalDays * RentedCar.PricePerDay;
        }
    }

}
