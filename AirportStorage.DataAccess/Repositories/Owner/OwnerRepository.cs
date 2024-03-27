using AirportStorage.DataAccess.Abstract.Owners;
using AirportStorage.DataAccess.Abstract.Plane;
using AirportStorage.Domain.Entities.Owner;
using AirportStorage.Domain.Entities.Planes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportStorage.DataAccess.Repositories
{
    public partial class ApliccationRepository : IOwnerRepository
    {
        public Owner CreateOwner(string nomb, uint id, uint cantjets)
        {
            Owner owner = new Owner(nomb, id, cantjets);
            _context.Add(owner);
            return owner;
        }

        Owner? IOwnerRepository.Get(int id)
        {
            return _context.Set<Owner>().Find(id);
        }
        public IEnumerable<Owner> GetAllOwner()
        {
            return _context.Set<Owner>().ToList();
        }


        public void Update(Owner owner)
        {
            _context.Update(owner);
        }


        public void Delete(Owner owner)
        {
            _context.Remove(owner);
        }
    }
}
