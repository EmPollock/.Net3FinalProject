using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogicLayer;
using DataAccessInterfaces;
using DataAccessFakes;
using DataObjects;

namespace LogicLayerTests
{
    [TestClass]
    public class FishManagerTests
    {
        IFishManager fishManager;
        [TestInitialize]
        public void TestSetup()
        {
            fishManager = new FishManager(new FishAccessorFake());
        }

        [TestMethod]
        public void TestRetrieveFishByCritterGoodCritter()
        {
            // arrange
            String critterID = "Big-Mouthed Bass";
            const string expectedLocationDescription = "The long water.";
            string actualLocationDescription;

            // act
            actualLocationDescription = fishManager.RetrieveFishByCritterID(critterID).LocationDescription;

            // assert
            Assert.AreEqual(expectedLocationDescription, actualLocationDescription);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRetrieveFishByCritterBadCritter()
        {
            // arrange
            const string critterID = "Big-Mouthed Bassx";

            // act
            fishManager.RetrieveFishByCritterID(critterID);

            // assert
            // nothing to do here
        }

        [TestMethod]
        public void TestRetrieveAllLocations()
        {
            // arrange
            const int expectedLocationCount = 2;
            int actualLocationCount;

            // act
            actualLocationCount = fishManager.RetrieveAllLocations().Count;

            // assert
            Assert.AreEqual(expectedLocationCount, actualLocationCount);
        }

        [TestMethod]
        public void TestRetrieveAllShadowSizes()
        {
            // arrange
            const int expectedShadowSizeCount = 2;
            int actualShadowSizeCount;

            // act
            actualShadowSizeCount = fishManager.RetrieveAllShadowSizes().Count;

            // assert
            Assert.AreEqual(expectedShadowSizeCount, actualShadowSizeCount);
        }
    }
}
