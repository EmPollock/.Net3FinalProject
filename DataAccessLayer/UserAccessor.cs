using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using DataAccessInterfaces;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    public class UserAccessor : IUserAccessor
    {
        public int AuthenticateUserWithLoginNameAndPasswordHash(string loginName, string passwordHash)
        {
            int result = 0;

            var conn = DBConnection.GetConnection();
            var cmdText = "sp_authenticate_user";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@login_name", SqlDbType.NVarChar, 16);
            cmd.Parameters.Add("@password_hash", SqlDbType.NVarChar, 64);
            cmd.Parameters["@login_name"].Value = loginName;
            cmd.Parameters["@password_hash"].Value = passwordHash;

            try
            {
                conn.Open();

                result = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }

        public List<string> SelectAllRoles()
        {
            List<string> roles = new List<string>();

            var conn = DBConnection.GetConnection();
            string cmdText = @"sp_select_all_roles";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;           

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        roles.Add(reader.GetString(0));
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return roles;
        }

        public List<string> SelectRolesByVillagerID(int villagerID)
        {
            List<string> roles = new List<string>();

            var conn = DBConnection.GetConnection();
            string cmdText = @"sp_select_villager_roles_by_villager_id";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@villager_id", SqlDbType.Int);
            cmd.Parameters["@villager_id"].Value = villagerID;

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        roles.Add(reader.GetString(0));
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return roles;
        }

        public User SelectUserByLoginName(string loginName)
        {
            User user = null;

            var conn = DBConnection.GetConnection();
            string commandText = "sp_select_villager_by_login_name";
            var cmd = new SqlCommand(commandText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@login_name", SqlDbType.NVarChar, 16);
            cmd.Parameters["@login_name"].Value = loginName;

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        user = new User()
                        {
                            VillagerID = reader.GetInt32(0),
                            CharacterName = reader.GetString(1),
                            Email = reader.GetString(2),
                            LoginName = loginName,
                            Active = reader.GetBoolean(3)
                        };
                    }
                }
                else
                {
                    throw new ApplicationException("User not found.");
                }
            }
            catch (Exception)
            {

                throw;
            }

            return user;
        }

        public User SelectUserByVillagerID(int villagerID)
        {
            User user = null;

            var conn = DBConnection.GetConnection();
            string commandText = "sp_select_villager_by_villager_id";
            var cmd = new SqlCommand(commandText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@villager_id", SqlDbType.Int);
            cmd.Parameters["@villager_id"].Value = villagerID;

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        user = new User()
                        {
                            CharacterName = reader.GetString(0),
                            LoginName = reader.GetString(1),
                            Email = reader.GetString(2),
                            Active = reader.GetBoolean(3),
                            VillagerID = villagerID
                        };
                    }
                }
                else
                {
                    throw new ApplicationException("User not found.");
                }
            }
            catch (Exception)
            {

                throw;
            }

            return user;
        }

        public User SelectUserByEmail(string email)
        {
            User user = null;

            var conn = DBConnection.GetConnection();
            string commandText = "sp_select_villager_by_email";
            var cmd = new SqlCommand(commandText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@email", SqlDbType.NVarChar, 250);
            cmd.Parameters["@email"].Value = email;

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        user = new User()
                        {
                            VillagerID = reader.GetInt32(0),
                            CharacterName = reader.GetString(1),
                            LoginName = reader.GetString(2),
                            Active = reader.GetBoolean(3),
                            Email = email
                        };
                    }
                }
                else
                {
                    throw new ApplicationException("User not found.");
                }
            }
            catch (Exception)
            {

                throw;
            }

            return user;
        }

        public int UpdatePasswordHash(string loginName, string oldPasswordHash, string newPasswordHash)
        {
            int rowsAffected = 0;

            var conn = DBConnection.GetConnection();
            string cmdText = @"sp_update_passwordHash";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@login_name", SqlDbType.NVarChar, 16);
            cmd.Parameters.Add("@old_password_hash", SqlDbType.NVarChar, 64);
            cmd.Parameters.Add("@new_password_hash", SqlDbType.NVarChar, 64);

            cmd.Parameters["@login_name"].Value = loginName;
            cmd.Parameters["@old_password_hash"].Value = oldPasswordHash;
            cmd.Parameters["@new_password_hash"].Value = newPasswordHash;

            try
            {
                conn.Open();
                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return rowsAffected;
        }

        public int AuthenticateUserWithEmailAndPasswordHash(string email, string passwordHash)
        {
            int result = 0;

            var conn = DBConnection.GetConnection();
            var cmdText = "sp_authenticate_user_by_email";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@email", SqlDbType.NVarChar, 250);
            cmd.Parameters.Add("@password_hash", SqlDbType.NVarChar, 64);
            cmd.Parameters["@email"].Value = email;
            cmd.Parameters["@password_hash"].Value = passwordHash;

            try
            {
                conn.Open();

                result = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }

        public int DeleteUserRole(int villagerID, string role)
        {
            int rowsAffected = 0;

            var conn = DBConnection.GetConnection();
            var cmdText = "sp_delete_villager_role";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@villager_id", SqlDbType.Int);
            cmd.Parameters.Add("@role", SqlDbType.NVarChar, 64);
            cmd.Parameters["@villager_id"].Value = villagerID;
            cmd.Parameters["@role"].Value = role;

            try
            {
                conn.Open();
                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return rowsAffected;
        }

        public int InsertUserRole(int villagerID, string role)
        {
            int rowsAffected = 0;

            var conn = DBConnection.GetConnection();
            var cmdText = "sp_insert_villager_role";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@villager_id", SqlDbType.Int);
            cmd.Parameters.Add("@role", SqlDbType.NVarChar, 64);
            cmd.Parameters["@villager_id"].Value = villagerID;
            cmd.Parameters["@role"].Value = role;

            try
            {
                conn.Open();
                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return rowsAffected;
        }
    }
}
