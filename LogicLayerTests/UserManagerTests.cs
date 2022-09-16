using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogicLayer;
using DataAccessFakes;
using DataObjects;
using DataAccessInterfaces;
using System.Collections.Generic;

namespace LogicLayerTests
{
    [TestClass]
    public class UserManagerTests
    {
        IUserManager userManager;
        [TestInitialize]
        public void TestSetup()
        {
            userManager = new UserManager(new UserAccessorFake());
        }

        [TestMethod]
        public void TestHashSha256ReturnsCorrectHashValue()
        {
            //Arrange
            const string source = "newuser";
            const string expectedResult = "9C9064C59F1FFA2E174EE754D2979BE80DD30DB552EC03E7E327E9B1A4BD594E";
            string actualResult = "";

            //Act
            actualResult = userManager.HashSha256(source);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestAuthenticateUserPassesWithCorrectUsernamePasswordHash()
        {
            // Arrange
            const string loginName = "tessdata";
            const string passwordHash = "9C9064C59F1FFA2E174EE754D2979BE80DD30DB552EC03E7E327E9B1A4BD594E";
            const bool expectedResult = true;
            bool actualResult;

            // Act
            actualResult = userManager.AuthenticateUser(loginName, passwordHash);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestAuthenticateUserFailsWithIncorrectUsername()
        {
            // Arrange
            const string loginName = "xtessdata";
            const string passwordHash = "9C9064C59F1FFA2E174EE754D2979BE80DD30DB552EC03E7E327E9B1A4BD594E";
            const bool expectedResult = false;
            bool actualResult;

            // Act
            actualResult = userManager.AuthenticateUser(loginName, passwordHash);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestAuthenticateUserFailsWithIncorrectPasswordHash()
        {
            // Arrange
            const string loginName = "tessdata";
            const string passwordHash = "x9C9064C59F1FFA2E174EE754D2979BE80DD30DB552EC03E7E327E9B1A4BD594E";
            const bool expectedResult = false;
            bool actualResult;

            // Act
            actualResult = userManager.AuthenticateUser(loginName, passwordHash);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        
        [TestMethod]
        public void TestAuthenticateUserFailsWithDuplicateUsers()
        {
            // Arrange
            const string loginName = "duplicate";
            const string passwordHash = "dup-9C9064C59F1FFA2E174EE754D2979BE80DD30DB552EC03E7E327E9B1A4BD594E";
            const bool expectedResult = false;
            bool actualResult;

            // Act
            actualResult = userManager.AuthenticateUser(loginName, passwordHash);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestSelectUserByLoginNameReturnsCorrectUser()
        {
            // Arrange
            User user = null;
            const string expectedCharacterName = "Tessy";
            const string expectedLoginName = "tessdata";
            string actualCharacterName;

            // Act
            user = userManager.GetUserByLoginName(expectedLoginName);
            actualCharacterName = user.CharacterName;

            // Assert
            Assert.AreEqual(expectedCharacterName, actualCharacterName);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestSelectUserByLoginNameReturnsApplicationException()
        {
            // Arrange
            User user = null;
            const string badLoginName = "xtessdata";

            // Act
            user = userManager.GetUserByLoginName(badLoginName);

            // Assert
            // nothing to do, checking for exception
        }

        [TestMethod]
        public void TestGetRolesForUserReturnsCorrectList()
        {
            // arrange
            var expectedRoles = new List<string>();
            expectedRoles.Add("Villager");
            expectedRoles.Add("Island Owner");
            List<string> actualRoles = null;
            const int villagerID = 1;

            // act
            actualRoles = userManager.GetRolesForUser(villagerID);

            // assert

            CollectionAssert.AreEquivalent(expectedRoles, actualRoles); //would work in this case but not all cases

        }

        [TestMethod]
        public void TestGetRolesForUserFailsWithIncorrectList()
        {
            // arrange
            var expectedRoles = new List<string>();
            expectedRoles.Add("xVillager");
            expectedRoles.Add("Island Owner");
            List<string> actualRoles = null;
            const int villagerID = 1;

            // act
            actualRoles = userManager.GetRolesForUser(villagerID);

            // assert

            CollectionAssert.AreNotEquivalent(expectedRoles, actualRoles); //would work in this case but not all cases
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestGetRolesForBadVillagerIDThrowsApplicationException()
        {
            // arrange
            const int badVillagerID = -1;

            // act
            userManager.GetRolesForUser(badVillagerID);

            // assert
            // nothing to do, exception checking

        }

        [TestMethod]
        public void TestGetUserRoleStringReturnsCorrectRoleStringTwoRoles()
        {
            // arrange
            const string loginName = "tessdata";
            const string expectedResult = "Villager and Island Owner";
            string actualResult;
            User user;

            // act
            user = userManager.GetUserByLoginName(loginName);
            actualResult = userManager.GetUserRoleString(user);

            // assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestResetPasswordWorksWithValidPasswords()
        {
            // arrange
            const string loginName = "tessdata";
            const string oldPassword = "newuser";
            const string newPassword = "P@ssw0rd";
            bool expectedResult = true;
            bool actualResult;

            //act
            actualResult = userManager.ResetPassword(loginName, oldPassword, newPassword);

            //assert
            Assert.AreEqual(expectedResult, actualResult);

        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestResetPasswordThrowsExceptionWithBadOldPassword()
        {
            // arrange
            const string loginName = "tessdata";
            const string oldPassword = "xnewuser";
            const string newPassword = "P@ssw0rd";

            //act
            userManager.ResetPassword(loginName, oldPassword, newPassword);

            //assert
            // nothing to do, exception checking

        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestResetPasswordThrowsExceptionWithBadLoginName()
        {
            // arrange
            const string loginName = "xtessdata";
            const string oldPassword = "newuser";
            const string newPassword = "P@ssw0rd";

            //act
            userManager.ResetPassword(loginName, oldPassword, newPassword);

            //assert
            // nothing to do, exception checking

        }

        [TestMethod]
        public void TestDeleteUserRoleWorksWithGoodVillagerID()
        {
            // arrange
            const string role = "Villager";
            const int villagerID = 1;
            List<string> roles = userManager.GetRolesForUser(villagerID);

            // act
            userManager.DeleteUserRole(villagerID, role);           

            // assert
            CollectionAssert.DoesNotContain(roles, role);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestDeleteUserRoleFailsWithBadVillagerID()
        {
            // arrange
            const string role = "Villager";
            const int villagerID = -1;
            List<string> roles = userManager.GetRolesForUser(villagerID);

            // act
            userManager.DeleteUserRole(villagerID, role);

            // assert
                // nothing to do here, error checking
        }

        [TestMethod]
        public void TestAddUserRoleWorksWithGoodVillagerIDAndRole()
        {
            // arrange
            const string role = "Museum Admin";
            const int villagerID = 1;
            List<string> roles = userManager.GetRolesForUser(villagerID);

            // act
            userManager.AddUserRole(villagerID, role);

            // assert
            CollectionAssert.Contains(roles, role);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestAddUserRoleFailsWithBadVillagerID()
        {
            // arrange
            const string role = "Museum Admin";
            const int villagerID = -1;
            List<string> roles = userManager.GetRolesForUser(villagerID);

            // act
            userManager.AddUserRole(villagerID, role);

            // assert
                // nothing to do here, error checking
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestAddUserRoleFailsWithBadRole()
        {
            // arrange
            const string role = "M";
            const int villagerID = 1;
            List<string> roles = userManager.GetRolesForUser(villagerID);

            // act
            userManager.AddUserRole(villagerID, role);

            // assert
                // nothing to do here, error checking
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestAddUserRoleFailsWithDuplicateRole()
        {
            // arrange
            const string role = "Villager";
            const int villagerID = 1;
            List<string> roles = userManager.GetRolesForUser(villagerID);

            // act
            userManager.AddUserRole(villagerID, role);

            // assert
                // nothing to do here, error checking
        }
    }
}
