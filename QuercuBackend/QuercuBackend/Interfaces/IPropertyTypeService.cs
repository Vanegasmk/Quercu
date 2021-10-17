using Microsoft.AspNetCore.Mvc;
using QuercuBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuercuBackend.Interfaces
{
    public interface IPropertyTypeService
    {
        Task<ActionResult<IEnumerable<PropertyType>>> GetAll();
        Task<ActionResult<IEnumerable<PropertyType>>> Save(PropertyType propertyType);
        Task<ActionResult<IEnumerable<PropertyType>>> PropertyTypeDelete(int id);
    }
}
