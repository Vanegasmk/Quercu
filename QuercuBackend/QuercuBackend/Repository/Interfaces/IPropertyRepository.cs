using Microsoft.AspNetCore.Mvc;
using QuercuBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuercuBackend.Repository.Interfaces
{
    public interface IPropertyRepository
    {
        IEnumerable<Property> GetAll();
        Property GetPropertyById(int id);

        Property Save(Property property);
        Property PropertyDelete(int id);
    }
}
