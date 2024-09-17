using Microsoft.AspNetCore.Mvc;
using CustomerMvc.Models;

namespace CustomerMvc.Controllers
{
    public class CustomerController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;

        // URL of the API
        private readonly string apiUrl = "http://localhost:5035/api/customers";

        public CustomerController(IConfiguration configuration)
        {
            _httpClient = new HttpClient();

            // Retrieve API URL from configuration
            _apiUrl = configuration.GetValue<string>("ApiSettings:BaseAPIUrl");
        }

        // Fetch all customers and display in the view
        public async Task<IActionResult> Index()
        {
            var customers = await _httpClient.GetFromJsonAsync<List<Customer>>(apiUrl);
            return View(customers);
        }

        // Show the form to add a new customer
        public IActionResult Create()
        {
            return View();
        }

        // Submit the form to add a new customer
        [HttpPost]
        public async Task<IActionResult> Create(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View(customer);
            }

            var response = await _httpClient.PostAsJsonAsync(apiUrl, customer);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError(string.Empty, "An error occurred while creating the customer.");
            return View(customer);
        }

        // Show the edit form with customer data
        public async Task<IActionResult> Edit(int id)
        {
            var customer = await _httpClient.GetFromJsonAsync<Customer>($"{apiUrl}/{id}");
            return View(customer);
        }

        // Submit the form to edit a customer
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View(customer);
            }

            var response = await _httpClient.PutAsJsonAsync($"{apiUrl}/{id}", customer);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError(string.Empty, "An error occurred while updating the customer.");
            return View(customer);
        }

        // Delete a customer by ID
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"{apiUrl}/{id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError(string.Empty, "An error occurred while deleting the customer.");
            return RedirectToAction(nameof(Index));
        }
    }
}
