namespace Uppgift.Interfaces;

// "string?" innebär att strängen som deklareras kan vara tom (nullable)
public interface IAddress
{
    public string? StreetName { get; set; }
    public string? StreetNumber { get; set; }
    public string? PostalCode { get; set; }
    public string? City { get; set; }
    public string? FullAddress { get; }
}