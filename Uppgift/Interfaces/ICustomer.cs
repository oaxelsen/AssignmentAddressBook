namespace Uppgift.Interfaces;

public interface ICustomer
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? FullName { get; }

    // Implementerar IAddress "interfacet"
    public IAddress? Address { get; set; }
}