using AirportStorage.DataAcces.Tests.Utilities;
using AirportStorage.DataAccess.Abstract.Companys;
using AirportStorage.DataAccess.Abstract.Stores;
using AirportStorage.DataAccess.Abstract.Workshops;
using AirportStorage.DataAccess.Repositories;
using AirportStorage.Domain.Entities.company;
using AirportStorage.Domain.Entities.Staff;
using AirportStorage.Domain.Entities.Store;
using AirportStorage.Domain.Entities.Workshop;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


[TestClass]
public class WorkshopTest
{
    private IWorkshopRepository _WorkshopRepository;
    public WorkshopTest()
    {
        _WorkshopRepository = new ApliccationRepository(ConnectionStringProvider.GetConnectionString());
        }
    [DataRow(10, 1, 1)]
    [TestMethod]
    public void Can_Create_Workshop(uint ability, int storeId, int companyId)
    {
        //Arrage
        _WorkshopRepository.BeginTransaction();
        Store store = ((IStoreRepository)_WorkshopRepository).GetStore(storeId);
        Assert.IsNotNull(store);
        Company company = ((ICompanyRepository)_WorkshopRepository).GetCompany(companyId);
        Assert.IsNotNull(company);

        //Execute
        Workshop newWorkshop = _WorkshopRepository.CreateWorkshop(ability, store, company);
        _WorkshopRepository.PartialCommit();//Generando id del nuevo elemento.
        Workshop? loadedWorkshop = _WorkshopRepository.GetWorkshop(newWorkshop.Id);
        _WorkshopRepository.CommitTransaction();

        // Assert
        Assert.IsNotNull(loadedWorkshop);
        Assert.AreEqual(loadedWorkshop.Ability, ability);
        Assert.AreEqual(loadedWorkshop.Store, store);
        Assert.AreEqual(loadedWorkshop.company, company);
    }
    [DataRow(1)]
    [TestMethod]
    public void Can_Get_Workshop(int id)
    {
        //Arrage
        _WorkshopRepository.BeginTransaction();

        //Execute
        var loadedWorkshop = _WorkshopRepository.GetWorkshop(id);
        _WorkshopRepository.CommitTransaction();

        //Assert
        Assert.IsNotNull(loadedWorkshop);
    }
    [DataRow(10, 15, true)]
    [TestMethod]
    public void Can_Update_Workshop(int id, uint ability, bool HayCap)
    {
        //Arrange
        _WorkshopRepository.BeginTransaction();
        var workshops = _WorkshopRepository.GetAllWorkshop();
        Assert.IsNotNull(workshops);
        Workshop workshop = workshops.ElementAt(id);
        Assert.IsNotNull(workshop);

        //Execute
        workshop.Ability = ability;
        workshop.IsAbility = HayCap;
        _WorkshopRepository.Update(workshop);
        _WorkshopRepository.PartialCommit();

        //Assert
        Workshop updatedWorkshop = _WorkshopRepository.GetWorkshop(workshop.Id);
        Assert.AreEqual(updatedWorkshop.Ability, workshop.Ability);
        Assert.AreEqual(updatedWorkshop.IsAbility, workshop.IsAbility);

    }
    [DataRow(1)]
    [TestMethod]
    public void Can_Delete_Workshop(int id)
    {
        //Arrange
        _WorkshopRepository.BeginTransaction();

        //Execute
        var loadedWorkshop = _WorkshopRepository.GetWorkshop(id);
        Assert.IsNotNull(loadedWorkshop);
        _WorkshopRepository.Delete(loadedWorkshop);
        _WorkshopRepository.PartialCommit();
        loadedWorkshop = _WorkshopRepository.GetWorkshop(id);
        _WorkshopRepository.CommitTransaction();

        //Assert
        Assert.IsNull(loadedWorkshop);
    }
}
