using AirportStorage.DataAcces.Tests.Utilities;
using AirportStorage.DataAccess.Abstract.Staffs;
using AirportStorage.DataAccess.Repositories;
using AirportStorage.Domain.Entities.Hangar;
using AirportStorage.Domain.Entities.Staff;
using AirportStorage.Domain.Entities.Workshop;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace AirportStorage.DataAcces.Test
{
    [TestClass]
    public class StaffTest
    {
        private IStaffRepository _StaffRepository;
        public StaffTest()
        {
            _StaffRepository = new ApliccationRepository(ConnectionStringProvider.GetConnectionString());
        }
        [DataRow(1000, "Pedro Garcia", 78020568755, "Operario", workshop)]
        [TestMethod]
        public void Can_Create_Mechanic(uint pagoXrep, string nomb, uint id, string cargo, Workshop workshop)
        {
            //Arrage
            _StaffRepository.BeginTransaction();

            //Execute
            Mechanic newMechanic = _StaffRepository.Create(pagoXrep, nomb, id, cargo, workshop);
            _StaffRepository.PartialCommit();//Generando id del nuevo elemento.
            Mechanic? loadedMechanic = _StaffRepository.Get(newMechanic.Id);
            _StaffRepository.CommitTransaction();

            // Assert
            Assert.IsNotNull(loadedMechanic);
            Assert.AreEqual(loadedMechanic.Name, nomb);
            Assert.AreEqual(loadedMechanic.PagoxRep, pagoXrep);
            Assert.AreEqual(loadedMechanic.Id, id);
            Assert.AreEqual(loadedMechanic.Cargo, cargo);
            Assert.AreEqual(loadedMechanic.Workshop, workshop);
        }

        [DataRow(1000, 500, "Julio Verne", 75040390766, "Pistero", hangar)]
        [TestMethod]
        public void Can_Create_AssuranceStaff(uint pagoXhoras, uint pagoXhorasextras, string nomb, uint id, string cargo, Hangar hangar)
        {
            //Arrage
            _StaffRepository.BeginTransaction();

            //Execute
            AssuranceStaff newAssuranceStaff = _StaffRepository.Create(pagoXhoras, pagoXhorasextras, nomb, id, cargo, hangar);
            _StaffRepository.PartialCommit();//Generando id del nuevo elemento.
            AssuranceStaff? loadedAssuranceStaff = _StaffRepository.Get(newAssuranceStaff.Id);
            _StaffRepository.CommitTransaction();

            // Assert
            Assert.IsNotNull(loadedAssuranceStaff);
            Assert.AreEqual(loadedAssuranceStaff.Name, nomb);
            Assert.AreEqual(loadedAssuranceStaff.PagoxHoras, pagoXhoras);
            Assert.AreEqual(loadedAssuranceStaff.PagoxHorasExtras, pagoXhorasextras);
            Assert.AreEqual(loadedAssuranceStaff.Id, id);
            Assert.AreEqual(loadedAssuranceStaff.Cargo, cargo);
            Assert.AreEqual(loadedAssuranceStaff.Hangar, hangar);
        }
        [DataRow(1)]
        [DataRow(2)]
        [TestMethod]
        public void Can_Get_Staff(int id)
        {
            //Arrage
            _StaffRepository.BeginTransaction();

            //Execute
            var loadedStaff = _StaffRepository.Get(id);
            _StaffRepository.CommitTransaction();

            //Assert
            Assert.IsNotNull(loadedStaff);
        }
        [DataRow(1000, "Pedro Garcia", 78020568755, "Operario", workshop)]
        [TestMethod]
        public void Can_Update_Mechanic(int id, uint pagoXrep, string nomb, uint idd, string cargo, Workshop workshop)
        {
            //Arrange
            _StaffRepository.BeginTransaction();

            //Execute
            var loadMechanic = _StaffRepository.Get(id);
            Assert.IsNotNull(loadMechanic);
            var newMechanic = new Mechanic(pagoXrep, nomb, idd, cargo, workshop) { Id = loadMechanic.Id };
            _StaffRepository.Update(newMechanic);
            var modifyedMechanic = _StaffRepository.Get(id);
            _StaffRepository.CommitTransaction();

            //Assert
            Assert.AreEqual(modifyedMechanic.PagoxRep, pagoXrep);
            Assert.AreEqual(modifyedMechanic.Name, nomb);
            Assert.AreEqual(modifyedMechanic.Id, idd);
            Assert.AreEqual(modifyedMechanic.Cargo, cargo);
            Assert.AreEqual(modifyedMechanic.Workshop, workshop);
        }
        [DataRow(1000, 500, "Julio Verne", 75040390766, "Pistero", hangar)]
        [TestMethod]
        public void Can_Create_AssuranceStaff(int id, uint pagoXhoras, uint pagoXhorasextras, string nomb, uint idd, string cargo, Hangar hangar)
        {
            //Arrange
            _StaffRepository.BeginTransaction();

            //Execute
            var loadAssuranceStaff = _StaffRepository.Get(id);
            Assert.IsNotNull(loadAssuranceStaff);
            var newAssuranceStaff = new AssuranceStaff(pagoXhoras, pagoXhorasextras, nomb, idd, cargo, hangar) { Id = loadAssuranceStaff.Id };
            _StaffRepository.Update(newAssuranceStaff);
            var modifyedAssuranceStaff = _StaffRepository.Get(id);
            _StaffRepository.CommitTransaction();

            //Assert
            Assert.AreEqual(modifyedAssuranceStaff.PagoxHoras, pagoXhoras);
            Assert.AreEqual(modifyedAssuranceStaff.PagoxHorasExtras, pagoXhorasextras);
            Assert.AreEqual(modifyedAssuranceStaff.Name, nomb);
            Assert.AreEqual(modifyedAssuranceStaff.Id, idd);
            Assert.AreEqual(modifyedAssuranceStaff.Cargo, cargo);
            Assert.AreEqual(modifyedAssuranceStaff.Workshop, hangar);
        }
        [DataRow("Jilio Iglesias", 68120456789, "Jefe de Taller")]
        [TestMethod]
        public void Can_Create_Staff(int id, string nomb, uint idd, string cargo)
        {
            //Arrange
            _StaffRepository.BeginTransaction();

            //Execute
            var loadStaff = _StaffRepository.Get(id);
            Assert.IsNotNull(loadStaff);
            var modifyedStaff = _StaffRepository.Get(id);
            _StaffRepository.CommitTransaction();

            //Assert
            Assert.AreEqual(modifyedStaff.Name, nomb);
            Assert.AreEqual(modifyedStaff.Id, idd);
            Assert.AreEqual(modifyedStaff.Cargo, cargo);
        }
        [DataRow(1)]
        [DataRow(2)]
        [TestMethod]
        public void Can_Delete_Staff(int id)
        {
            //Arrange
            _StaffRepository.BeginTransaction();

            //Execute
            var loadedStaff = _StaffRepository.Get(id);
            Assert.IsNotNull(loadedStaff);
            _StaffRepository.Delete(loadedStaff);
            _StaffRepository.PartialCommit();
            loadedStaff = _StaffRepository.Get(id);
            _StaffRepository.CommitTransaction();

            //Assert
            Assert.IsNull(loadedStaff);
        }


    }
}
