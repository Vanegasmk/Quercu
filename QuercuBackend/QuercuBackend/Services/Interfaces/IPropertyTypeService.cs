using Microsoft.AspNetCore.Mvc;
using QuercuBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuercuBackend.Services.Interfaces
{
    public interface IPropertyTypeService
    {
        Task<ActionResult<IEnumerable<PropertyType>>> GetAll();
        Task<ActionResult<PropertyType>> GetOwnerById(int id);

        Task<ActionResult<PropertyType>> Update(int id, PropertyType propertyType);
        Task<ActionResult<PropertyType>> Delete(int id);
    }
}
