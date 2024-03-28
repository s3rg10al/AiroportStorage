using AirportStorage.DataAccess.Abstract.Stores;
using AirportStorage.DataAccess.Abstract.Workshops;
using AirportStorage.Domain.Entities.company;
using AirportStorage.Domain.Entities.Store;
using AirportStorage.Domain.Entities.Workshop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportStorage.DataAccess.Repositories
{
    public partial class ApliccationRepository :IWorkshopRepository
    {
      public Workshop CreateWorkshop(uint ability, Store store, Company company)
        {
            Workshop workshop = new Workshop(ability, store, company);
            _context.Add(workshop);
            return workshop;
        }
        Workshop? IWorkshopRepository.GetWorkshop(int id)
        {
            return _context.Set<Workshop>().Find(id);
        }
        public IEnumerable<Workshop> GetAllWorkshop()
        {
            return _context.Set<Workshop>().ToList();
        }

        public void Update(Workshop workshop)
        {
            _context.Update(workshop);
        }
        public void Delete(Workshop workshop)
        {
            _context.Remove(workshop);
        }


    }
}
