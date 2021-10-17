using Microsoft.AspNetCore.Mvc;
using QuercuBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuercuBackend.Repository.Interfaces
{
    public interface IOwnerRepository
    {
        IEnumerable<Owner> GetAll();
        Owner GetOwnerById(int id);

        Owner Save(Owner owner);
        Owner OwnerDelete(int id);
    }
}
