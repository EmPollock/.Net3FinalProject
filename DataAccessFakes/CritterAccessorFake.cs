using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessInterfaces;
using DataObjects;

namespace DataAccessFakes
{
    public class CritterAccessorFake : ICritterAccessor
    {
        private List<CritterVM> fakeCritters = new List<CritterVM>();
        private UserAccessorFake userAccessor = new UserAccessorFake();
        private Dictionary<String, List<String>> critterMonths = new Dictionary<String, List<String>>();
        private Dictionary<String, List<int>> critterHours = new Dictionary<string, List<int>>();

        public CritterAccessorFake()
        {
            Dictionary<String, DateTime> tessCaught = new Dictionary<string, DateTime>();
            fakeCritters.Add(new CritterVM()
            {
                CritterId = "Big-Mouthed Bass",
                RainNeeded = false,
                InMuseum = true,
                Price = 500,
                CritterTypeId = "fish",
                Active = true,
                MuseumBy = "tessdata",
                CatchDescription = "Use a fishing rod or something idk",
                UserCaughtDate = new Dictionary<int, DateTime>()
            }) ; 
            critterMonths.Add("Big-Mouthed Bass", new List<string>() { "Jan", "Feb", "Mar", "Nov", "Dec" });
            critterHours.Add("Big-Mouthed Bass", new List<int>() { 9, 10, 11, 12, 13, 14, 15, 16 });

            fakeCritters.Add(new CritterVM()
            {
                CritterId = "Guppy",
                RainNeeded = true,
                InMuseum = false,
                Price = 200,
                CritterTypeId = "fish",
                Active = true,
                CatchDescription = "Use a fishing rod or something idk",
                UserCaughtDate = new Dictionary<int, DateTime>()
            });
            critterMonths.Add("Guppy", new List<string>() { "May", "June", "July", "Oct", "Nov" });
            critterHours.Add("Guppy", new List<int>() { 12, 13, 14, 15, 16, 17, 22, 23, 24 });

            fakeCritters.Add(new CritterVM()
            {
                CritterId = "Kelp",
                RainNeeded = false,
                InMuseum = true,
                Price = 1000,
                CritterTypeId = "sea creature",
                Active = false,                
                CatchDescription = "Go for a swim and find it.",
                UserCaughtDate = new Dictionary<int, DateTime>()
            });
            critterMonths.Add("Kelp", new List<string>() { "May", "June", "July", "Oct", "Nov" });
            critterHours.Add("Kelp", new List<int>() { 12, 13, 14, 15, 16, 17, 22, 23, 24 });

            fakeCritters.Add(new CritterVM()
            {
                CritterId = "French Fly",
                RainNeeded = false,
                InMuseum = true,
                Price = 2000,
                CritterTypeId = "bug",
                Active = true,
                CatchDescription = "Fight it with a net",
                UserCaughtDate = new Dictionary<int, DateTime>()
            });
            critterMonths.Add("French Fly", new List<string>() { "June", "July", "Aug" });
            critterHours.Add("French Fly", new List<int>() { 12, 13, 14, 15, 16, 17, 18 });

            fakeCritters[0].UserCaughtDateAdd(1, DateTime.Today);
            fakeCritters[0].UserCaughtDateAdd(2, DateTime.Today.AddDays(-7));
            fakeCritters[2].UserCaughtDateAdd(1, DateTime.Now.AddDays(-5));
            fakeCritters[3].UserCaughtDateAdd(1, DateTime.Now.AddDays(-20));
            DateTime date = fakeCritters[2].UserCaughtDate[1];
        }

        public int DeleteCaughtByByCritterId(string critter_id)
        {
            throw new NotImplementedException();
        }

        public int DeleteCritter(Critter critter)
        {
            int result = 0;
            foreach (CritterVM fakeCritter in fakeCritters)
            {
                if (fakeCritter.CritterId == critter.CritterId)
                {
                    fakeCritters.Remove(fakeCritter);
                    result = 1;
                }
            }

            return result;
        }

        public int DeleteHoursByCritterID(string critter_id)
        {
            throw new NotImplementedException();
        }

        public int DeleteMonthsByCritterID(string critter_id)
        {
            throw new NotImplementedException();
        }

