namespace Uppgift.Interfaces;

public interface ICustomerService
{
    // Lägger till en kund
    public Task AddACustomerAsync(ICustomer customer);

    // Hämtar alla kunder
    public IEnumerable<ICustomer> GetAllCustomers();

    // Hämtar en kund utifrån deras e-postadress
    public ICustomer GetACustomer(string email);

    // Raderar en kund utifrån deras e-postadress
    public void RemoveACustomer(string email);
}