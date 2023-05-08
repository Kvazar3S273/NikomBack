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
    public class SubcategoryController : ControllerBase
    {
        private readonly AppEFContext _context;
        private readonly IMapper _mapper;
        public SubcategoryController(AppEFContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [Route("subcategories")]
        public async Task<IActionResult> GetSubCategoriesList()
        {
            var subCategories = await _context.SubCategories.Select(subCategory => _mapper.Map<SubCategoryViewModel>(subCategory)).ToListAsync();
            if (!subCategories.Any())
            {
                return BadRequest("There are no subcategories to display");
            }
            if (subCategories != null)
            {
                return Ok(subCategories);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("subcategory/{id:int}")]
        public async Task<ActionResult> GetSubCategoryById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid value");
            }
            var item = await _context.SubCategories.Where(x => x.Id == id).Select(y => _mapper.Map<SubCategoryViewModel>(y)).SingleOrDefaultAsync();
            if (item != null)
            {
                return Ok(item);
            }
            return NotFound();
        }

        [HttpPost]
        [Route("addsubcat")]
        public async Task<ActionResult> CreateSubCategoryAsync([FromBody] SubcategoryCreateViewModel model)
        {
            var item = new SubCategory
            {
                Name = model.Name
            };
            _context.SubCategories.Add(item);
            await _context.SaveChangesAsync();
            return Ok(item);
        }

        [HttpPatch]
        [Route("editsubcat/{id:int}")]
        public async Task<ActionResult> EditSubCategoryAsync(int id, [FromBody] SubcategoryCreateViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            var editItem = await _context.SubCategories.FirstOrDefaultAsync(x => x.Id == id);
            if (editItem == null)
            {
                return NotFound();
            }
            editItem.Name = model.Name;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete]
        [Route("deletesubcat/{id:int}")]
        public async Task<ActionResult> DeleteSubCategoryAsync(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid value");
            }
            var item = await _context.SubCategories.SingleOrDefaultAsync(x => x.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            _context.SubCategories.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
