using CarRental;

class Program
{
    static List<User> users = new List<User>
    {
        new User("admin", "Admin"),
        new User("saler1", "Saler"),
        new User("saler2", "Saler")
    };

    static User currentUser;
  

    static void Main(string[] args)
    {
       
        Console.WriteLine("Welcome to the Car Rental System");
        Console.WriteLine("Please log in:");

        Console.Write("Enter username: ");
        string username = Console.ReadLine();

        // Authenticate user
        currentUser = users.FirstOrDefault(u => u.Username == username);

        if (currentUser != null)
        {
            Console.WriteLine($"Welcome, {currentUser.Username} ({currentUser.Role})");
            ShowMenu();
        }
        else
        {
            Console.WriteLine("Invalid username. Exiting...");
        }
    }

    static void ShowMenu()
    {
        RentalSystem rentalSystem = new RentalSystem();
        if (currentUser.Role == "Admin")
        {
            rentalSystem.AdminMenu();
           
        }
        else if (currentUser.Role == "Saler")
        {
            rentalSystem.SalerMenu();
        }
    }

  

 
}
