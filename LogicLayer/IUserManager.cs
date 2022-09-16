using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using DataAccessInterfaces;
using DataAccessLayer;
using DataAccessFakes;

namespace LogicLayer
{
    public interface IUserManager
    {
        // should return a user object with roles or throw an exception
        User LoginUser(string loginName, string password);
        bool AuthenticateUser(string loginName, string password);
        User AuthenticateUserByEmail(string email, string password);

        string HashSha256(string source);

        User GetUserByLoginName(string loginName);

        List<string> GetRolesForUser(int villagerID);

        string GetUserRoleString(User user);

        bool ResetPassword(string email, string oldPassword, string newPassword);
        List<string> GetAllRoles();

        bool FindUser(string email);

        void DeleteUserRole(int villagerID, string role);
        void AddUserRole(int villagerID, string role);
    }
}
