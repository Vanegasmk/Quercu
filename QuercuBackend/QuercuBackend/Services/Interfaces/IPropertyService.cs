using Microsoft.AspNetCore.Mvc;
using QuercuBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuercuBackend.Services.Interfaces
{
    public interface IPropertyService
    {
        Task<ActionResult<IEnumerable<Property>>> GetAll();
        Task<ActionResult<Property>> GetOwnerById(int id);

        Task<ActionResult<Property>> Update(int id, Property property);
        Task<ActionResult<Property>> Delete(int id);
    }
}
