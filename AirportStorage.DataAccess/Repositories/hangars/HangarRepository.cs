using AirportStorage.DataAccess.Abstract.hangars;
using AirportStorage.Domain.Entities.company;
using AirportStorage.Domain.Entities.Hangar;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AirportStorage.DataAccess.Repositories
{
    public partial class ApliccationRepository : IHangarRepository
    {
        public Hangar Create(int InitialCantMax,Company company)
        {
            Hangar hangars = new Hangar(InitialCantMax,company);
            _context.Add(hangars);
            return hangars;
        }


       Hangar? IHangarRepository.Get(int id)
        {
            return _context.Set<Hangar>().Find(id);
        }


        public void Update(Hangar hangars)
        {
            _context.Update(hangars);
        }


       public void Delete(Hangar hangars)
        {
            _context.Remove(hangars);
        }
    }
}
