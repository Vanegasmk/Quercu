using Microsoft.EntityFrameworkCore;
using QuercuBackend.Data;
using QuercuBackend.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuercuBackend.Repository.Implements
{
    public class GenericRepository<IEntity>  : IGenericRepository<IEntity> where IEntity: class
    {
        private readonly PropertiesContext propertiesContext;

        public GenericRepository(PropertiesContext propertiesContext)
        {
            this.propertiesContext = propertiesContext;
        }
        
        public async Task<IEnumerable<IEntity>> GetAll()
        {
            return await propertiesContext.Set<IEntity>().ToListAsync();
        }

        public async Task<IEntity> GetById(int id)
        {
            return await propertiesContext.Set<IEntity>().FindAsync(id);
        }

        public async Task<IEntity> Create(IEntity entity)
        {
            propertiesContext.Set<IEntity>().Add(entity);
            await propertiesContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEntity> Update(IEntity entity)
        {
            propertiesContext.Entry(entity).State = EntityState.Modified;
            await propertiesContext.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);

            if (entity == null)
                throw new Exception("The entity is null");

            propertiesContext.Set<IEntity>().Remove(entity);
            await propertiesContext.SaveChangesAsync();
        }

       
    }
}
