using CustomerApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
    private static List<Customer> Customers = new List<Customer>
    {
        // Names are not real, just for demonstration purposes
        new Customer { Id = 1, Name = "Fadi Akkad", Email = "fadiakkad94@gmail.com" },
        new Customer { Id = 2, Name = "Jane Smith", Email = "jane.smith@example.com" },
        new Customer { Id = 3, Name = "Alice Johnson", Email = "alice.johnson@example.com" },
        new Customer { Id = 4, Name = "Bob Brown", Email = "bob.brown@example.com" },
        new Customer { Id = 5, Name = "Carol White", Email = "carol.white@example.com" }
    };

    [HttpGet]
    public ActionResult<IEnumerable<Customer>> GetCustomers()
    {
        return Ok(Customers);
    }

    [HttpGet("{id}")]
    public ActionResult<Customer> GetCustomer(int id)
    {
        var customer = Customers.FirstOrDefault(c => c.Id == id);
        if (customer == null) return NotFound();
        return Ok(customer);
    }

    [HttpPost]
    public ActionResult<Customer> CreateCustomer(Customer customer)
    {
        customer.Id = Customers.Max(c => c.Id) + 1;
        Customers.Add(customer);
        return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCustomer(int id, Customer updatedCustomer)
    {
        var customer = Customers.FirstOrDefault(c => c.Id == id);
        if (customer == null) return NotFound();
        customer.Name = updatedCustomer.Name;
        customer.Email = updatedCustomer.Email;
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCustomer(int id)
    {
        var customer = Customers.FirstOrDefault(c => c.Id == id);
        if (customer == null) return NotFound();
        Customers.Remove(customer);
        return NoContent();
    }
}
