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
    public class CritterAccessor : ICritterAccessor
    {
        UserAccessor _userAccessor = new UserAccessor();

        public int DeleteCaughtByByCritterId(string critter_id)
        {
            int rowsAffected = 0;

            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_delete_caught_by_by_critter_id";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            /*	@critter_id			[nvarchar](40)*/
            cmd.Parameters.Add("@critter_id", SqlDbType.NVarChar, 40);
            cmd.Parameters["@critter_id"].Value = critter_id;

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

        public int DeleteCritter(Critter critter)
        {
            int rowsAffected = 0;

            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_delete_critter_by_critter";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            /*	@critter_id			[nvarchar](40),
	            @critter_type_id	[nvarchar](16),
	            @rain_needed		[bit],
	            @is_in_museum		[bit],
	            @price				[int],
	            @museum_by_login_name [nvarchar](16)
                @active             [bit]*/
            cmd.Parameters.Add("@critter_id", SqlDbType.NVarChar, 40);
            cmd.Parameters["@critter_id"].Value = critter.CritterId;
            cmd.Parameters.Add("@critter_type_id", SqlDbType.NVarChar, 16);
            cmd.Parameters["@critter_type_id"].Value = critter.CritterTypeId;
            cmd.Parameters.Add("@rain_needed", SqlDbType.Bit);
            cmd.Parameters["@rain_needed"].Value = critter.RainNeeded;
            cmd.Parameters.Add("@is_in_museum", SqlDbType.Bit);
            cmd.Parameters["@is_in_museum"].Value = critter.InMuseum;
            cmd.Parameters.Add("@price", SqlDbType.Int);
            cmd.Parameters["@price"].Value = critter.Price;
            cmd.Parameters.Add("@museum_by_login_name", SqlDbType.NVarChar, 16);
            cmd.Parameters["@museum_by_login_name"].Value = critter.MuseumBy;
            cmd.Parameters.AddWithValue("@active", critter.Active);

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

        public int DeleteHoursByCritterID(string critter_id)
        {
            int rowsAffected = 0;

            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_delete_catchable_hour_by_critter_id";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            /*	@critter_id			[nvarchar](40)*/
            cmd.Parameters.Add("@critter_id", SqlDbType.NVarChar, 40);
            cmd.Parameters["@critter_id"].Value = critter_id;

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

        public int DeleteMonthsByCritterID(string critter_id)
        {
            int rowsAffected = 0;

            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_delete_catchable_month_by_critter_id";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            /*	@critter_id			[nvarchar](40)*/
            cmd.Parameters.Add("@critter_id", SqlDbType.NVarChar, 40);
            cmd.Parameters["@critter_id"].Value = critter_id;

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

        public int InsertCatchableHour(CritterVM critter)
        {
            int rowsAffected = 0;

            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_insert_catchable_hour";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@critter_id", SqlDbType.NVarChar, 40);
            cmd.Parameters["@critter_id"].Value = critter.CritterId;
            cmd.Parameters.AddWithValue("@hour1am", critter.CatchableHours.Contains(1));
            cmd.Parameters.AddWithValue("@hour2am", critter.CatchableHours.Contains(2));
            cmd.Parameters.AddWithValue("@hour3am", critter.CatchableHours.Contains(3));
            cmd.Parameters.AddWithValue("@hour4am", critter.CatchableHours.Contains(4));
            cmd.Parameters.AddWithValue("@hour5am", critter.CatchableHours.Contains(5));
            cmd.Parameters.AddWithValue("@hour6am", critter.CatchableHours.Contains(6));
            cmd.Parameters.AddWithValue("@hour7am", critter.CatchableHours.Contains(7));
            cmd.Parameters.AddWithValue("@hour8am", critter.CatchableHours.Contains(8));
            cmd.Parameters.AddWithValue("@hour9am", critter.CatchableHours.Contains(9));
            cmd.Parameters.AddWithValue("@hour10am", critter.CatchableHours.Contains(10));
            cmd.Parameters.AddWithValue("@hour11am", critter.CatchableHours.Contains(11));
            cmd.Parameters.AddWithValue("@hour12pm", critter.CatchableHours.Contains(12));
            cmd.Parameters.AddWithValue("@hour1pm", critter.CatchableHours.Contains(13));
            cmd.Parameters.AddWithValue("@hour2pm", critter.CatchableHours.Contains(14));
            cmd.Parameters.AddWithValue("@hour3pm", critter.CatchableHours.Contains(15));
            cmd.Parameters.AddWithValue("@hour4pm", critter.CatchableHours.Contains(16));
            cmd.Parameters.AddWithValue("@hour5pm", critter.CatchableHours.Contains(17));
            cmd.Parameters.AddWithValue("@hour6pm", critter.CatchableHours.Contains(18));
            cmd.Parameters.AddWithValue("@hour7pm", critter.CatchableHours.Contains(19));
            cmd.Parameters.AddWithValue("@hour8pm", critter.CatchableHours.Contains(20));
            cmd.Parameters.AddWithValue("@hour9pm", critter.CatchableHours.Contains(21));
            cmd.Parameters.AddWithValue("@hour10pm", critter.CatchableHours.Contains(22));
            cmd.Parameters.AddWithValue("@hour11pm", critter.CatchableHours.Contains(23));
            cmd.Parameters.AddWithValue("@hour12am", critter.CatchableHours.Contains(24));

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

        public int InsertCatchableMonth(CritterVM critter)
        {
            int rowsAffected = 0;

            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_insert_catchable_month";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@critter_id", SqlDbType.NVarChar, 40);
            cmd.Parameters["@critter_id"].Value = critter.CritterId;
            cmd.Parameters.AddWithValue("@jan", critter.CatchableMonths.Contains("Jan"));
            cmd.Parameters.AddWithValue("@feb", critter.CatchableMonths.Contains("Feb"));
            cmd.Parameters.AddWithValue("@mar", critter.CatchableMonths.Contains("Mar"));
            cmd.Parameters.AddWithValue("@apr", critter.CatchableMonths.Contains("Apr"));
            cmd.Parameters.AddWithValue("@may", critter.CatchableMonths.Contains("May"));
            cmd.Parameters.AddWithValue("@june", critter.CatchableMonths.Contains("June"));
            cmd.Parameters.AddWithValue("@july", critter.CatchableMonths.Contains("July"));
            cmd.Parameters.AddWithValue("@aug", critter.CatchableMonths.Contains("Aug"));
            cmd.Parameters.AddWithValue("@sep", critter.CatchableMonths.Contains("Sep"));
            cmd.Parameters.AddWithValue("@octo", critter.CatchableMonths.Contains("Oct"));
            cmd.Parameters.AddWithValue("@nov", critter.CatchableMonths.Contains("Nov"));
            cmd.Parameters.AddWithValue("@dec", critter.CatchableMonths.Contains("Dec"));

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

        public int InsertCritter(Critter critter)
        {
            int rowsAffected = 0;

            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_insert_critter";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            /*	@critter_id			[nvarchar](40),
	            @critter_type_id	[nvarchar](16),
	            @rain_needed		[bit],
	            @is_in_museum		[bit],
	            @price				[int]*/
            cmd.Parameters.Add("@critter_id", SqlDbType.NVarChar, 40);
            cmd.Parameters["@critter_id"].Value = critter.CritterId;
            cmd.Parameters.Add("@critter_type_id", SqlDbType.NVarChar, 16);
            cmd.Parameters["@critter_type_id"].Value = critter.CritterTypeId;
            cmd.Parameters.Add("@rain_needed", SqlDbType.Bit);
            cmd.Parameters["@rain_needed"].Value = critter.RainNeeded;
            cmd.Parameters.Add("@is_in_museum", SqlDbType.Bit);
            cmd.Parameters["@is_in_museum"].Value = critter.InMuseum;
            cmd.Parameters.Add("@price", SqlDbType.Int);
            cmd.Parameters["@price"].Value = critter.Price;

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

        public List<CritterVM> SelectActiveCritters()
        {
            List<CritterVM> critters = new List<CritterVM>();

            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_select_all_active_critters";
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
                        /*[critter_id], [rain_needed], [is_in_museum], [price], 
                         * [critter].[critter_type_id], [critter_type].[catch_description]*/
                        critters.Add(new CritterVM
                        {
                            CritterId = reader.GetString(0),
                            RainNeeded = reader.GetBoolean(1),
                            InMuseum = reader.GetBoolean(2),
                            Price = reader.GetInt32(3),
                            MuseumBy = reader.IsDBNull(4) ? null : reader.GetString(4),
                            CritterTypeId = reader.GetString(5),
                            CatchDescription = reader.GetString(6),
                            Active = true
                        }) ;
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

            return critters;
        }

        public List<CritterVM> SelectAllCritters()
        {
            List<CritterVM> critters = new List<CritterVM>();

            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_select_all_critters";
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
                        /*[critter_id], [rain_needed], [is_in_museum], [price], [museum_by_login_name], 
                         * [critter].[critter_type_id], [critter_type].[catch_description], [active]*/
                        critters.Add(new CritterVM
                        {
                            CritterId = reader.GetString(0),
                            RainNeeded = reader.GetBoolean(1),
                            InMuseum = reader.GetBoolean(2),
                            Price = reader.GetInt32(3),
                            MuseumBy = reader.IsDBNull(4) ? null : reader.GetString(4),
                            CritterTypeId = reader.GetString(5),
                            CatchDescription = reader.GetString(6),
                            Active = reader.GetBoolean(7)
                        });
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

            return critters;
        }

        public List<CritterVM> SelectAllCrittersCaughtByVillagerID(int villagerID)
        {
            List<CritterVM> critters = new List<CritterVM>();

            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_select_all_critters_caught_by_villager_id";
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
                    int i = 0;
                    while (reader.Read())
                    {
                        /*[caught_by].[caught_date], [critter].[critter_id], [critter].[rain_needed], [critter].[is_in_museum], 
                         * [critter].[price], [critter].[museum_by_login_name], [critter].[critter_type_id], 
                         * [critter_type].[catch_description]*/
                        critters.Add(new CritterVM
                        {
                            UserCaughtDate = new Dictionary<int, DateTime>(),
                            CritterId = reader.GetString(1),
                            RainNeeded = reader.GetBoolean(2),
                            InMuseum = reader.GetBoolean(3),
                            Price = reader.GetInt32(4),
                            MuseumBy = reader.IsDBNull(5) ? null : reader.GetString(5),
                            CritterTypeId = reader.GetString(6),
                            CatchDescription = reader.GetString(7),
                            Active = true
                        });
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

            return critters;
        }

        public List<int> SelectCatchHoursByCritterId(string critterId)
        {
            List<int> hours = new List<int>();

            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_select_catch_hours_by_critter_id";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@critter_id", SqlDbType.NVarChar, 40);
            cmd.Parameters["@critter_id"].Value = critterId;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        /*[hour1am], [hour2am], [hour3am], [hour4am], [hour5am], [hour6am], 
				        [hour7am], [hour8am], [hour9am], [hour10am], [hour11am], [hour12pm], 
				        [hour1pm], [hour2pm], [hour3pm], [hour4pm], [hour5pm], [hour6pm], 
				        [hour7pm], [hour8pm], [hour9pm], [hour10pm], [hour11pm], [hour12am]*/
                        for (int i = 0; i < 24; i++)
                        {
                            if (reader.GetBoolean(i))
                            {
                                hours.Add(i+1);
                            }
                        } 
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

            return hours;
        }

        public List<string> SelectCatchMonthsByCritterId(string critterId)
        {
            List<string> months = new List<string>();

            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_select_catch_months_by_critter_id";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@critter_id", SqlDbType.NVarChar, 40);
            cmd.Parameters["@critter_id"].Value = critterId;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        /*[jan],[feb],[mar],[apr],[may],[june],[july],[aug],[sep],[octo],[nov],[dec]*/
                        if (reader.GetBoolean(0))
                        {
                            months.Add("Jan");
                        }
                        if (reader.GetBoolean(1))
                        {
                            months.Add("Feb");
                        }
                        if (reader.GetBoolean(2))
                        {
                            months.Add("Mar");
                        }
                        if (reader.GetBoolean(3))
                        {
                            months.Add("Apr");
                        }
                        if (reader.GetBoolean(4))
                        {
                            months.Add("May");
                        }
                        if (reader.GetBoolean(5))
                        {
                            months.Add("June");
                        }
                        if (reader.GetBoolean(6))
                        {
                            months.Add("July");
                        }
                        if (reader.GetBoolean(7))
                        {
                            months.Add("Aug");
                        }
                        if (reader.GetBoolean(8))
                        {
                            months.Add("Sep");
                        }
                        if (reader.GetBoolean(9))
                        {
                            months.Add("Oct");
                        }
                        if (reader.GetBoolean(10))
                        {
                            months.Add("Nov");
                        }
                        if (reader.GetBoolean(11))
                        {
                            months.Add("Dec");
                        }
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

            return months;
        }

        public Dictionary<int, DateTime> SelectUserAndCaughtByDateByCritterID(string critterId)
        {
            Dictionary<int, DateTime> userCaughtBy = new Dictionary<int, DateTime>();

            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_select_caught_bys_by_critter_id";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@critter_id", SqlDbType.NVarChar, 40);
            cmd.Parameters["@critter_id"].Value = critterId;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    /*[villager_id], [caught_date]*/
                    userCaughtBy.Add(reader.GetInt32(0), reader.GetDateTime(1));
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return userCaughtBy;
        }

        public CritterVM SelectCritterByCritterID(string critterID)
        {
            CritterVM critter = null;
            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_select_critter_by_critter_id";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@critter_id", SqlDbType.NVarChar, 40);
            cmd.Parameters["@critter_id"].Value = critterID;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    critter = new CritterVM()
                    {
                        UserCaughtDate = SelectUserAndCaughtByDateByCritterID(critterID),
                        CritterId = critterID,
                        RainNeeded  = reader.GetBoolean(0),
                        InMuseum = reader.GetBoolean(1),
                        Price = reader.GetInt32(2),
                        MuseumBy = reader.IsDBNull(3) ? null : reader.GetString(3),
                        CritterTypeId = reader.GetString(4),
                        CatchDescription = reader.GetString(5),
                        Active = reader.GetBoolean(6),
                        CatchableMonths = SelectCatchMonthsByCritterId(critterID),
                        CatchableHours = SelectCatchHoursByCritterId(critterID),                      
                    };                                       
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

            return critter;
        }

        public int InsertCaughtBy(int villagerID, string critterID, DateTime caughtDate)
        {
            int rowsAffected = 0;

            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_insert_caught_by";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            
            /*	@villager_id        [int],
             *	@critter_id			[nvarchar](40),
             *	@caught_date        [date]
	         */
            cmd.Parameters.Add("@villager_id", SqlDbType.Int);
            cmd.Parameters["@villager_id"].Value = villagerID;
            cmd.Parameters.Add("@critter_id", SqlDbType.NVarChar, 40);
            cmd.Parameters["@critter_id"].Value = critterID;
            cmd.Parameters.Add("@caught_date", SqlDbType.Date);
            cmd.Parameters["@caught_date"].Value = caughtDate;


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

        public int PutCritterInMuseum(string critterID, string loginName)
        {
            int rowsAffected = 0;

            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_put_critter_in_museum";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            /*	@critter_id 				[nvarchar](40),
             *	@museum_by_login_name		[nvarchar](16) 
	         */

            cmd.Parameters.Add("@critter_id", SqlDbType.NVarChar, 40);
            cmd.Parameters["@critter_id"].Value = critterID;
            cmd.Parameters.Add("@museum_by_login_name", SqlDbType.NVarChar, 16);
            cmd.Parameters["@museum_by_login_name"].Value = loginName;

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

        public int RemoveCritterFromMuseum(string critterID)
        {
            int rowsAffected = 0;

            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_remove_critter_from_museum";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            /*	@critter_id 	[nvarchar](40)*/

            cmd.Parameters.Add("@critter_id", SqlDbType.NVarChar, 40);
            cmd.Parameters["@critter_id"].Value = critterID;


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
