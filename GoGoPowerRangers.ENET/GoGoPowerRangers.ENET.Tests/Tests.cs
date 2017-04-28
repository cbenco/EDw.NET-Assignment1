using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GoGoPowerRangers.ENET.Model;
using GoGoPowerRangers.ENET.Data;

namespace GoGoPowerRangers.ENET.Tests
{
    [TestClass]
    public class Tests
    {
        public TestContext TestContext { get; set; }
        SiteEngineer engineer;
        Manager manager;
        Intervention intervention;
        District district;

        [TestInitialize]
        public void Setup()
        {
            district = new District("DISTRICTNAME");
            engineer = new SiteEngineer("asdf", "asdf", "asdf", district);
            manager = new Manager("asdf", "asdf", "asdf", district);
            intervention = new Intervention(new InterventionType("TYPE", 1.0, 1.0), new Client("", "", district), engineer, 100);
        }

        //Tests for public methods
            //Tests for Intervention.Approvable()
        [TestMethod]
        public void InterventionApproval_EngineerBothEqual_ReturnsTrue()
        {
            engineer.MaxManHours = 1.0;
            engineer.MaxMaterialCost = 1.0;
            Assert.IsTrue(intervention.Approvable(engineer));
        }
        [TestMethod]
        public void InterventionApproval_EngineerManHoursBelow_ReturnsFalse()
        {
            engineer.MaxManHours = 0.5;
            engineer.MaxMaterialCost = 1.0;
            Assert.IsFalse(intervention.Approvable(engineer));
        }
        [TestMethod]
        public void InterventionApproval_EngineerMatCostBelow_ReturnsFalse()
        {
            engineer.MaxManHours = 1.0;
            engineer.MaxMaterialCost = 0.5;
            Assert.IsFalse(intervention.Approvable(engineer));
        }
        [TestMethod]
        public void InterventionApproval_EngineerManHoursAbove_ReturnsTrue()
        {
            engineer.MaxManHours = 2.0;
            engineer.MaxMaterialCost = 1.0;
            Assert.IsTrue(intervention.Approvable(engineer));
        }
        [TestMethod]
        public void InterventionApproval_EngineerMatCostAbove_ReturnsTrue()
        {
            engineer.MaxManHours = 1.0;
            engineer.MaxMaterialCost = 2.0;
            Assert.IsTrue(intervention.Approvable(engineer));
        }
        [TestMethod]
        public void InterventionApproval_EngineerIsRequester_ReturnsTrue()
        {
            intervention.Requester = engineer;
            Assert.IsTrue(intervention.Approvable(engineer));
        }
        [TestMethod]
        public void InterventionApproval_EngineerIsNotRequester_ReturnsTrue()
        {
            intervention.Requester = new SiteEngineer("", "", "", district);
            Assert.IsFalse(intervention.Approvable(engineer));
        }
        [TestMethod]
        public void InterventionApproval_ManagerFromDistrict_ReturnsTrue()
        {
            Assert.IsTrue(intervention.Approvable(manager));
        }
        [TestMethod]
        public void InterventionApproval_ManagerNotFromDistrict_ReturnsFalse()
        {
            manager.District = new District();
            Assert.IsFalse(intervention.Approvable(manager));
        }

            //Tests for EngineerOrManager.ChangeInterventionState()
        [TestMethod]
        public void ChangeInterventionState_PendingToApproved_ChangedToApproved()
        {
            intervention.Status = Status.Pending;
            engineer.ChangeInterventionState(intervention, Status.Approved);
            Assert.AreEqual(intervention.Status, Status.Approved);
        }
        [TestMethod]
        public void ChangeInterventionState_PendingToCancelled_ChangedToCancelled()
        {
            intervention.Status = Status.Pending;
            engineer.ChangeInterventionState(intervention, Status.Cancelled);
            Assert.AreEqual(intervention.Status, Status.Cancelled);
        }
        [TestMethod]
        public void ChangeInterventionState_PendingToCompleted_NoChange()
        {
            intervention.Status = Status.Pending;
            engineer.ChangeInterventionState(intervention, Status.Complete);
            Assert.AreEqual(intervention.Status, Status.Pending);
        }
        [TestMethod]
        public void ChangeInterventionState_ApprovedToPending_NoChange()
        {
            intervention.Status = Status.Approved;
            engineer.ChangeInterventionState(intervention, Status.Pending);
            Assert.AreEqual(intervention.Status, Status.Approved);
        }
        [TestMethod]
        public void ChangeInterventionState_ApprovedToCompleted_ChangedToCompleted()
        {
            intervention.Status = Status.Approved;
            engineer.ChangeInterventionState(intervention, Status.Complete);
            Assert.AreEqual(intervention.Status, Status.Complete);
        }
        [TestMethod]
        public void ChangeInterventionState_ApprovedToCancelled_ChangedToCancelled()
        {
            intervention.Status = Status.Approved;
            engineer.ChangeInterventionState(intervention, Status.Cancelled);
            Assert.AreEqual(intervention.Status, Status.Cancelled);
        }
        [TestMethod]
        public void ChangeInterventionState_CancelledToPending_NoChange()
        {
            intervention.Status = Status.Cancelled;
            engineer.ChangeInterventionState(intervention, Status.Pending);
            Assert.AreEqual(intervention.Status, Status.Cancelled);
        }
        [TestMethod]
        public void ChangeInterventionState_CancelledToApproved_NoChange()
        {
            intervention.Status = Status.Cancelled;
            engineer.ChangeInterventionState(intervention, Status.Approved);
            Assert.AreEqual(intervention.Status, Status.Cancelled);
        }
        [TestMethod]
        public void ChangeInterventionState_CancelledToCompleted_NoChange()
        {
            intervention.Status = Status.Cancelled;
            engineer.ChangeInterventionState(intervention, Status.Complete);
            Assert.AreEqual(intervention.Status, Status.Cancelled);
        }
        [TestMethod]
        public void ChangeInterventionState_CompletedToPending_NoChange()
        {
            intervention.Status = Status.Complete;
            engineer.ChangeInterventionState(intervention, Status.Pending);
            Assert.AreEqual(intervention.Status, Status.Complete);
        }
        [TestMethod]
        public void ChangeInterventionState_CompletedToApproved_NoChange()
        {
            intervention.Status = Status.Complete;
            engineer.ChangeInterventionState(intervention, Status.Approved);
            Assert.AreEqual(intervention.Status, Status.Complete);
        }
        [TestMethod]
        public void ChangeInterventionState_CompletedToCancelled_NoChange()
        {
            intervention.Status = Status.Complete;
            engineer.ChangeInterventionState(intervention, Status.Cancelled);
            Assert.AreEqual(intervention.Status, Status.Complete);
        }

        [TestMethod]
        public void EngineerQueries_ListClientsInDistrict_HasNoOtherDistricts()
        {
        }

        [TestMethod]
        public void EngineerQueries_GetInterventions_HasNoOtherEngineers()
        {

        }
    }
}
