using AirportStorage.DataAccess.Abstract.Plane;
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
        public Commercial CreateCommercial(string modelo, string serialnumber, uint cantkmsPM, uint passengerscapacity, int hangarId)
        {
            Commercial commercial = new Commercial(modelo, serialnumber, cantkmsPM, passengerscapacity, hangarId);
            _context.Add(commercial);
            return commercial;
        }

        public Jets CreateJets(string modelo, string serialnumber, uint cantkmsPM, int ownerId)
        {
            Jets jets = new Jets(modelo,serialnumber,cantkmsPM,ownerId);
            _context.Add(jets);
            return jets;
        }


        public T? GetPlanes<T>(int id) where T : Planes
        {
            return _context.Set<T>().Find(id);
        }

        public IEnumerable<Planes> GetAllPlanes()
        {
            return _context.Set<Planes>().ToList();
        }


        public void Update(Planes planes)
        {
            _context.Update(planes);
        }


        public void Delete(Planes planes)
        {
            _context.Remove(planes);
        }
    }
}
