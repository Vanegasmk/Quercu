using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuercuBackend.Repository.Interfaces
{
    public interface IGenericRepository<IEntity> where IEntity : class
    {
        Task<IEnumerable<IEntity>> GetAll();
        Task<IEntity> GetById(int id);
        Task<IEntity> Create(IEntity entity);
        Task<IEntity> Update(IEntity entity);
        Task Delete(int id);

    }
}
