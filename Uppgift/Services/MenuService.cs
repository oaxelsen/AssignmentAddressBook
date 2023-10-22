using Uppgift.Interfaces;
using Uppgift.Models;

namespace Uppgift.Services;

public class MenuService
{
    private static readonly ICustomerService customerService = new CustomerService();

    // Metod för att skapa ny kund
    public static void AddCustomerMenu()
    {
        // Skapar ett nytt kundobjekt
        ICustomer customer = new Customer();

        // Frågar användaren om kundinformation
        Console.Write("Förnamn: ");
        customer.FirstName = Console.ReadLine();

        Console.Write("Efternamn: ");
        customer.LastName = Console.ReadLine();

        Console.Write("E-postadress: ");
        customer.Email = Console.ReadLine();

        // Skapar ett nytt adressobjekt
        customer.Address = new Address();

        // Frågar användaren om adressinformation
        Console.Write("Gatuadress: ");
        customer.Address.StreetName = Console.ReadLine();

        Console.Write("Gatunummer ");
        customer.Address.StreetNumber = Console.ReadLine();

        Console.Write("Postnummer: ");
        customer.Address.PostalCode = Console.ReadLine();

        Console.Write("Ort: ");
        customer.Address.City = Console.ReadLine();

        // Lägger till kunden i kundhanteringen
        Task.Run(() => customerService.AddACustomerAsync(customer));
    }

    // Metod för att visa all kunder
    public static void ViewAllCustomersMenu()
    {
        // Hämtar varje kund från kundhanteringen och visar detaljerna
        foreach (var customer in customerService.GetAllCustomers())
        {
            Console.WriteLine(customer.FullName);
            Console.WriteLine(customer.Address?.FullAddress);
            Console.WriteLine();
        }
    }

    // Metod för att visa en kund
    public static void ViewOneCustomerMenu()
    {
        Console.Write("E-postadress: ");
        var email = Console.ReadLine();

        // Hämtar och visar detaljerna av en kund utifrån e-postadress
        var customer = customerService.GetACustomer(email!);
        Console.WriteLine(customer?.FullName);
        Console.WriteLine(customer?.Address?.FullAddress);
        Console.WriteLine();
    }

    // Metod för att ta bort en kund
    public static void RemoveOneCustomerMenu()
    {
        Console.Write("E-postadress: ");
        var email = Console.ReadLine();

        // Tar bort kund utifrån deras e-postadress ("!" innebär att variabeln inte får vara tom)
        customerService.RemoveACustomer(email!);
    }

    // Meny
    public static void Menu()
    {
        do
        {
            Console.Clear();
            Console.WriteLine("1: Skapa en kund");
            Console.WriteLine("2: Visa alla kunder");
            Console.WriteLine("3: Visa en kund");
            Console.WriteLine("4: Ta bort en kund");
            Console.WriteLine("a: Avsluta");
            Console.Write("Välj ett av alternativen: ");
            var option = Console.ReadLine();

            Console.Clear();

            // Lyssnar efter användarens knapptryckning
            switch (option)
            {
                case "1":
                    AddCustomerMenu();
                    break;

                case "2":
                    ViewAllCustomersMenu();
                    break;

                case "3":
                    ViewOneCustomerMenu();
                    break;

                case "4":
                    RemoveOneCustomerMenu();
                    break;

                case "a":
                    Environment.Exit(0);
                    break;
            }

            Console.ReadKey();
        }
        // Fortsätter för alltid
        while (true);
    }
}