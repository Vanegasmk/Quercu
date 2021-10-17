using Microsoft.AspNetCore.Mvc;
using QuercuBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuercuBackend.Interfaces
{
    public interface IOwnerService
    {
        Task<ActionResult<IEnumerable<Owner>>> GetAll();
        Task<ActionResult<IEnumerable<Owner>>> Save(Owner owner);
        Task<ActionResult<IEnumerable<Owner>>> OwnerDelete(int id);
    }
}
