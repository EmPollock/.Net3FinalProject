using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessInterfaces;
using DataObjects;

namespace DataAccessLayer
{
    public class BugAccessor : IBugAccessor
    {
        ICritterAccessor _critterAccessor = new CritterAccessor();
        public int DeleteBug(Bug bug)
        {
            int rowsAffected = 0;
            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_delete_bug_by_bug";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@critter_id", SqlDbType.NVarChar, 40);
            cmd.Parameters["@critter_id"].Value = bug.CritterId;
            cmd.Parameters.Add("@spot_id", SqlDbType.NVarChar, 40);
            cmd.Parameters["@spot_id"].Value = bug.SpotId;

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

        public int InsertBug(Bug bug)
        {
            int rowsAffected = 0;
            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_insert_bug";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@critter_id", SqlDbType.NVarChar, 40);
            cmd.Parameters["@critter_id"].Value = bug.CritterId;
            cmd.Parameters.Add("@spot_id", SqlDbType.NVarChar, 40);
            cmd.Parameters["@spot_id"].Value = bug.SpotId;

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

        public List<string> SelectAllSpots()
        {
            List<string> spots = new List<string>();

            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_select_all_bug_finding_spots";
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
                        /*[spot_id]*/
                        spots.Add(reader.GetString(0));
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return spots;
        }

        public BugVM SelectBugByCritter(String critterID)
        {
            BugVM bug = new BugVM();

            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_select_bug_by_critter_id";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@critter_id", SqlDbType.NVarChar, 40);
            cmd.Parameters["@critter_id"].Value = critterID;           

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                CritterVM critter = _critterAccessor.SelectCritterByCritterID(critterID);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        /*[spot_id], [spot_description]*/
                        bug.CritterId = critter.CritterId;
                        bug.CritterTypeId = critter.CritterTypeId;
                        bug.RainNeeded = critter.RainNeeded;
                        bug.InMuseum = critter.InMuseum;
                        bug.Price = critter.Price;
                        bug.Active = critter.Active;
                        bug.CatchableMonths = critter.CatchableMonths;
                        bug.CatchableHours = critter.CatchableHours;
                        bug.CatchableMonthString = critter.CatchableMonthString;
                        bug.CatchableHourString = critter.CatchableHourString;
                        bug.MuseumBy = critter.MuseumBy;
                        bug.CatchDescription = critter.CatchDescription;
                        bug.UserCaughtDate = critter.UserCaughtDate;
                        bug.CaughtByCurrentUser = critter.CaughtByCurrentUser;
                        bug.SpotId = reader.GetString(0);
                        bug.SpotDescription = reader.GetString(1);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return bug;
        }
    }
}
