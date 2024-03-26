using AirportStorage.DataAccess.Abstract.Stores;
using AirportStorage.Domain.Entities.Store;
using AirportStorage.Domain.Entities.Workshop;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportStorage.DataAccess.Repositories
{
    public partial class ApliccationRepository :IStoreRepository
    {
     public Store CreateStore(uint cantPiezas, DateTime lastInv, Workshop workshop)
        {
            Store store = new Store(cantPiezas, lastInv,workshop);
            _context.Add(store);
            return store;
        }
        Store? IStoreRepository.Get(int id)
        {
            return _context.Set<Store>().Find(id);
        }
        public IEnumerable<Store> GetAllStore()
        {
            return _context.Set<Store>().ToList();
        }


        public void Update(Store store)
        {
            _context.Update(store);
        }


        public void Delete(Store store)
        {
            _context.Remove(store);
        }

    }
}
