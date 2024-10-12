using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental
{
    internal class RentalSystem
    {
        Car car;
        List<Car> cars = new List<Car>();
        public void AddCar()
        {
            car = new Car("E90", "Ferari", 2024, 15000, true);
            cars.Add(car);
            car = new Car("F30", "Bmw", 2016, 2500, true);
            cars.Add(car);
            car = new Car("Corola", "Toyota", 2011, 1000, true);
            cars.Add(car);
        }
        public void DeleteCar(string carModel)
        {

            var carToRemove = cars.FirstOrDefault(c => c.Model == carModel);
            if (carToRemove != null)
            {
                cars.Remove(carToRemove);
            }
           
        }
        public List<Car> carsList()
        {
            return cars;
        }
    }
}
