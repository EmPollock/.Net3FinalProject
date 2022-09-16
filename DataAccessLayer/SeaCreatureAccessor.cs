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
    public class SeaCreatureAccessor : ISeaCreatureAccessor
    {
        ICritterAccessor _critterAccessor = new CritterAccessor();
        public int DeleteSeaCreature(SeaCreature seaCreature)
        {
            int rowsAffected = 0;
            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_delete_sea_creature_by_sea_creature";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@critter_id", SqlDbType.NVarChar, 40);
            cmd.Parameters["@critter_id"].Value = seaCreature.CritterId;
            cmd.Parameters.Add("@movement_id", SqlDbType.NVarChar, 40);
            cmd.Parameters["@movement_id"].Value = seaCreature.movementId;
            cmd.Parameters.Add("@shadow_size_id", SqlDbType.NVarChar, 40);
            cmd.Parameters["@shadow_size_id"].Value = seaCreature.ShadowSizeId;

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

        public int InsertSeaCreature(SeaCreature seaCreature)
        {
            int rowsAffected = 0;
            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_insert_sea_creature";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@critter_id", SqlDbType.NVarChar, 40);
            cmd.Parameters["@critter_id"].Value = seaCreature.CritterId;
            cmd.Parameters.Add("@movement_id", SqlDbType.NVarChar, 40);
            cmd.Parameters["@movement_id"].Value = seaCreature.movementId;
            cmd.Parameters.Add("@shadow_size_id", SqlDbType.NVarChar, 40);
            cmd.Parameters["@shadow_size_id"].Value = seaCreature.ShadowSizeId;

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

        public List<string> SelectAllMovements()
        {
            List<string> movements = new List<string>();

            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_select_all_movements";
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
                        /*[movement_id]*/
                        movements.Add(reader.GetString(0));
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

            return movements;
        }

        public SeaCreature SelectSeaCreatureByCritterID(string critterID)
        {
            SeaCreature seaCreature = new SeaCreature();

            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_select_sea_creature_by_critter_id";
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
                        /*[shadow_size_id], [movement_id]*/
                        seaCreature.CritterId = critter.CritterId;
                        seaCreature.CritterTypeId = critter.CritterTypeId;
                        seaCreature.RainNeeded = critter.RainNeeded;
                        seaCreature.InMuseum = critter.InMuseum;
                        seaCreature.Price = critter.Price;
                        seaCreature.Active = critter.Active;
                        seaCreature.CatchableMonths = critter.CatchableMonths;
                        seaCreature.CatchableHours = critter.CatchableHours;
                        seaCreature.CatchableMonthString = critter.CatchableMonthString;
                        seaCreature.CatchableHourString = critter.CatchableHourString;
                        seaCreature.MuseumBy = critter.MuseumBy;
                        seaCreature.CatchDescription = critter.CatchDescription;
                        seaCreature.UserCaughtDate = critter.UserCaughtDate;
                        seaCreature.CaughtByCurrentUser = critter.CaughtByCurrentUser;
                        seaCreature.ShadowSizeId = reader.GetString(0);
                        seaCreature.movementId = reader.GetString(1);
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

            return seaCreature;
        }
    }
}
