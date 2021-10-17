using Microsoft.EntityFrameworkCore;
using QuercuBackend.Data;
using QuercuBackend.Models;
using QuercuBackend.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuercuBackend.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly PropertiesContext _context;

        public OwnerRepository(PropertiesContext context)
        {
            _context = context;
        }

        public IEnumerable<Owner> GetAll()
        {
            try
            {
                IEnumerable<Owner> owners =  _context.Owners.ToList();
                return owners;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public Owner GetOwnerById(int id)
        {
            Owner owner = null;

            try
            {
                owner = _context.Owners.Where(x => x.Id == id).FirstOrDefault();
                return owner;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public Owner OwnerDelete(int id)
        {
            Owner owner = null;
            try
            {
                owner = _context.Owners.Find(id);

                if (owner == null)
                {
                    return null;
                }

                _context.Owners.Remove(owner);
                _context.SaveChanges();

                return owner;

            }
            catch (Exception)
            {

                throw;
            }
        }



        public Owner Save(Owner owner)
        {
            int regress = 0;

            Owner ownerFind = null;

            try
            {
                ownerFind = GetOwnerById(owner.Id);

                if (ownerFind == null)
                {
                    _context.Owners.Add(owner);
                }
                else
                {
                    _context.Entry(owner).State = EntityState.Modified;
                }

                regress = _context.SaveChanges();

                if (regress >= 0)
                    ownerFind = GetOwnerById(owner.Id);
                return ownerFind;

            }
            catch (Exception)
            {

                throw;
            }

        }


    }
}
