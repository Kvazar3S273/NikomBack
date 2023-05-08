using AutoMapper;
using Data.Nikom;
using Data.Nikom.Entities.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nikom.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Nikom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly AppEFContext _context;
        private readonly IMapper _mapper;
        public CategoryController(AppEFContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [Route("categories")]
        public async Task<IActionResult> GetCategoriesList()
        {
            var categories = await _context.Categories.Select(category => _mapper.Map<CategoryViewModel>(category)).ToListAsync();
            if (!categories.Any())
            {
                return BadRequest("There are no categories to display");
            }
            if (categories != null)
            {
                return Ok(categories);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("category/{id:int}")]
        public async Task<ActionResult> GetCategoryById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid value");
            }
            var item = await _context.Categories.Where(x => x.Id == id).Select(y => _mapper.Map<CategoryViewModel>(y)).SingleOrDefaultAsync();
            if (item != null)
            {
                return Ok(item);
            }
            return NotFound();
        }

        [HttpPost]
        [Route("add")]
        public async Task<ActionResult> CreateCategoryAsync([FromBody] CategoryCreateViewModel createViewModel)
        {
            var item = new Category
            {
                Name = createViewModel.CategoryName
            };
            _context.Categories.Add(item);
            await _context.SaveChangesAsync();
            return Ok(item);
        }

        [HttpPatch]
        [Route("edit/{id:int}")]
        public async Task<ActionResult> EditCategoryAsync(int id, [FromBody] CategoryCreateViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            var editItem = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (editItem == null)
            {
                return NotFound();
            }
            editItem.Name = model.CategoryName;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete]
        [Route("deletecategory/{id:int}")]
        public async Task<ActionResult> DeleteCategoryAsync(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid value");
            }
            var item = await _context.Categories.SingleOrDefaultAsync(x => x.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
