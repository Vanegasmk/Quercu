using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuercuBackend.Data;
using QuercuBackend.Interfaces;
using QuercuBackend.Models;
using QuercuBackend.Services;
using QuercuBackend.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuercuBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OwnerController : ControllerBase, IOwnerService
    {
        private readonly PropertiesContext _context;

        public OwnerController(PropertiesContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Owner>>> GetAll()
        {
            IEnumerable<Owner> owners = null;
            try
            {
                owners = await _context.Owners.ToListAsync();
                return Ok(owners);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        [Route("Delete")]
        public async Task<ActionResult<IEnumerable<Owner>>> OwnerDelete(int id)
        {
            Owner owner = null;
            try
            {
                owner = await _context.Owners.FindAsync(id);

                if (owner == null)
                {
                    return NotFound();
                }

                _context.Owners.Remove(owner);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(OwnerDelete), new { id = owner.Id }, owner);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        

        [HttpPost]
        [Route("Save")]
        public async Task<ActionResult<IEnumerable<Owner>>> Save([FromBody]Owner owner)
        {
            int regress = 0;

            Owner ownerFind = null;

            try
            {
                ownerFind =  await _context.Owners.FindAsync(owner.Id);

                if (ownerFind == null)
                {
                    _context.Owners.Add(owner);
                }
                else
                {
                    _context.Entry(owner).State = EntityState.Modified;
                }

                regress = _context.SaveChanges();

                if (regress >= 0)
                    ownerFind = await _context.Owners.FindAsync(owner.Id);
                return Ok(ownerFind);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
