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
        Hangar Create(int InitialCantMax)
        {
            Hangar hangars = new Hangar(InitialCantMax);
            _context.Add(hangars);
            return hangars;
        }


        Hangar? Get(int id)
        {
            return _context.Set<Hangar>().Find(id);
        }


        void Update(Hangar hangars)
        {
            _context.Update(hangars);
        }


        void Delete(Hangar hangars)
        {
            _context.Remove(hangars);
        }
    }
}
