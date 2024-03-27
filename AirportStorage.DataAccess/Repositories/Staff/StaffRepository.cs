using AirportStorage.DataAccess.Abstract.Staffs;
using AirportStorage.Domain.Entities.Hangar;
using AirportStorage.Domain.Entities.Staff;
using AirportStorage.Domain.Entities.Workshop;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportStorage.DataAccess.Repositories
{
    public partial class ApliccationRepository : IStaffRepository
    {
        public Mechanic CreateMechanic(uint pagoXrep, string nomb, uint id, string cargo, Workshop workshop)
        {
            Mechanic mechanic = new Mechanic(pagoXrep, nomb, id, cargo, workshop);
            _context.Add(mechanic);
            return mechanic;
        }
       public AssuranceStaff CreateAssuranceStaff(uint pagoXhoras, uint pagoXhorasextras, string nomb, uint id, string cargo, Hangar hangar)
       
        {
            AssuranceStaff assurancestaff = new AssuranceStaff( pagoXhoras,  pagoXhorasextras,  nomb,  id,  cargo, hangar);
            _context.Add(assurancestaff);
            return assurancestaff;
        }


        public T? GetStaff<T>(int id) where T : Staff
        {
            return _context.Set<T>().Find(id);
        }

        public IEnumerable<Staff> GetAllStaff()
        {
            return _context.Set<Staff>().ToList();
        }


        public void Update(Staff staff)
        {
            _context.Update(staff);
        }


        public void Delete(Staff staff)
        {
            _context.Remove(staff);
        }
    }
}
