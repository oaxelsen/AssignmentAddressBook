using Newtonsoft.Json;
using Uppgift.Interfaces;

namespace Uppgift.Services;

// Implementerar ICustomerService interfacet
public class CustomerService : ICustomerService
{
    // Skapar en lista för att spara kunder
    private readonly List<ICustomer> _customers = new List<ICustomer>();

    // Sökvägen där kundinformation sparas
    private readonly string _filePath = @"C:\Users\ossia\OneDrive\Skrivbord\customers.json";

    
    public async Task AddACustomerAsync(ICustomer customer)
    {
        _customers.Add(customer);

        // Konverterar listan av kunder till json-format
        var json = JsonConvert.SerializeObject(_customers, Formatting.Indented);
        await SaveJsonToFileAsync(_filePath, json);
    }

    // Sparar skapad kund till en json-fil
    private static async Task SaveJsonToFileAsync(string filePath, string json)
    {
        // Skriver ner data till json-filen
        using (StreamWriter streamWriter = new StreamWriter(filePath))
        {
            await streamWriter.WriteAsync(json);
        }
    }

    // Hämtar kundinformation ifrån json-filen
    public void Deserialize()
    {
        if (File.Exists(_filePath))
        {
            var json = File.ReadAllText(_filePath);
            _customers.Clear();
            _customers.AddRange(JsonConvert.DeserializeObject<List<ICustomer>>(json)!);
        }
    }

    // Hämtar alla kunder
    public IEnumerable<ICustomer> GetAllCustomers()
    {
        return _customers;
    }

    // Hämtar en kund utifrån e-postadress
    public ICustomer GetACustomer(string email)
    {
        return _customers.FirstOrDefault(x => x.Email == email)!;
    }

    // Raderar en kund utifrån e-postadress
    public void RemoveACustomer(string email)
    {
        var customer = GetACustomer(email);
        _customers.Remove(customer);
    }
}