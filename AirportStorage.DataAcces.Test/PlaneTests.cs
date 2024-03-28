using AirportStorage.DataAcces.Tests.Utilities;
using AirportStorage.DataAccess.Abstract.hangars;
using AirportStorage.DataAccess.Abstract.Owners;
using AirportStorage.DataAccess.Abstract.Plane;
using AirportStorage.DataAccess.Repositories;
using AirportStorage.Domain.Entities.Hangar;
using AirportStorage.Domain.Entities.Owner;
using AirportStorage.Domain.Entities.Planes;
using AirportStorage.Domain.Entities.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace AirportStorage.DataAcces.Test
{
    [TestClass]
    public class PlaneTests
    {
        private IPlanesRepository _planesReposityory;

        public PlaneTests()
        {
            _planesReposityory = new ApliccationRepository(ConnectionStringProvider.GetConnectionString());
        }



        [TestMethod]
        [DataRow("Boing747", "SMls0707", 50000, 500, 2)]
        [DataRow("Boing747, GClm2547", 100000, 250, 1)]

        public void Can_Create_Commercial(string modelo, string serialnumber, uint cantkmsPM, uint passengerscapacity, int hangarId)
        {
            //Arrange 
            _planesReposityory.BeginTransaction();
            Hangar hangar = ((IHangarRepository)_planesReposityory).GetHangar(hangarId);
            Assert.IsNotNull(hangar);

            //Execute
            Commercial commercial = (Commercial)_planesReposityory.CreateCommercial(modelo, serialnumber, cantkmsPM, passengerscapacity, hangar);
            _planesReposityory.PartialCommit();
            var loadedCommercial = _planesReposityory.GetPlanes<Commercial>(commercial.Id);
            _planesReposityory.CommitTransaction();

            //Assert
            Assert.IsNotNull(loadedCommercial);
            Assert.AreEqual(loadedCommercial.Model, commercial.Model);
            Assert.AreEqual(loadedCommercial.SerialNumber, commercial.SerialNumber);
            Assert.AreEqual(loadedCommercial.CantKmsPlanMant, commercial.CantKmsPlanMant);
            Assert.AreEqual(loadedCommercial.PassengersCapacity, commercial.PassengersCapacity);
            Assert.AreEqual(loadedCommercial.HangarId, hangarId);

        }

        [TestMethod]
        [DataRow("SyberjectSJ30", "SA55245", 100000, 2)]
        [DataRow("GulsfstreamG550", "GP56987", 100000, 1)]
        public void Can_Create_Jets(string modelo, string serialnumber, uint cantkmsPM, int ownerId)
        {
            //Arrange 
            _planesReposityory.BeginTransaction();
            Owner owner = ((IOwnerRepository)_planesReposityory).Get(ownerId);
            Assert.IsNotNull(owner);

            //Execute
            Jets jets = (Jets)_planesReposityory.CreateJets(modelo, serialnumber, cantkmsPM, owner);
            _planesReposityory.PartialCommit();
            var loadedJet = _planesReposityory.GetPlanes<Jets>(jets.Id);
            _planesReposityory.CommitTransaction();

            //Assert
            Assert.IsNotNull(loadedJet);
            Assert.AreEqual(loadedJet.Model, jets.Model);
            Assert.AreEqual(loadedJet.SerialNumber, jets.SerialNumber);
            Assert.AreEqual(loadedJet.CantKmsPlanMant, jets.CantKmsPlanMant);
            Assert.AreEqual(loadedJet.LuxuryLevel, jets.LuxuryLevel);
            Assert.AreEqual(loadedJet.OwnerId, ownerId);



        }
        [TestMethod]
        [DataRow(1)]
        public void Can_Get_Planes(int count)
        {
            //Arrange
            _planesReposityory.BeginTransaction();

            //Execute
            var planes = _planesReposityory.GetAllPlanes();
            _planesReposityory.CommitTransaction();


            //Assert
            Assert.AreEqual(count, planes.Count());

        }

        [TestMethod]
        [DataRow(1, 9000, 15000, FlightStatus.Volando)]
        [DataRow(2, 10000, 50000, FlightStatus.Mantenimiento)]
        public void Can_Update_Planes(int pos, uint cantKMmant,uint cantKMTot, FlightStatus flightStatus )
        {
            //Arrange
            _planesReposityory.BeginTransaction();
            var planes = _planesReposityory.GetAllPlanes();
            Assert.IsNotNull(planes);
            var plane = planes.ElementAt(pos);
            Assert.IsNotNull(plane);


            //Execute
            plane.CantKmsDesdeMant = cantKMmant;
            plane.CantKmsTotales = cantKMTot;
            plane.Estado = flightStatus;
            _planesReposityory.Update(plane);
            _planesReposityory.PartialCommit();

            //Assert
            var updatedPlane = _planesReposityory.GetPlanes<Planes>(plane.Id);
            Assert.IsNotNull(updatedPlane);
            Assert.AreEqual(updatedPlane.CantKmsDesdeMant, plane.CantKmsDesdeMant);
            Assert.AreEqual(updatedPlane.CantKmsTotales, plane.CantKmsTotales);
            Assert.AreEqual(updatedPlane.Estado, plane.Estado); 
        }

        [TestMethod]
        [DataRow(1, 200)]
        [DataRow(2,350)]

        public void Can_Update_Commercial(int pos, uint passengerCapacity)
        {
            //Arrange
            _planesReposityory.BeginTransaction();
            var commercials = _planesReposityory.GetAllPlanes().OfType<Commercial>().ToList();
            Assert.IsNotNull(commercials);
            var commercial = commercials.ElementAt(pos);
            Assert.IsNotNull(commercial);

            //Execute
            commercial.PassengersCapacity = passengerCapacity;
            _planesReposityory.Update(commercial);
            _planesReposityory.PartialCommit();
            
            //Assert
            var updatedCommercial = _planesReposityory.GetPlanes<Commercial>(commercial.Id);
            Assert.IsNotNull(updatedCommercial);
            Assert.AreEqual(updatedCommercial.PassengersCapacity, commercial.PassengersCapacity);
        }
        
        [TestMethod]
        [DataRow(1, LuxuryLevel.Alto)]
        [DataRow(2, LuxuryLevel.Medio)]
        public void Can_Update_Jets(int pos, LuxuryLevel luxuryLevel)
        {
            //Arrange
            _planesReposityory.BeginTransaction();
            var jets = _planesReposityory.GetAllPlanes().OfType<Jets>().ToList();
            Assert.IsNotNull(jets);
            Jets jet = jets.ElementAt(pos);
            Assert.IsNotNull(jet);

            //Execute
            jet.LuxuryLevel = luxuryLevel;
            _planesReposityory.Update(jet);
            _planesReposityory.PartialCommit();

            //Assert
            Jets updatedJet = _planesReposityory.GetPlanes<Jets>(jet.Id);
            Assert.IsNotNull(updatedJet);
            Assert.AreEqual(updatedJet.LuxuryLevel, jet.LuxuryLevel);

        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(2)]
        public void Can_Delete_Planes(int pos)
        {
            //Arrange
            _planesReposityory.BeginTransaction();
            var planes = _planesReposityory.GetAllPlanes();
            Assert.IsNotNull(planes);
            var count = planes.Count();
            var plane = planes.ElementAt(pos);
            Assert.IsNotNull(plane);

            //Execute
            _planesReposityory.Delete(plane);
            _planesReposityory.PartialCommit();

            //Assert
            planes = _planesReposityory.GetAllPlanes();
            Assert.AreEqual(count - 1, planes.Count());
            var deletedPlane = _planesReposityory.GetPlanes<Planes>(plane.Id);
            _planesReposityory.CommitTransaction();
            Assert.IsNull(deletedPlane);



        }

    }
}
