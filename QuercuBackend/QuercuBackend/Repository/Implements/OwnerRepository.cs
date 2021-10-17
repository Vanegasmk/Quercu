using QuercuBackend.Data;
using QuercuBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuercuBackend.Repository.Implements
{
    public class OwnerRepository : GenericRepository<Owner>
    {
        public OwnerRepository(PropertiesContext propertiesContext) : base(propertiesContext)
        {

        }
    }
}
