using DataAccessFakes;
using DataObjects;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LogicLayerTests
{
    [TestClass]
    public class SeaCreatureManagerTests
    {
        ISeaCreatureManager seaCreatureManager;
        [TestInitialize]
        public void TestSetup()
        {
            seaCreatureManager = new SeaCreatureManager(new SeaCreatureAccessorFake());
        }

        [TestMethod]
        public void TestRetrieveSeaCreatureByCritterIDGoodCritter()
        {
            // arrange
            const string critterID = "Kelp";
            const string expectedSpotId = "Fast";
            string actualSpotId;

            // act
            actualSpotId = seaCreatureManager.RetrieveSeaCreatureByCritterID(critterID).movementId;

            // assert
            Assert.AreEqual(expectedSpotId, actualSpotId);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRetrieveBugByCritterBadCritter()
        {
            // arrange
            const string critterID = "Kelpx";

            // act
            seaCreatureManager.RetrieveSeaCreatureByCritterID(critterID);

            // assert
            // nothing to do here
        }

        [TestMethod]
        public void TestRetrieveAllBugFindingSpots()
        {
            // arrange
            const int expectedLocationCount = 1;
            int actualLocationCount;

            // act
            actualLocationCount = seaCreatureManager.RetrieveAllMovements().Count;

            // assert
            Assert.AreEqual(expectedLocationCount, actualLocationCount);
        }
    }
}
