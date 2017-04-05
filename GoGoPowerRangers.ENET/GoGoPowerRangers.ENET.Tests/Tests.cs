using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GoGoPowerRangers.ENET.Model;

namespace GoGoPowerRangers.ENET.Tests
{
    [TestClass]
    public class Tests
    {
        User _user;
        SiteEngineer _engineer;
        Accountant _accountant;
        Manager _manager;
        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void Setup()
        {
            _user = new User();
            _user.Id = 1;
            _user.Name = "Luke";
            _user.UserType = Model.Type.SiteEngineer;
            _engineer = new SiteEngineer(_user);
            _accountant = new Accountant(_user);
            _manager = new Manager(_user);

        }

        [TestMethod]
        public void CreateSiteEngineer_FromUser_ReturnsUserId()
        {
            Assert.AreEqual(_engineer.Id, _user.Id);
        }
        [TestMethod]
        public void CreateSiteEngineer_FromUser_ReturnsUserName()
        {
            Assert.AreEqual(_engineer.Name, _user.Name);
        }
        [TestMethod]
        public void CreateAccountant_FromUser_ReturnsUserId()
        {
            Assert.AreEqual(_accountant.Id, _user.Id);
        }
        [TestMethod]
        public void CreateAccountant_FromUser_ReturnsUserName()
        {
            Assert.AreEqual(_accountant.Id, _user.Id);
        }
        [TestMethod]
        public void CreateManager_FromUser_ReturnsUserId()
        {
            Assert.AreEqual(_manager.Id, _user.Id);
        }
        [TestMethod]
        public void CreateManager_FromUser_ReturnsUserName()
        {
            Assert.AreEqual(_manager.Id, _user.Id);
        }

        [TestMethod]
        public void SetSiteEngineerType_ToUser_ReturnsUserType()
        {
            _engineer.UserType = Model.Type.SiteEngineer;
            Assert.AreEqual(_engineer.UserType, _user.UserType);
        }
        [TestMethod]
        public void SetManagerType_ToUser_ReturnsUserType()
        {
            _user.UserType = Model.Type.Manager;
            _manager.UserType = Model.Type.Manager;
            Assert.AreEqual(_manager.UserType, _user.UserType);
        }
        [TestMethod]
        public void SetAccountantType_ToUser_ReturnsUserType()
        {
            _user.UserType = Model.Type.Accountant;
            _accountant.UserType = Model.Type.Accountant;
            Assert.AreEqual(_accountant.UserType, _user.UserType);
        }
        [TestMethod]
        public void SetDisctrictType_ToEngineer_ReturnsCorrectDistrict()
        {
            District _district = new District();
            _district.Name = "UTS";
            _manager.ChangeSiteEngineerDistrict(_engineer, _district);
            //_manager.ChangeManagerDistrict(_manager, _district);
            Assert.AreEqual(_engineer.District.Name, "UTS");
        }
        static void Main() { }
    }
}
