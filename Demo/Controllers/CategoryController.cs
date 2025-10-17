using Demo.DTOs.ArtPieceDtos;
using Demo.DTOs.CategoryDtos;
using Demo.Repositories.CategoryRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepo _categoryRepo;

        public CategoryController(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var cat = await _categoryRepo.GetAllCateogriesAsync();

            if (cat.Count() == 0)
                return NotFound();

            var categories = cat.Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                CountOfArtPieces = c.ArtPieces.Count(),
                ArtPieces = c.ArtPieces.Select(a => new ArtPieceDto
                {
                    Id = a.Id,
                    Title = a.Title,
                    Description = a.Description ?? "Default Description",
                    Price = a.Price,
                }).ToList()
            }).OrderByDescending(c => c.CountOfArtPieces)
            .ToList();

            return Ok(categories);
        }


        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCategoryById(int id)
        {
            var cat = await _categoryRepo.GetCategoryById(id);

            if (cat == null)
                return NotFound();

            if (cat.ArtPieces.Count() > 0)
                return BadRequest("Can't delete the cateogry");

            _categoryRepo.Delete(cat);
            await _categoryRepo.SaveChangesAsync();

            return Ok();
        }
    }
}
