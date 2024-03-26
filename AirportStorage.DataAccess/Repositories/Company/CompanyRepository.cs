using AirportStorage.Domain.Entities.company;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//namespace AirportStorage.DataAccess.Abstract.Company
namespace AirportStorage.DataAccess.Repositories
{
    public partial class ApliccationRepository : ICompanyRepository
    {
        Company Create(string InitialPais)
        {
            Company company = new Company(InitialPais);
            _context.Add(company);
            return company;
        }


        Company? Get(int id)
        {
            return _context.Set<Company>().Find(id);
        }


        void Update(Company company)
        {
            _context.Update(company);
        }


        void Delete(Company company)
        {
            _context.Remove(company);
        }
    }
}
