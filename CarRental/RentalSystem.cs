using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental
{
    internal class RentalSystem
    {
        static List<Car> carList = new List<Car>
         {
        new Car(1, "Toyota Corolla", "Toyota", 30),
        new Car(2, "Honda Civic", "Honda", 28)
       };

        public List<Rental> rentalHistory = new List<Rental>();

        public  void SalerMenu()
        {
            while (true)
            {
                Console.WriteLine("\nSaler Menu:");
                Console.WriteLine("1. Rent a car");
                Console.WriteLine("2. Return a car");
                Console.WriteLine("3. View available cars");
                Console.WriteLine("4. Exit");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        RentCar();
                        break;
                    case "2":
                        ReturnCar();
                        break;
                    case "3":
                        ViewAvailableCars();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid choice, try again.");
                        break;
                }
            }
        }

        public void RentCar()
        {
            ViewAvailableCars();

            Console.Write("Enter car ID to rent: ");
            int carId = int.Parse(Console.ReadLine());

            var car = carList.FirstOrDefault(c => c.Id == carId && c.IsAvailable);
            if (car != null)
            {
                Console.Write("Enter customer name: ");
                string customerName = Console.ReadLine();
                Console.Write("Enter customer contact: ");
                string contact = Console.ReadLine();

                Console.Write("Enter rental start date (yyyy-mm-dd): ");
                DateTime startDate = DateTime.Parse(Console.ReadLine());
                Console.Write("Enter rental end date (yyyy-mm-dd): ");
                DateTime endDate = DateTime.Parse(Console.ReadLine());

                var customer = new Customer(customerName, contact);
                var rental = new Rental(car, customer, startDate, endDate);

                car.IsAvailable = false;
                rentalHistory.Add(rental);

                Console.WriteLine($"Car rented successfully. Total Price: {rental.CalculateTotalPrice()}");
            }
            else
            {
                Console.WriteLine("Car not available.");
            }
        }

        public void ReturnCar()
        {
            Console.WriteLine("\nActive Rentals:");
            for (int i = 0; i < rentalHistory.Count; i++)
            {
                var rental = rentalHistory[i];
                if (!rental.RentedCar.IsAvailable)
                {
                    Console.WriteLine($"{i + 1}. {rental.RentedCar.Model} (Rented by {rental.Customer.Name})");
                }
            }

            Console.Write("Enter rental number to return: ");
            int rentalIndex = int.Parse(Console.ReadLine()) - 1;

            if (rentalIndex >= 0 && rentalIndex < rentalHistory.Count)
            {
                var rental = rentalHistory[rentalIndex];
                rental.RentedCar.IsAvailable = true;
                Console.WriteLine($"Car {rental.RentedCar.Model} returned successfully.");
            }
            else
            {
                Console.WriteLine("Invalid selection.");
            }
        }

        public void ViewAvailableCars()
        {
            Console.WriteLine("\nAvailable Cars:");
            foreach (var car in carList.Where(c => c.IsAvailable))
            {
                Console.WriteLine($"ID: {car.Id}, Model: {car.Model}, Price per day: {car.PricePerDay}");
            }
        }

        public void AdminMenu()
        {
            while (true)
            {
                Console.WriteLine("\nAdmin Menu:");
                Console.WriteLine("1. Add a car");
                Console.WriteLine("2. Delete a car");
                Console.WriteLine("3. View all cars (including unavailable)");
                Console.WriteLine("4. Exit");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddCar();
                        break;
                    case "2":
                        DeleteCar();
                        break;
                    case "3":
                        ViewAllCars();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid choice, try again.");
                        break;
                }
            }
        }

        public void AddCar()
        {
            Console.Write("Enter car model: ");
            string model = Console.ReadLine();

            Console.Write("Enter car brand: ");
            string brand = Console.ReadLine();

            Console.Write("Enter price per day: ");
            decimal pricePerDay = decimal.Parse(Console.ReadLine());

            int newCarId = carList.Any() ? carList.Max(c => c.Id) + 1 : 1; // Generate a new unique ID for the car

            Car newCar = new Car(newCarId, model, brand, pricePerDay);
            carList.Add(newCar);

            Console.WriteLine($"Car {model} added successfully!");
        }

        public void DeleteCar()
        {
            Console.WriteLine("\nAvailable Cars for Deletion:");
            foreach (var car in carList)
            {
                Console.WriteLine($"ID: {car.Id}, Model: {car.Model}, Brand: {car.Brand}, Price per day: {car.PricePerDay}, Available: {car.IsAvailable}");
            }

            Console.Write("Enter car ID to delete: ");
            int carId = int.Parse(Console.ReadLine());

            var carToDelete = carList.FirstOrDefault(c => c.Id == carId);
            if (carToDelete != null)
            {
                carList.Remove(carToDelete);
                Console.WriteLine($"Car {carToDelete.Model} deleted successfully.");
            }
            else
            {
                Console.WriteLine("Car not found.");
            }
        }

        public void ViewAllCars()
        {
            Console.WriteLine("\nAll Cars:");
            foreach (var car in carList)
            {
                Console.WriteLine($"ID: {car.Id}, Model: {car.Model}, Brand: {car.Brand}, Price per day: {car.PricePerDay}, Available: {car.IsAvailable}");
            }
        }



    }
}
