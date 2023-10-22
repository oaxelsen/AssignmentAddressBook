using Uppgift.Interfaces;

namespace Uppgift.Models;

public class Customer : ICustomer
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public IAddress? Address { get; set; }
    public string? FullName => $"{FirstName} {LastName}";
}