        public int InsertCatchableHour(CritterVM critter)
        {
            int result = 0;
            foreach (CritterVM fakeCritter in fakeCritters)
            {
                if (fakeCritter.CritterId == critter.CritterId)
                {
                    fakeCritter.CatchableHours = critter.CatchableHours;
                    result = 1;
                }
            }

            return result;
        }

        public int InsertCatchableMonth(CritterVM critter)
        {
            int result = 0;
            foreach (CritterVM fakeCritter in fakeCritters)
            {
                if (fakeCritter.CritterId == critter.CritterId)
                {
                    fakeCritter.CatchableMonths = critter.CatchableMonths;
                    result = 1;
                }
            }

            return result;
        }

        public int InsertCaughtBy(int villagerID, string critterID, DateTime caughtDate)
        {
            int rowsAffected = 0;
            try
            {
                userAccessor.SelectUserByVillagerID(villagerID);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            foreach(CritterVM critter in fakeCritters)
            {
                if (critter.CritterId.Equals(critterID))
                {
                    rowsAffected++;
                    critter.UserCaughtDateAdd(villagerID, caughtDate);
                    break;
                }
            }
            return rowsAffected;
        }

        public int InsertCritter(Critter critter)
        {
            fakeCritters.Add(new CritterVM() { CritterId = critter.CritterId}
                );
            return 1;
        }

        public int PutCritterInMuseum(string critterID, string loginName)
        {
            int rowsAffected = 0;

            if(userAccessor.SelectUserByLoginName(loginName) == null)
            {
                throw new ApplicationException();
            }

            foreach(CritterVM critter in fakeCritters)
            {
                if (critter.CritterId.Equals(critterID))
                {
                    if (critter.InMuseum)
                    {
                        break;
                    }
                    rowsAffected++;
                    critter.InMuseum = true;
                    critter.MuseumBy = loginName;
                }
            }

            return rowsAffected;
        }

        public int RemoveCritterFromMuseum(string critterID)
        {
            int rowsAffected = 0;

            foreach (CritterVM critter in fakeCritters)
            {
                if (critter.CritterId.Equals(critterID))
                {
                    if (!critter.InMuseum)
                    {
                        break;
                    }
                    rowsAffected++;
                    critter.InMuseum = false;
                    critter.MuseumBy = "";
                }
            }

            return rowsAffected;
        }

        public List<CritterVM> SelectActiveCritters()
        {
            List<CritterVM> critterList = new List<CritterVM>();
            foreach (CritterVM critter in fakeCritters)
            {
                if (critter.Active)
                {
                    critterList.Add(critter);
                }
            }

            return critterList;
        }

        public List<CritterVM> SelectAllCritters()
        {
            return fakeCritters;
        }

        public List<CritterVM> SelectAllCrittersCaughtByVillagerID(int villagerID)
        {
            List<CritterVM> critterList = new List<CritterVM>();

            foreach(CritterVM critter in fakeCritters)
            {
                if (critter.UserCaughtDate.ContainsKey(villagerID) && critter.Active)
                {
                    critterList.Add(critter);
                }
            }

            return critterList;
        }

        public List<int> SelectCatchHoursByCritterId(string critterId)
        {
            List<int> hours = new List<int>();

            hours = critterHours[critterId];

            return hours;
        }

        public List<string> SelectCatchMonthsByCritterId(string critterId)
        {
            List<string> months = new List<string>();

            months = critterMonths[critterId];

            return months;
        }

        public CritterVM SelectCritterByCritterID(string critterID)
        {
            CritterVM result = null;
            foreach(CritterVM critter in fakeCritters)
            {
                if (critter.CritterId.Equals(critterID)){
                    result = critter;
                }
            }
            return result;
        }

        public Dictionary<int, DateTime> SelectUserAndCaughtByDateByCritterID(string critterId)
        {
            Dictionary<int, DateTime> result = new Dictionary<int, DateTime>();

            foreach(CritterVM critter in fakeCritters)
            {
                if(critter.CritterId == critterId)
                {
                    result = critter.UserCaughtDate;
                }
            }

            return result;
        }
    }
}
