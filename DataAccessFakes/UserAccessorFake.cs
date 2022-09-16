using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using DataAccessInterfaces;

namespace DataAccessFakes
{
    public class UserAccessorFake : IUserAccessor
    {
        private List<User> fakeUsers = new List<User>();
        private List<string> passwordHashes = new List<string>();
        private List<string> roles = new List<string>()
        {
            "Island Owner",
            "Museum Admin",
            "Villager"
        };

        public UserAccessorFake()
        {
            fakeUsers.Add(new User()
            {
                VillagerID = 1,
                LoginName = "tessdata",
                CharacterName = "Tessy",
                Active = true,
                Roles = new List<string>()
            }) ;
            fakeUsers.Add(new User()
            {
                VillagerID = 2,
                LoginName = "duplicate",
                CharacterName = "Dupy",
                Active = true,
                Roles = new List<string>()
            });
            fakeUsers.Add(new User()
            {
                VillagerID = 3,
                LoginName = "duplicate",
                CharacterName = "Dupy",
                Active = true,
                Roles = new List<string>()
            });
            passwordHashes.Add("9C9064C59F1FFA2E174EE754D2979BE80DD30DB552EC03E7E327E9B1A4BD594E");
            passwordHashes.Add("dup-9C9064C59F1FFA2E174EE754D2979BE80DD30DB552EC03E7E327E9B1A4BD594E");
            passwordHashes.Add("dup-9C9064C59F1FFA2E174EE754D2979BE80DD30DB552EC03E7E327E9B1A4BD594E");

            fakeUsers[0].Roles.Add("Villager");
            fakeUsers[0].Roles.Add("Island Owner");

        }

        public int AuthenticateUserWithEmailAndPasswordHash(string email, string passwordHash)
        {
            int numAuthenticated = 0;

            // check for user records in fake data
            for (int i = 0; i < fakeUsers.Count; i++)
            {
                int userIndex = -1; // invalid list index
                if (fakeUsers[i].Email == email)
                {                   // found email
                    userIndex = i;
                    if (userIndex >= 0)  // if the user was found
                    {                   // and if the passwordHash matches
                        if (passwordHashes[userIndex] == passwordHash && fakeUsers[userIndex].Active)
                        {               // then the user is authenticated
                            numAuthenticated += 1;
                        }
                    }
                }
            }
            return numAuthenticated; // there should normally be 1 or 0
        }

        public int AuthenticateUserWithLoginNameAndPasswordHash(string loginName, string passwordHash)
        {
            int numAuthenticated = 0;

            // check for user records in fake data
            for (int i = 0; i < fakeUsers.Count; i++)
            {
                int userIndex = -1; // invalid list index
                if (fakeUsers[i].LoginName == loginName)
                {                   // found email
                    userIndex = i;
                    if (userIndex >= 0)  // if the user was found
                    {                   // and if the passwordHash matches
                        if (passwordHashes[userIndex] == passwordHash && fakeUsers[userIndex].Active)
                        {               // then the user is authenticated
                            numAuthenticated += 1;
                        }
                    }
                }
            }
            return numAuthenticated; // there should normally be 1 or 0
        }

        public int DeleteUserRole(int villagerID, string role)
        {
            int rowsAffected = 0;
            foreach(User u in fakeUsers)
            {
                if(u.VillagerID == villagerID)
                {
                    foreach(string r in u.Roles)
                    {
                        if (r.Equals(role))
                        {
                            rowsAffected++;
                            u.Roles.Remove(r);
                            break;
                        }
                    }
                }
            }

            return rowsAffected;
        }

        public int InsertUserRole(int villagerID, string role)
        {
            int rowsAffected = 0;

            foreach(User u in fakeUsers)
            {
                if(u.VillagerID == villagerID)
                {
                    if (u.Roles.Contains(role))
                    {
                        break;
                    }
                    else if(roles.Contains(role))
                    {
                        u.Roles.Add(role);
                        rowsAffected++;
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return rowsAffected;
        }

        public List<string> SelectAllRoles()
        {
            return roles;
        }

        public List<string> SelectRolesByLoginName(string loginName)
        {
            List<string> roles = new List<string>();
            bool foundVillager = false;

            for (int i = 0; i < fakeUsers.Count; i++)
            {
                if (fakeUsers[i].LoginName == loginName)
                {
                    roles = fakeUsers[i].Roles;
                    foundVillager = true;
                    break;
                }
            }

            if (!foundVillager)
            {
                throw new ApplicationException("Roles unavailable. Villager not found.");
            }
            return roles;
        }

        public List<string> SelectRolesByVillagerID(int villagerID)
        {
            List<string> result = null;

            foreach(var user in fakeUsers)
            {
                if(user.VillagerID == villagerID)
                {
                    result = user.Roles;
                }
            }

           if(result == null)
            {
                throw new ApplicationException("Could not find a user with the id: " + villagerID+ ".");
            }

            return result;
        }

        public User SelectUserByEmail(string email)
        {
            User user = null;
            foreach (var fakeUser in fakeUsers)
            {
                if (fakeUser.LoginName.Equals(email))
                {
                    user = fakeUser;
                    break;
                }
            }
            if (user == null)
            {
                throw new ApplicationException("User not found.");
            }

            return user;
        }

        public User SelectUserByLoginName(string loginName)
        {
            User user = null;
            foreach (var fakeUser in fakeUsers)
            {
                if (fakeUser.LoginName.Equals(loginName))
                {
                    user = fakeUser;
                    break;
                }
            }
            if (user == null)
            {
                throw new ApplicationException("User not found.");
            }

            return user;
        }

        public User SelectUserByVillagerID(int villagerID)
        {
            User user = null;
            foreach (var fakeUser in fakeUsers)
            {
                if (fakeUser.VillagerID == villagerID)
                {
                    user = fakeUser;
                    break;
                }
            }
            if (user == null)
            {
                throw new ApplicationException("User not found.");
            }

            return user;
        }

        public int UpdatePasswordHash(string loginName, string oldPasswordHash, string newPasswordHash)
        {
            int rowsAffected = 0;

            for (int i = 0; i < fakeUsers.Count; i++)
            {
                if (fakeUsers[i].LoginName == loginName)
                {
                    if (passwordHashes[i] == oldPasswordHash)
                    {
                        passwordHashes[i] = newPasswordHash;
                        rowsAffected++;
                        break;
                    }
                }
            }

            return rowsAffected;
        }


    }
}
