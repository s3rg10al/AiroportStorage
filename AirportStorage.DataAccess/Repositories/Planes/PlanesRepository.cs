using AirportStorage.Domain.Entities.Planes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AirportStorage.DataAccess.Repositories
{
    public partial class ApliccationRepository : IPlanesRepository
    {
        Planes Create(string modelo, string serialnumber, uint cantkmsPM)
        {
            Planes planes = new Planes(modelo, serialnumber, cantkmsPM);
            _context.Add(planes);
            return planes;
        }

       
        Planes? Get(int id)
        {
            return _context.Set<Planes>().Find(id);
        }

       
        void Update(Planes planes)
        {
            _context.Update(planes);
        }

    
        void Delete(Planes planes)
        {
            _context.Remove(planes);
        }
    }
}
