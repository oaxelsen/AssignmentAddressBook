using Uppgift.Interfaces;
using Uppgift.Models;

namespace AddressBook.Tests.Tests;

public class CustomerTests
{
    [Fact]
    public void AddCustomer_ShouldShowCustomerNameInAddressBook()
    {
        // Arrange
        // Skapar en testkund
        ICustomer customer = new Customer
        {
            FirstName = "Test",
            LastName = "Tester"
        };

        // Act
        // Hämtar kundens namn
        string fullName = customer.FullName!;

        // Assert
        // Kollar om det matchar förväntat namn "Test Tester"
        Assert.Equal("Test Tester", fullName);
    }
}
