using DataAccessFakes;
using DataObjects;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace LogicLayerTests
{
    [TestClass]
    public class BugManagerTests
    {
        IBugManager bugManager;
        [TestInitialize]
        public void TestSetup()
        {
            bugManager = new BugManager(new BugAccessorFake());
        }
        
        [TestMethod]
        public void TestRetrieveAllBugFindingSpots()
        {
            // arrange
            const int expectedLocationCount = 1;
            int actualLocationCount;

            // act
            actualLocationCount = bugManager.RetrieveAllBugFindingSpots().Count;

            // assert
            Assert.AreEqual(expectedLocationCount, actualLocationCount);
        }

        [TestMethod]
        public void TestRetrieveBugByCritterID()
        {
            // arrange
            const string CritterID = "French Fly";
            const string expectedSpotId = "Blue Flowers";
            string actualSpotId;

            // act
            actualSpotId = bugManager.RetrieveBugByCritterID(CritterID).SpotId;

            // assert
            Assert.AreEqual(expectedSpotId, actualSpotId);
        }
    }
}
