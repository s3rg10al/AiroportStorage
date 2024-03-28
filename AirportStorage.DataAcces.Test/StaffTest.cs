using AirportStorage.DataAcces.Tests.Utilities;
using AirportStorage.DataAccess.Abstract.hangars;
using AirportStorage.DataAccess.Abstract.Owners;
using AirportStorage.DataAccess.Abstract.Staffs;
using AirportStorage.DataAccess.Abstract.Workshops;
using AirportStorage.DataAccess.Repositories;
using AirportStorage.Domain.Entities.Hangar;
using AirportStorage.Domain.Entities.Owner;
using AirportStorage.Domain.Entities.Staff;
using AirportStorage.Domain.Entities.Types;
using AirportStorage.Domain.Entities.Workshop;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace AirportStorage.DataAcces.Test
{
    [TestClass]
    public class StaffTests
    {
        private IStaffRepository _StaffReposityory;

        public StaffTests()
        {
            _StaffReposityory = new ApliccationRepository(ConnectionStringProvider.GetConnectionString());
        }



        [TestMethod]
        [DataRow(1000, "German Garmendia", 87041298744, "Operario", 1)]
        

        public void Can_Create_Mechanic(uint pagoXrep, string nomb, uint ci, string cargo,int workshopId)
        {
            //Arrange 
            _StaffReposityory.BeginTransaction();
            Workshop workshop = ((IWorkshopRepository)_StaffReposityory).GetWorkshop(workshopId);
            Assert.IsNotNull(workshop);

            //Execute
            Mechanic mechanic = (Mechanic)_StaffReposityory.CreateMechanic(pagoXrep, nomb, ci, cargo, workshop);
            _StaffReposityory.PartialCommit();
            var loadedMechanic = _StaffReposityory.GetStaff<Mechanic>(mechanic.Id);
            _StaffReposityory.CommitTransaction();

            //Assert
            Assert.IsNotNull(loadedMechanic);
            Assert.AreEqual(loadedMechanic.PagoxRep, mechanic.PagoxRep);
            Assert.AreEqual(loadedMechanic.Name, mechanic.Name);
            Assert.AreEqual(loadedMechanic.CI, mechanic.CI);
            Assert.AreEqual(loadedMechanic.Cargo, mechanic.Cargo);
            Assert.AreEqual(loadedMechanic.WorkshopId, mechanic.WorkshopId);

        }

        [TestMethod]
        [DataRow(200, 400, "Federico Garcia",99082287455,"Pistero", 1)]
        public void Can_Create_AssuranceStaff(uint pagoXhoras, uint pagoXhorasextras, string nomb, uint ci, string cargo, int hangarId)
        {
            //Arrange 
            _StaffReposityory.BeginTransaction();
            Hangar hangar = ((IHangarRepository)_StaffReposityory).GetHangar(hangarId);
            Assert.IsNotNull(hangar);

            //Execute
            AssuranceStaff assuranceStaff = (AssuranceStaff)_StaffReposityory.CreateAssuranceStaff(pagoXhoras,pagoXhorasextras,nomb,ci,cargo,hangar);
            _StaffReposityory.PartialCommit();
            var loadedAssuranceStaff = _StaffReposityory.GetStaff<AssuranceStaff>(assuranceStaff.Id);
            _StaffReposityory.CommitTransaction();

            //Assert
            Assert.IsNotNull(loadedAssuranceStaff);
            Assert.AreEqual(loadedAssuranceStaff.PagoxHoras, assuranceStaff.PagoxHoras);
            Assert.AreEqual(loadedAssuranceStaff.PagoxHorasExtras, assuranceStaff.PagoxHorasExtras);
            Assert.AreEqual(loadedAssuranceStaff.Name, assuranceStaff.Name);
            Assert.AreEqual(loadedAssuranceStaff.CI, assuranceStaff.CI);
            Assert.AreEqual(loadedAssuranceStaff.Cargo, assuranceStaff.Cargo);
            Assert.AreEqual(loadedAssuranceStaff.HangarId, hangarId);



        }
        [TestMethod]
        [DataRow(1)]
        public void Can_Get_Staff(int count)
        {
            //Arrange
            _StaffReposityory.BeginTransaction();

            //Execute
            var staff = _StaffReposityory.GetAllStaff();
            _StaffReposityory.CommitTransaction();


            //Assert
            Assert.AreEqual(count, staff.Count());

        }

        [TestMethod]
        [DataRow(1,"Jhon Cena","Trabajador" )]
        public void Can_Update_Staff(int pos,string nomb, string cargo)
        {
            //Arrange
            _StaffReposityory.BeginTransaction();
            var staffs = _StaffReposityory.GetAllStaff();
            Assert.IsNotNull(staffs);
            var staff = staffs.ElementAt(pos);
            Assert.IsNotNull(staff);


            //Execute
            staff.Name = nomb;
            staff.Cargo = cargo;
            _StaffReposityory.Update(staff);
            _StaffReposityory.PartialCommit();

            //Assert
            var updatedStaff = _StaffReposityory.GetStaff<Staff>(staff.Id);
            Assert.IsNotNull(updatedStaff);
            Assert.AreEqual(updatedStaff.Name, staff.Name);
            Assert.AreEqual(updatedStaff.CI, staff.CI);
            Assert.AreEqual(updatedStaff.Cargo, staff.Cargo);
        }

        [TestMethod]
        [DataRow(1,2000,"Franz Kafka")]

        public void Can_Update_Mechanic(int pos,uint pagoXrep,string nomb )
        {
            //Arrange
            _StaffReposityory.BeginTransaction();
            var mechanics = _StaffReposityory.GetAllStaff().OfType<Mechanic>().ToList();
            Assert.IsNotNull(mechanics);
            var mechanic= mechanics.ElementAt(pos);
            Assert.IsNotNull(mechanic);

            //Execute
            mechanic.PagoxRep = pagoXrep;
            mechanic.Name = nomb;
            _StaffReposityory.Update(mechanic);
            _StaffReposityory.PartialCommit();

            //Assert
            var updatedMechanic = _StaffReposityory.GetStaff<Mechanic>(mechanic.Id);
            Assert.IsNotNull(updatedMechanic);
            Assert.AreEqual(updatedMechanic.PagoxRep, mechanic.PagoxRep);
            Assert.AreEqual(updatedMechanic.Name, mechanic.Name);
        }

        [TestMethod]
        [DataRow(1, "Limpeza")]
        public void Can_Update_AssuranceStaff(int pos, string cargo)
        {
            //Arrange
            _StaffReposityory.BeginTransaction();
            var assuranceStaffs = _StaffReposityory.GetAllStaff().OfType<AssuranceStaff>().ToList();
            Assert.IsNotNull(assuranceStaffs);
            AssuranceStaff assuranceStaff = assuranceStaffs.ElementAt(pos);
            Assert.IsNotNull(assuranceStaff);

            //Execute
            assuranceStaff.Cargo= cargo;
            _StaffReposityory.Update(assuranceStaff);
            _StaffReposityory.PartialCommit();

            //Assert
            AssuranceStaff updatedAssuranceStaff = _StaffReposityory.GetStaff<AssuranceStaff>(assuranceStaff.Id);
            Assert.IsNotNull(updatedAssuranceStaff);
            Assert.AreEqual(updatedAssuranceStaff.Cargo, assuranceStaff.Cargo);

        }

        [TestMethod]
        [DataRow(1)]
        public void Can_Delete_Staff(int pos)
        {
            //Arrange
            _StaffReposityory.BeginTransaction();
            var staffs = _StaffReposityory.GetAllStaff();
            Assert.IsNotNull(staffs);
            var count = staffs.Count();
            var staff = staffs.ElementAt(pos);
            Assert.IsNotNull(staffs);

            //Execute
            _StaffReposityory.Delete(staff);
            _StaffReposityory.PartialCommit();

            //Assert
            staffs = _StaffReposityory.GetAllStaff();
            Assert.AreEqual(count - 1, staffs.Count());
            var deletedStaff = _StaffReposityory.GetStaff<Staff>(staff.Id);
            _StaffReposityory.CommitTransaction();
            Assert.IsNull(deletedStaff);



        }

    }
}