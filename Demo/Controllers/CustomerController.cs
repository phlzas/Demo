using Demo.DTOs.CustomerDtos;
using Demo.Repositories.CustomerRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepo _customerRepo;

        public CustomerController(ICustomerRepo customerRepo)
        {
            _customerRepo = customerRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var cus = await _customerRepo.GetAllCustomersWithInformation();

            if (cus  == null) 
                return NotFound();


            var customers = cus.Select(c => new CustomerDto
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Email,
                Phone = c.Phone,
                TotalSpending = c.ArtPieces.Sum(a => a.Price),
                Card = new Card()
                {
                    Id = c.LoyaltyCard.Id,
                    CardNumber = c.LoyaltyCard.CardNumber,
                    Balance = c.LoyaltyCard.Balance
                },
                CustomArtPieces = c.ArtPieces.Select(a => new CustomArtPieces
                {
                    Id = a.Id,
                    Title = a.Title,
                    Description = a.Description ?? "Default Des",
                    Price = a.Price
                }).ToList()
            })
            .OrderByDescending(a => a.TotalSpending)
            .ToList();

            //var orderedCustomers = customers.OrderByDescending(a => a.TotalSpending);


            return Ok(customers);
        }


    }
}
