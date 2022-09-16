using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using DataAccessInterfaces;
using DataAccessLayer;
using DataAccessFakes;
using System.Security.Cryptography;

namespace LogicLayer
{
    public class UserManager : IUserManager
    {
        private IUserAccessor _userAccessor = null;

        public UserManager()
        {
            // a default constructor for most uses
            _userAccessor = new UserAccessor();
        }
        public UserManager(IUserAccessor userAccessor)
        {
            // overloaded constructor allows calling code to
            // supply its own IUSerAccessor provider
            _userAccessor = userAccessor;
        }
        public bool AuthenticateUser(string loginName, string passwordHash)
        {
            bool result = false;

            try
            {
                result = (1 == _userAccessor.AuthenticateUserWithLoginNameAndPasswordHash(loginName, passwordHash));
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public User AuthenticateUserByEmail(string email, string password)
        {
            User result = null;

            try
            {
                if(1 == _userAccessor.AuthenticateUserWithEmailAndPasswordHash(email, HashSha256(password)))
                {
                    result = _userAccessor.SelectUserByEmail(email);
                    result.Roles = _userAccessor.SelectRolesByVillagerID(result.VillagerID);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;
        }

        public List<string> GetRolesForUser(int villagerID)
        {
            List<string> roles = new List<string>();
            try
            {
                roles = _userAccessor.SelectRolesByVillagerID(villagerID);
            }
            catch (Exception ex)
            {
                throw;
            }
            return roles;
        }

        public string GetUserRoleString(User user)
        {
            string roleString = "";
            for (int i = 0; i < user.Roles.Count; i++)
            {
                roleString += user.Roles[i];
                if (i == user.Roles.Count - 2)
                {
                    if (user.Roles.Count > 2)
                    {
                        roleString += ", and ";
                    }
                    else
                    {
                        roleString += " and ";
                    }
                }
                else if (i < user.Roles.Count - 2)
                {
                    roleString += ", ";
                }
            }
            return roleString;
        }

        public User GetUserByLoginName(string loginName)
        {
            User requestedUser = null;

            try
            {
                requestedUser = _userAccessor.SelectUserByLoginName(loginName);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return requestedUser;
        }

        public User GetUserByEmail(string email)
        {
            User requestedUser = null;

            try
            {
                requestedUser = _userAccessor.SelectUserByEmail(email);
            }
            catch (Exception)
            {

                throw;
            }

            return requestedUser;
        }

        public string HashSha256(string source)
        {
            String result = "";

            // create a byte array
            byte[] data;

            // create a .NET hash provider object
            using (SHA256 sha256hasher = SHA256.Create())
            {
                // hash the input
                data = sha256hasher.ComputeHash(
                    Encoding.UTF8.GetBytes(source));
            }

            // create an output stringbuilder object
            var s = new StringBuilder();

            // loop throught the hashed output making characters
            for (int i = 0; i < data.Length; i++)
            {
                s.Append(data[i].ToString("x2"));
            }

            // convert the StringBuilder to a string
            result = s.ToString();

            return result.ToUpper();
        }

        public User LoginUser(string loginName, string password)
        {
            User loggedInUser = null;

            try
            {
                if (loginName == "")
                {
                    throw new ArgumentException("Missing email");
                }
                if (password == "") // or fails complexity rules
                {
                    throw new ArgumentException("Missing password");
                }

                string passwordHash = HashSha256(password);
                if (AuthenticateUser(loginName, passwordHash))
                {
                    loggedInUser = GetUserByLoginName(loginName);
                    loggedInUser.Roles = GetRolesForUser(loggedInUser.VillagerID);
                }
                else
                {
                    throw new ApplicationException("Bad Login Name or Password.");
                }
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Login failed. Please check your credentials.", ex);
            }

            return loggedInUser;
     
        }

        public bool ResetPassword(string loginName, string oldPassword, string newPassword)
        {
            bool result = false;

            try
            {
                result = (1 == _userAccessor.UpdatePasswordHash(
                    loginName,
                    HashSha256(oldPassword),
                    HashSha256(newPassword)));

                if (!result)
                {
                    throw new ApplicationException("Update Failed");
                }
            }
            catch (Exception)
            {
                throw;
            }


            return result;
        }

        public List<string> GetAllRoles()
        {
            List<string> roles = null;

            try
            {
                roles = _userAccessor.SelectAllRoles();
            }
            catch (Exception)
            {
                throw;
            }

            return roles;
        }

        public bool FindUser(string email)
        {
            try
            {                
                return _userAccessor.SelectUserByEmail(email) != null;
            }
            catch (ApplicationException ax)
            {
                if (ax.Message.Equals("User not found."))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Database Error", ex);
            }
        }

        public void DeleteUserRole(int villagerID, string role)
        {
            try
            {
                if (_userAccessor.DeleteUserRole(villagerID, role) != 1)
                {
                    throw new ApplicationException("Something went wrong trying to delete the role. Please try again later.");
                }
            } catch(Exception ex)
            {
                throw ex;
            }
        }

        public void AddUserRole(int villagerID, string role)
        {
            try
            {
                if (_userAccessor.InsertUserRole(villagerID, role) != 1)
                {
                    throw new ApplicationException("Something went wrong trying to add the role. Please try again later.");
                }
            } catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
