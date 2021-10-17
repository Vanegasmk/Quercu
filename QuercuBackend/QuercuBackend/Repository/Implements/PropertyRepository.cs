using QuercuBackend.Data;
using QuercuBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuercuBackend.Repository.Implements
{
    public class PropertyRepository : GenericRepository<Property>
    {
        public PropertyRepository(PropertiesContext propertiesContext) : base(propertiesContext)
        {
               
        }
    }
}
