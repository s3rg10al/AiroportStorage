using AirportStorage.DataAcces.Tests.Utilities;
using AirportStorage.DataAccess.Abstract.Companys;
using AirportStorage.DataAccess.Repositories;
using AirportStorage.Domain.Entities.company;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportStorage.DataAcces.Tests
{
    [TestClass]
    public class CompanyTests
    {
        private ICompanyRepository _companyRepository;
        /// <summary>
        /// Para ver si logro el merge
        /// </summary>
        
        public CompanyTests()
        {
            _companyRepository = new ApliccationRepository(ConnectionStringProvider.GetConnectionString());
        }
        
        [DataRow("cuba")]
        [DataRow("USA")]
        [TestMethod]
        [Priority(1)]
        public void Can_Create_Company(string InitialCountry)
        {
            //Arrange
            _companyRepository.BeginTransaction();

            //Execute
            Company newCompany = _companyRepository.Create(InitialCountry);
            _companyRepository.PartialCommit();  //generando id 
            Company? loadedCompany = _companyRepository.GetCompany(newCompany.Id);
            _companyRepository.CommitTransaction();

            //Assert
            Assert.IsNotNull(loadedCompany);
            Assert.AreEqual(loadedCompany.Pais, InitialCountry);
            

        }


        [DataRow(1)]
        [DataRow(2)]
        [TestMethod]
        [Priority(2)]
        public void Can_Get_Company(int id)
        {
            //Arrange 
            _companyRepository.BeginTransaction();

            // Execute
            var loadedCompany = _companyRepository.GetCompany(id);
            _companyRepository.CommitTransaction();

            //Assert
            Assert.IsNotNull(loadedCompany);
        }

        [DataRow(1,"panama")]
        [DataRow(2, "inglaterra")]
        [TestMethod]
        [Priority(2)]
        public void Can_Update_Company(int id,string InitialCountry)
        {
            //Arrange
            _companyRepository.BeginTransaction();

            //Execute
            var loadedCompany = _companyRepository.GetCompany(id);
            Assert.IsNotNull(loadedCompany);
            var newCompany = new Company(InitialCountry) { Id = loadedCompany.Id };
            _companyRepository.Update(newCompany);
            var modifyedCompany = _companyRepository.GetCompany(id);
            _companyRepository.CommitTransaction();

            //Assert
            Assert.AreEqual(modifyedCompany.Pais, InitialCountry);
          


        }

        [DataRow(1)]
        [TestMethod]
        [Priority(6)]
        public void Can_Delete_Company(int id)
        {
            //Arrange
            _companyRepository.BeginTransaction();

            //Execute
            var loadedCompany = _companyRepository.GetCompany(id);
            Assert.IsNotNull(loadedCompany);
            _companyRepository.Delete(loadedCompany);
            _companyRepository.PartialCommit();
            loadedCompany = _companyRepository.GetCompany(id);
            _companyRepository.CommitTransaction();

            //Assert
            Assert.IsNull(loadedCompany);



        }
    }
}
