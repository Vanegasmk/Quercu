using Microsoft.EntityFrameworkCore;
using QuercuBackend.Data;
using QuercuBackend.Models;
using QuercuBackend.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuercuBackend.Repository
{
    public class PropertyTypeRepository : IPropertyTypeRepository
    {
        private readonly PropertiesContext _context;

        public PropertyTypeRepository(PropertiesContext context)
        {
            _context = context;
        }

        public IEnumerable<PropertyType> GetAll()
        {
            try
            {
                IEnumerable<PropertyType> propertyTypes = _context.PropertyTypes.ToList();
                return propertyTypes;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public PropertyType GetPropertyTypeById(int id)
        {
            PropertyType propertyType = null;

            try
            {
                propertyType = _context.PropertyTypes.Where(x => x.Id == id).FirstOrDefault();
                return propertyType;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public PropertyType PropertyTypeDelete(int id)
        {
            PropertyType propertyType = null;
            try
            {
                propertyType = _context.PropertyTypes.Find(id);

                if (propertyType == null)
                {
                    return null;
                }

                _context.PropertyTypes.Remove(propertyType);
                _context.SaveChanges();

                return propertyType;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public PropertyType Save(PropertyType propertyType)
        {
            int regress = 0;

            PropertyType propertyTypeFind = null;

            try
            {
                propertyTypeFind = GetPropertyTypeById(propertyType.Id);

                if (propertyTypeFind == null)
                {
                    _context.PropertyTypes.Add(propertyType);
                }
                else
                {
                    _context.Entry(propertyType).State = EntityState.Modified;
                }

                regress = _context.SaveChanges();

                if (regress >= 0)
                    propertyTypeFind = GetPropertyTypeById(propertyType.Id);
                return propertyTypeFind;

            }
            catch (Exception)
            {

                throw;
            }

        }



    }
}
