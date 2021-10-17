using Microsoft.EntityFrameworkCore;
using QuercuBackend.Data;
using QuercuBackend.Models;
using QuercuBackend.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;


namespace QuercuBackend.Repository
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly PropertiesContext _context;

        public PropertyRepository(PropertiesContext context)
        {
            _context = context;
        }

        public IEnumerable<Property> GetAll()
        {
            try
            {
                IEnumerable<Property> properties = _context.Properties.Include(x => x.Owner).
                                                                       Include(x => x.PropertyType).
                                                                       ToList();
                return properties;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public Property GetPropertyById(int id)
        {
            Property property = null;

            try
            {
                property = _context.Properties.Where(x => x.Id == id).FirstOrDefault();
                return property;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public Property PropertyDelete(int id)
        {
            Property property = null;
            try
            {
                property = _context.Properties.Find(id);

                if (property == null)
                {
                    return null;
                }

                _context.Properties.Remove(property);
                _context.SaveChanges();

                return property;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Property Save(Property property)
        {
            int regress = 0;

            Property propertyFind = null;

            try
            {
                propertyFind = GetPropertyById(property.Id);

                if (propertyFind == null)
                {
                    _context.Properties.Add(property);
                }
                else
                {
                    _context.Entry(property).State = EntityState.Modified;
                }

                regress = _context.SaveChanges();

                if (regress >= 0)
                    propertyFind = GetPropertyById(property.Id);
                return propertyFind;

            }
            catch (Exception)
            {

                throw;
            }

        }


    }
}
