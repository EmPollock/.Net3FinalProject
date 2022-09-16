using DataObjects;
using LogicLayer;
using DataAccessInterfaces;
using DataAccessFakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace LogicLayerTests
{
    [TestClass]
    public class CritterManagerTests
    {
        ICritterManager critterManager;
        [TestInitialize]
        public void TestSetup()
        {
            critterManager = new CritterManager(new CritterAccessorFake(), new UserAccessorFake());
        }

        [TestMethod]
        public void TestRetrieveActive()
        {
            // arrange
            const int expectedCount = 3;
            int actualCount;

            // act
            actualCount = critterManager.RetrieveActive().Count;

            // assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void TestRetrieveAll()
        {
            // arrange
            const int expectedCount = 4;
            int actualCount;

            // act
            actualCount = critterManager.RetrieveAll().Count;

            // assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void TestRetrieveCaughtByUserWorksWithGoodLoginName()
        {
            // arrange
            const int villagerID = 1;
            const int expectedCount = 2;
            int actualCount;

            // act
            actualCount = critterManager.RetrieveCaughtByUser(villagerID).Count;

            // assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestRetrieveCaughtByUserFailsWithBagLoginName()
        {
            // arrange
            const int villagerID = -1;

            // act
            critterManager.RetrieveCaughtByUser(villagerID);

            // assert
            // nothing to do here, exception checking
        }

        [TestMethod]
        public void TestSetCritterMonthsAndHours()
        {
            // arrange
            List<CritterVM> critterList = critterManager.RetrieveAll();
            const int expectedMonthCount = 5;
            const int expectedHourCount = 8;
            int actualMonthCount;
            int actualHourCount;

            // act
            critterManager.setCritterMonthsAndHours(critterList);
            actualMonthCount = critterList[0].CatchableMonths.Count;
            actualHourCount = critterList[0].CatchableHours.Count;

            // assert
            Assert.IsTrue(expectedMonthCount == actualMonthCount && expectedHourCount == actualHourCount);
        }

        [TestMethod]
        public void TestSetUserCaughtBy()
        {
            // arrange
            List<CritterVM> critterList = critterManager.RetrieveAll();
            const int expectedUserCaughtDateCount = 2;
            int actualUserCaughtDateCount;

            // act
            critterManager.setUserCaughtBy(critterList);
            actualUserCaughtDateCount = critterList[0].UserCaughtDate.Count;

            // assert
            Assert.AreEqual(expectedUserCaughtDateCount, actualUserCaughtDateCount);
        }

        [TestMethod]
        public void TestSetCritterCaughtByCurrentUserTrue()
        {
            // arrange
            List<CritterVM> critterList = critterManager.RetrieveAll();
            int villagerID = 1;
            bool critterCaught;

            // act
            critterManager.setCritterCaughtByCurrentUser(critterList, villagerID);
            critterCaught = critterList[0].CaughtByCurrentUser;

            // assert
            Assert.IsTrue(critterCaught);
        }

        [TestMethod]
        public void TestSetCritterCaughtByCurrentUserFalse()
        {
            // arrange
            List<CritterVM> critterList = critterManager.RetrieveAll();
            int villagerID = 1;
            bool critterCaught;

            // act
            critterManager.setCritterCaughtByCurrentUser(critterList, villagerID);
            critterCaught = critterList[1].CaughtByCurrentUser;

            // assert
            Assert.IsFalse(critterCaught);
        }

        [TestMethod]
        public void TestAddCaughtByWorks()
        {
            // arrange
            const int villagerID = 1;
            const String critterID = "Guppy";
            DateTime caughtDate = DateTime.Today;
            const bool expected = true;
            bool actual;

            // act
            actual = critterManager.AddCaughtBy(villagerID, critterID, caughtDate);            

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestAddCaughtByReturnsFalseWithBadID()
        {
            // arrange
            const int villagerID = 1;
            const String critterID = "Guppyx";
            DateTime caughtDate = DateTime.Today;
            const bool expected = false;
            bool actual;

            // act
            actual = critterManager.AddCaughtBy(villagerID, critterID, caughtDate);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestAddCaughtByFailsWithBadVillagerID()
        {
            // arrange
            const int villagerID = -1;
            const String critterID = "Guppy";
            DateTime caughtDate = DateTime.Today;          

            // act
            critterManager.AddCaughtBy(villagerID, critterID, caughtDate);

            // assert
                // Nothing to do here, error checking
        }

        [TestMethod]
        public void TestPutCritterInMuseumReturnsTrue()
        {
            // arrange
            const string critterID = "Guppy";
            const string loginName = "tessdata";
            const bool expectedResult = true;
            bool actualResult;

            // act
            actualResult = critterManager.putCritterInMuseum(critterID, loginName);

            // assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestPutCritterInMuseumReturnsFalseWithCritterInMuseum()
        {
            // arrange
            const string critterID = "Kelp";
            const string loginName = "tessdata";
            const bool expectedResult = false;
            bool actualResult;

            // act
            actualResult = critterManager.putCritterInMuseum(critterID, loginName);

            // assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestPutCritterInMuseumFailsWithBadLoginName()
        {
            // arrange
            const string critterID = "Guppy";
            const string loginName = "tessdatax";

            // act
            critterManager.putCritterInMuseum(critterID, loginName);

            // assert
                // Nothing to do here, error checking
        }
    }
}
