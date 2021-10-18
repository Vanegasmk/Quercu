using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuercuBackend.Data;
using QuercuBackend.Models;
using QuercuBackend.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuercuBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PropertyController : ControllerBase, IPropertyService
    {
        private readonly PropertiesContext _context;

        public PropertyController(PropertiesContext context)
        {
            _context = context;
        }

        #region
        /// <summary>
        /// GetAll
        /// </summary>
        /// <returns>Return all Properties</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Property>>> GetAll()
        {
            IEnumerable<Property> properties = null;
            try
            {
                properties = await _context.Properties.Include(x => x.Owner)
                                                      .Include(x => x.PropertyType)
                                                      .ToListAsync();
                return Ok(properties);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
        #endregion

        #region
        /// <summary>
        /// PropertyDelete
        /// </summary>
        /// <param name="id">Id From Property Object</param>
        /// <returns>Return a Property Delete</returns>
        [HttpPost]
        [Route("Delete")]
        public async Task<ActionResult<IEnumerable<Property>>> PropertyDelete(int id)
        {
            Property property = null;
            try
            {
                property = await _context.Properties.FindAsync(id);

                if (property == null)
                {
                    return BadRequest();
                }

                _context.Properties.Remove(property);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(PropertyDelete), new { id = property.Id }, property);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion


        #region
        /// <summary>
        /// Save
        /// </summary>
        /// <param name="property">Property Object</param>
        /// <returns>Return a new Property or Update Property</returns>
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Property>>> Save([FromBody] Property property)
        {
            int regress = 0;

            Property propertyFind = null;

            try
            {
                propertyFind = await _context.Properties.FindAsync(property.Id);

                if (propertyFind == null)
                {
                    _context.Properties.Add(property);
                }
                else
                {
                    _context.Entry(propertyFind).CurrentValues.SetValues(property);
                }

                regress = _context.SaveChanges();

                if (regress >= 0)
                    propertyFind = await _context.Properties.FindAsync(property.Id);
                return Ok(propertyFind);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region
        /// <summary>
        /// GetPropertyById
        /// </summary>
        /// <param name="id">Id From Property Object</param>
        /// <returns>A Property Objet</returns>
        [HttpGet]
        [Route("Property")]
        public async Task<ActionResult<IEnumerable<Property>>> GetPropertyById(int id)
        {
            Property property = null;
            try
            {
                property = await _context.Properties.Where(x => x.Id == id).FirstOrDefaultAsync();
                return Ok(property);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}
