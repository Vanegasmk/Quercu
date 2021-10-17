using Microsoft.AspNetCore.Mvc;
using QuercuBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuercuBackend.Repository.Interfaces
{
    public interface IPropertyTypeRepository
    {
        IEnumerable<PropertyType> GetAll();
        PropertyType GetPropertyTypeById(int id);

        PropertyType Save(PropertyType propertyType);
        PropertyType PropertyTypeDelete(int id);
    }
}
