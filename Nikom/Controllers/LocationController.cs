using AutoMapper;
using Data.Nikom;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using System.Linq;
using Nikom.Models;
using Microsoft.EntityFrameworkCore;
using Data.Nikom.Entities.Products;

namespace Nikom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly AppEFContext _context;
        private readonly IMapper _mapper;
        public LocationController(AppEFContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [Route("locations")]
        public async Task<IActionResult> GetLocationList()
        {
            var locationList = await _context.Locations.Select(location => _mapper.Map<LocationViewModel>(location)).ToListAsync();
            if (!locationList.Any())
            {
                return BadRequest("There are no locations to display");
            }
            if (locationList != null)
            {
                return Ok(locationList);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("location/{id:int}")]
        public async Task<ActionResult> GetLocationById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid value");
            }
            var item = await _context.Locations.Where(x => x.Id == id).Select(y => _mapper.Map<LocationViewModel>(y)).SingleOrDefaultAsync();
            if (item != null)
            {
                return Ok(item);
            }
            return NotFound();
        }

        [HttpPost]
        [Route("addlocation")]
        public async Task<ActionResult> CreateLocationAsync([FromBody] LocationCreateViewModel model)
        {
            var item = new Location
            {
                Name = model.Name,
                //Box = model.Box
            };
            _context.Locations.Add(item);
            await _context.SaveChangesAsync();
            return Ok(item);
        }
        public T? CheckFieldForNull<T>(T mm, string name, T model)
        {
            if (string.IsNullOrEmpty(name))
            {
                return mm;
            }
            return model;
        }
        [HttpPatch]
        [Route("editlocation/{id:int}")]
        public async Task<ActionResult> EditLocationAsync(int id, [FromBody] LocationCreateViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            var editItem = await _context.Locations.FirstOrDefaultAsync(x => x.Id == id);
            if (editItem == null)
            {
                return NotFound();
            }
            //if (editItem.Name != null)
            //{
            //    editItem.Name = model.Name;
            //}

            //editItem.Box = model.Box;
            editItem.Name = CheckFieldForNull(editItem.Name, model.Name, model.Name);
            //editItem.Box = CheckFieldForNull(editItem.Box, model.Box, model.Box);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete]
        [Route("deletelocation/{id:int}")]
        public async Task<ActionResult> DeleteLocationAsync(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid value");
            }
            var item = await _context.Locations.SingleOrDefaultAsync(x => x.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            _context.Locations.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
