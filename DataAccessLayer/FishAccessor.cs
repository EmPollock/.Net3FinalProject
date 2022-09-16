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
    public class FishAccessor : IFishAccessor
    {
        private ICritterAccessor _critterAccessor = new CritterAccessor();
        public int DeleteFish(Fish fish)
        {
            int rowsAffected = 0;
            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_delete_fish_by_fish";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@critter_id", SqlDbType.NVarChar, 40);
            cmd.Parameters["@critter_id"].Value = fish.CritterId;
            cmd.Parameters.Add("@location_id", SqlDbType.NVarChar, 40);
            cmd.Parameters["@location_id"].Value = fish.LocationId;
            cmd.Parameters.Add("@shadow_size_id", SqlDbType.NVarChar, 40);
            cmd.Parameters["@shadow_size_id"].Value = fish.ShadowSizeId;

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

        public int InsertFish(Fish fish)
        {
            int rowsAffected = 0;
            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_insert_fish";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@critter_id", SqlDbType.NVarChar, 40);
            cmd.Parameters["@critter_id"].Value = fish.CritterId;
            cmd.Parameters.Add("@location_id", SqlDbType.NVarChar, 40);
            cmd.Parameters["@location_id"].Value = fish.LocationId;
            cmd.Parameters.Add("@shadow_size_id", SqlDbType.NVarChar, 40);
            cmd.Parameters["@shadow_size_id"].Value = fish.ShadowSizeId;

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

        public List<string> SelectAllLocations()
        {
            List<string> locations = new List<string>();

            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_select_all_locations";
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
                        /*[location_id]*/
                        locations.Add(reader.GetString(0));
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

            return locations;
        }

        public List<string> SelectAllShadowSizes()
        {
            List<string> shadowSizes = new List<string>();

            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_select_all_shadow_sizes";
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
                        /*[shadow_size_id]*/
                        shadowSizes.Add(reader.GetString(0));
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

            return shadowSizes;
        }

        public FishVM SelectFishByCritterID(string critterID)
        {
            FishVM fish = new FishVM();

            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_select_fish_by_critter_id";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@critter_id", SqlDbType.NVarChar, 40);
            cmd.Parameters["@critter_id"].Value = critterID;

            try
            {
                CritterVM critter = _critterAccessor.SelectCritterByCritterID(critterID);
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        /*[location_id], [location_description], [shadow_size_id]*/
                        fish.CritterId = critter.CritterId;
                        fish.CritterTypeId = critter.CritterTypeId;
                        fish.RainNeeded = critter.RainNeeded;
                        fish.InMuseum = critter.InMuseum;
                        fish.Price = critter.Price;
                        fish.Active = critter.Active;
                        fish.CatchableMonths = critter.CatchableMonths;
                        fish.CatchableHours = critter.CatchableHours;
                        fish.MuseumBy = critter.MuseumBy;
                        fish.CatchDescription = critter.CatchDescription;
                        fish.UserCaughtDate = critter.UserCaughtDate;;
                        fish.LocationId = reader.GetString(0);
                        fish.LocationDescription = reader.GetString(1);
                        fish.ShadowSizeId = reader.GetString(2);
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

            return fish;
        }
    }
}
