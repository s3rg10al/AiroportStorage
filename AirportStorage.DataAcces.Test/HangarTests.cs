using AirportStorage.DataAcces.Tests.Utilities;
using AirportStorage.DataAccess.Abstract.Companys;
using AirportStorage.DataAccess.Abstract.hangars;
using AirportStorage.DataAccess.Repositories;
using AirportStorage.Domain.Entities.company;
using AirportStorage.Domain.Entities.Hangar;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportStorage.DataAcces.Tests
{
 
    [TestClass]
    public class HangarTests
    {
        private IHangarRepository _hangarRepository;


        public HangarTests()
        {
            _hangarRepository = new ApliccationRepository(ConnectionStringProvider.GetConnectionString());
        }

        [DataRow(200,2)]
        [DataRow(300,2)]
        [TestMethod]
        public void Can_Create_Hangar(int InitialCantMax, int CompanyId )
        {
            //Arrange
            _hangarRepository.BeginTransaction();
            Company company = ((ICompanyRepository)_hangarRepository).GetCompany(CompanyId);
            Assert.IsNotNull(company);

            //Execute
            Hangar newHangar = _hangarRepository.Create(InitialCantMax, company);
            _hangarRepository.PartialCommit();  //generando id 
            Hangar? loadedHangar = _hangarRepository.GetHangar(newHangar.Id);
            _hangarRepository.CommitTransaction();

            //Assert
            Assert.IsNotNull(loadedHangar);
            Assert.AreEqual(loadedHangar.capMax, InitialCantMax);
            Assert.AreEqual(loadedHangar.CompanyId, CompanyId);


        }


        [DataRow(1)]
        [DataRow(2)]
        [TestMethod]
        public void Can_Get_Hangar(int id)
        {
            //Arrange 
            _hangarRepository.BeginTransaction();

            // Execute
            var loadedHangar = _hangarRepository.GetHangar(id);
            _hangarRepository.CommitTransaction();

            //Assert
            Assert.IsNotNull(loadedHangar);
        }

        [DataRow(1, 200)]
        [DataRow(2, 300)]
        [TestMethod]
        public void Can_Update_Hangar(int id, int InitialCantMax)
        {
            //Arrange
            _hangarRepository.BeginTransaction();
            var hangars = _hangarRepository.GetAllHangars();
            Assert.IsNotNull(hangars);
            var hangar = hangars.ElementAt(id);
            Assert.IsNotNull(hangar);

            //Execute
            hangar.capMax = InitialCantMax;
            _hangarRepository.Update(hangar);
            _hangarRepository.PartialCommit();

            //Assert
            var updatedPlane = _hangarRepository.GetHangar(hangar.Id);
            Assert.IsNotNull(updatedPlane);
            Assert.AreEqual(updatedPlane.capMax, hangar.capMax);
          

        }

        [DataRow(1)]
        [TestMethod]
        public void Can_Delete_Hangar(int id)
        {
            //Arrange
            _hangarRepository.BeginTransaction();

            //Execute
            var loadedHangar = _hangarRepository.GetHangar(id);
            Assert.IsNotNull(loadedHangar);
            _hangarRepository.Delete(loadedHangar);
            _hangarRepository.PartialCommit();
            loadedHangar = _hangarRepository.GetHangar(id);
            _hangarRepository.CommitTransaction();

            //Assert
            Assert.IsNull(loadedHangar);

           

        }
    }
}
