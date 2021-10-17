using Microsoft.EntityFrameworkCore;
using QuercuBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuercuBackend.Data
{
    public class PropertiesContext : DbContext
    {
        public PropertiesContext(DbContextOptions<PropertiesContext> options) : base(options)
        {

        }

        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyType> PropertyTypes { get; set; }
        public DbSet<Owner> Owners { get; set; }
    }
}
