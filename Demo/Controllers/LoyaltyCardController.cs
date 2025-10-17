using Demo.DTOs;
using Demo.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoyaltyCardController : ControllerBase
    {
        private readonly ILoyalityCardRepo _loyalityCardRepo;

        public LoyaltyCardController(ILoyalityCardRepo loyalityCardRepo)
        {
            _loyalityCardRepo = loyalityCardRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLoayltyCards()
        {

            var loyalties = await _loyalityCardRepo.GetAllLoyaltyCardsAsync();

            if (loyalties.Count() == 0)
                return NotFound();

            var lol = loyalties.Select(l => new
            {
                l.Id,
                l.CardNumber,
                l.Balance,
                CustomerName = l.Customer.Name
            }).OrderBy(l => l.CustomerName).ToList();

            return Ok();
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateLoyal(int id, CreateLoyaltyCardDto dto)
        {
            var card = await _loyalityCardRepo.GetByIdAsync(id);

            if (card == null)
                return NotFound();

            card.CardNumber = dto.CardNumber;
            card.Balance = dto.Balance;

            try
            {
                _loyalityCardRepo.Update(card);
                await _loyalityCardRepo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest("Can't Update it, must be unqiue");
            }

            return Ok();
        }
    }
}
