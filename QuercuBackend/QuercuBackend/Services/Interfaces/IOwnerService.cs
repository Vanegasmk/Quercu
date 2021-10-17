using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuercuBackend.Services.Interfaces
{
    public interface IOwnerService
    {
        Task<ActionResult<IEnumerable<Owner>>> GetAll();
        Task<ActionResult<Owner>> GetOwnerById(int id);

        Task<ActionResult<Owner>> Update(int id, Owner owner);
        Task<ActionResult<Owner>> Delete(int id);
    }
}
