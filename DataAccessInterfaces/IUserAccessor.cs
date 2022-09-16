using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace DataAccessInterfaces
{
    public interface IUserAccessor
    {
        int AuthenticateUserWithLoginNameAndPasswordHash(string loginName, string passwordHash);
        User SelectUserByLoginName(String loginName);
        List<string> SelectRolesByVillagerID(int villagerID);
        int UpdatePasswordHash(string loginName, string oldPasswordHash, string newPasswordHash);
        List<string> SelectAllRoles();
        User SelectUserByEmail(String email);
        User SelectUserByVillagerID(int villagerID);
        int AuthenticateUserWithEmailAndPasswordHash(string loginName, string passwordHash);
        int DeleteUserRole(int villagerID, string role);
        int InsertUserRole(int villagerID, string role);
    }
}
