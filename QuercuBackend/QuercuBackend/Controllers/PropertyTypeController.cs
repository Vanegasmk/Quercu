using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuercuBackend.Data;
using QuercuBackend.Interfaces;
using QuercuBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuercuBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PropertyTypeController : ControllerBase, IPropertyTypeService
    {
        private readonly PropertiesContext _context;

        public PropertyTypeController(PropertiesContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PropertyType>>> GetAll()
        {
            IEnumerable<PropertyType> propertyTypes = null;
            try
            {
                propertyTypes = await _context.PropertyTypes.ToListAsync();
                return Ok(propertyTypes);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        [Route("Delete")]
        public async Task<ActionResult<IEnumerable<PropertyType>>> PropertyTypeDelete(int id)
        {
            PropertyType propertyType = null;
            try
            {
                propertyType = await _context.PropertyTypes.FindAsync(id);

                if (propertyType == null)
                {
                    return BadRequest();
                }

                _context.PropertyTypes.Remove(propertyType);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(PropertyTypeDelete), new { id = propertyType.Id }, propertyType);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPost]
        public async Task<ActionResult<IEnumerable<PropertyType>>> Save([FromBody] PropertyType propertyType)
        {
            int regress = 0;

            PropertyType propertyTypeFind = null;

            try
            {
                propertyTypeFind = await _context.PropertyTypes.FindAsync(propertyType.Id);

                if (propertyTypeFind == null)
                {
                    _context.PropertyTypes.Add(propertyType);
                }
                else
                {
                    _context.Entry(propertyTypeFind).CurrentValues.SetValues(propertyType);
                }

                regress = _context.SaveChanges();

                if (regress >= 0)
                    propertyTypeFind = await _context.PropertyTypes.FindAsync(propertyType.Id);
                return Ok(propertyTypeFind);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("PropertyType")]
        public async Task<ActionResult<IEnumerable<PropertyType>>> GetPropertyTypeById(int id)
        {
            PropertyType propertyType = null;

            try
            {
                propertyType = await _context.PropertyTypes.Where(x => x.Id == id).FirstOrDefaultAsync();
                return Ok(propertyType);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
