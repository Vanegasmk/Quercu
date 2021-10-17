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
        Task<ActionResult<IEnumerable<Property>>> Save(Property property);
        Task<ActionResult<IEnumerable<Property>>> PropertyDelete(int id);
    }
}
