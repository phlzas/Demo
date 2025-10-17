using Demo.Data.Models;
using Demo.DTOs.ArtPieceDtos;
using Demo.DTOs.CategoryDtos;
using Demo.Repositories.ArtPieceRepository;
using Demo.Repositories.CategoryRepository;
using Demo.Repositories.CustomerRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtPieceController : ControllerBase
    {
        private readonly IArtPieceRepo _artPieceRepo;
        private readonly ICategoryRepo _categoryRepo;
        private readonly ICustomerRepo _customerRepo;

        public ArtPieceController(IArtPieceRepo artPieceRepo, ICategoryRepo categoryRepo, ICustomerRepo customerRepo)
        {
            _artPieceRepo = artPieceRepo;
            _categoryRepo = categoryRepo;
            _customerRepo = customerRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllArtPieces()
        {
            var arts = await _artPieceRepo.GetAllArtPiecesAsync();

            if (arts.Count() == 0)
                return NotFound();

            var artPieces = arts.Select(a => new ArtPieceDto
            {
                Id = a.Id,
                Title = a.Title,
                Description = a.Description ?? "Deafult",
                Price = a.Price,
                Customer = new CustomCustomer()
                {
                    Id = a.Customer.Id,
                    Name = a.Customer.Name,
                    Email = a.Customer.Email
                },
                Categories = a.Categories.Select(c => new CustomCategory
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToList()
            }).OrderByDescending(a => a.Price)
            .ToList();


            return Ok(artPieces);
        }


        [HttpGet("category")]
        public async Task<IActionResult> GetAllArtPiecesByCategories()
        {

            var arts = await _categoryRepo.GetAllCateogriesAsync();

            if (arts.Count() == 0)
                return NotFound();

            var artPieces = arts.Select(c => new GroupedArtpieces
            {
                Id = c.Id,
                Name = c.Name,
                No_Of_Pieces = c.ArtPieces.Count(),
                AveragePrice = c.ArtPieces.Average(a => a.Price),
                ArtPieces = c.ArtPieces.Select(a => new CustomArt
                {
                    Id = a.Id,
                    Title = a.Title,
                    Description = a.Description ?? "Default Description",
                    Price = a.Price,
                }).ToList()
            }).ToList();

            return Ok(artPieces);
        }


        [HttpGet("distinct-customers")]
        public async Task<IActionResult> GetDistinctCustomers()
        {
            var customers = await _artPieceRepo.GetDistinctCustomers();

            if (customers.Count() == 0)
                return NotFound("There is no Distinct");

            var custs = customers.Select(c => new
            {
                CustomerId = c.Id,
                CustomerName = c.Name,
                CustomerEmail = c.Email,
                Phone = c.Phone
            }).ToList();

            return Ok(custs);
        }

        [HttpGet("category-spending-summary")]
        public async Task<IActionResult> CategorySummary()
        {
            var arts = await _categoryRepo.GetAllCategoriesSummaryAsync();

            if (arts.Count() == 0)
                return NotFound();

            var summary = arts.Select(c => new SummaryDto
            {
                Id = c.Id,
                Name = c.Name,
                Total_Revenue = c.ArtPieces.Where(a => a.CustomerId > 0).Sum(c => c.Price),
                ArtPieces = c.ArtPieces.Where(a => a.CustomerId > 0)
                .Select(a => new SummaryArts
                {
                    Id = a.Id,
                    Title = a.Title,
                    Description = a.Description,
                    Price = a.Price,
                    Customer =  new CusLoayltyDto
                    {
                        Id = a.Customer.Id,
                        Name = a.Customer.Email,
                        Email = a.Customer.Email,
                        loyalityCard = new CustomLoyal
                        {
                            Id = a.Customer.LoyaltyCard.Id,
                            CardNumber = a.Customer.LoyaltyCard.CardNumber,
                            Balance = a.Customer.LoyaltyCard.Balance
                        }
                    }
                }).ToList()
            }).OrderByDescending(c => c.ArtPieces.Count())
            .ToList();

            return Ok(summary);
        }

        [HttpPost]
        public async Task<IActionResult> CreateArtPiece(CreateArtPieceDto dto)
        {
            if (dto == null)
                return BadRequest();

            var customer = _customerRepo.GetByIdAsync(dto.CustomerId);

            if (customer == null)
                return NotFound("Error, Customer Id not Correct");

            var artPiece = new ArtPiece()
            {
                Title = dto.Title,
                Description = dto.Description,
                Price = dto.Price,
                CustomerId = customer.Id,
                Categories = new List<Category>()
            };

            foreach (int catId in dto.CategoriesIds)
            {
                var cat = await _categoryRepo.GetByIdAsync(catId);
                if (cat == null) return NotFound($"Error, Category With Id {catId} not found");
                artPiece.Categories.Add(cat);
            }

            try
            {
                await _artPieceRepo.AddAsync(artPiece);
                await _artPieceRepo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest("The Name must be Unique");
            }
            

            return Ok(dto);
        }

    }
}
