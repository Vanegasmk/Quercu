using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuercuBackend.Repository.Interfaces
{
    interface IGenericRepository<IEntity> where IEntity : class
    {
        Task<IEnumerable<IEntity>> GetAll();
        Task<IEntity> GetById(int id);
        Task<IEntity> Create();
        Task<IEntity> Update();
        Task Delete(int id);

    }
}
