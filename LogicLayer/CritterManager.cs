using DataAccessFakes;
using DataAccessInterfaces;
using DataAccessLayer;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class CritterManager : ICritterManager
    {
        ICritterAccessor _critterAccessor;
        IUserAccessor _userAccessor;
        public CritterManager()
        {
            _critterAccessor = new CritterAccessor();
            _userAccessor = new UserAccessor();
        }

        public CritterManager(ICritterAccessor critterAccessor, IUserAccessor userAccessor)
        {
            _critterAccessor = critterAccessor;
            _userAccessor = userAccessor;
        }

        public List<CritterVM> RetrieveActive()
        {
            List<CritterVM> critterList = new List<CritterVM>();
            try
            {
                critterList = _critterAccessor.SelectActiveCritters();
                setCritterMonthsAndHours(critterList);
                setUserCaughtBy(critterList);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return critterList;
        }

        public List<CritterVM> RetrieveAll()
        {
            List<CritterVM> critterList = new List<CritterVM>();

            try
            {
                critterList = _critterAccessor.SelectAllCritters();
                setCritterMonthsAndHours(critterList);
                setUserCaughtBy(critterList);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return critterList;
        }

        public List<CritterVM> RetrieveCatchable()
        {
            List<CritterVM> critters;
            try
            {
                DateTime today = DateTime.Now;
                int month = today.Month;
                switch (month){
                    case 1:
                        critters = (List<CritterVM>)RetrieveActive().Where(c => c.CatchableMonths.Contains("jan")).Cast<int>();
                        break;
                    case 2:
                        critters = (List<CritterVM>)RetrieveActive().Where(c => c.CatchableMonths.Contains("feb")).Cast<int>();
                        break;
                    case 3:
                        critters = (List<CritterVM>)RetrieveActive().Where(c => c.CatchableMonths.Contains("mar")).Cast<int>();
                        break;
                    case 4:
                        critters = (List<CritterVM>)RetrieveActive().Where(c => c.CatchableMonths.Contains("apr")).Cast<int>();
                        break;
                    case 5:
                        critters = (List<CritterVM>)RetrieveActive().Where(c => c.CatchableMonths.Contains("may")).Cast<int>();
                        break;
                    case 6:
                        critters = (List<CritterVM>)RetrieveActive().Where(c => c.CatchableMonths.Contains("june")).Cast<int>();
                        break;
                    case 7:
                        critters = (List<CritterVM>)RetrieveActive().Where(c => c.CatchableMonths.Contains("july")).Cast<int>();
                        break;
                    case 8:
                        critters = (List<CritterVM>)RetrieveActive().Where(c => c.CatchableMonths.Contains("aug")).Cast<int>();
                        break;
                    case 9:
                        critters = (List<CritterVM>)RetrieveActive().Where(c => c.CatchableMonths.Contains("sep")).Cast<int>();
                        break;
                    case 10:
                        critters = (List<CritterVM>)RetrieveActive().Where(c => c.CatchableMonths.Contains("oct")).Cast<int>();
                        break;
                    case 11:
                        critters = (List<CritterVM>)RetrieveActive().Where(c => c.CatchableMonths.Contains("nov")).Cast<int>();
                        break;
                    case 12:
                        critters = (List<CritterVM>)RetrieveActive().Where(c => c.CatchableMonths.Contains("dec")).Cast<int>();
                        break;
                    default:
                        critters = RetrieveActive();
                        break;
                }

                 critters = (List<CritterVM>)RetrieveActive().Where(c => c.CatchableHours.Contains(today.Hour)).Cast<int>();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return critters;
        }

        public List<CritterVM> RetrieveInMuseum()
        {
            List<CritterVM> critters;

            critters = (List<CritterVM>)RetrieveActive().Where(c => c.InMuseum);

            return critters;
        }

        public string getCatchableHourString(CritterVM critter)
        {
            string result = "";

            for(int i = 0; i < critter.CatchableHours.Count; i++)
            {
                int hour = critter.CatchableHours[i];
                if (hour <= 12)
                {
                    result += hour + " AM\t";
                }
                else
                {
                    result += (hour - 12 + " PM\t");
                }
                if(i == 11)
                {
                    result += "\n";
                }
            }

            return result;
        }
        public string getCatchableMonthString(CritterVM critter)
        {
            string result = "";

            result += critter.CatchableMonths.Contains("Jan") ? "Jan  " : "     ";
            result += critter.CatchableMonths.Contains("Feb") ? "Feb  " : "     ";
            result += critter.CatchableMonths.Contains("Mar") ? "Mar  " : "     ";
            result += critter.CatchableMonths.Contains("Apr") ? "Apr  \n" : "     \n";
            result += critter.CatchableMonths.Contains("May") ? "May  " : "     ";
            result += critter.CatchableMonths.Contains("June") ? "June " : "     ";
            result += critter.CatchableMonths.Contains("July") ? "July " : "     ";
            result += critter.CatchableMonths.Contains("Aug") ? "Aug  \n" : "     \n";
            result += critter.CatchableMonths.Contains("Sep") ? "Sep  " : "     ";
            result += critter.CatchableMonths.Contains("Oct") ? "Oct  " : "     ";
            result += critter.CatchableMonths.Contains("Nov") ? "Nov  " : "     ";
            result += critter.CatchableMonths.Contains("Dec") ? "Dec  " : "     ";

            return result;
        }

        public List<CritterVM> RetrieveCaughtByUser(int villagerID)
        {
            List<CritterVM> critters = new List<CritterVM>();

            try
            {
                critters = _critterAccessor.SelectAllCrittersCaughtByVillagerID(villagerID);
                setCritterMonthsAndHours(critters);
                setUserCaughtBy(critters);
                if(critters.Count == 0)
                {
                    throw new ApplicationException();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }           

            return critters;
        }

        public void setCritterMonthsAndHours(List<CritterVM> critters)
        {
            foreach (CritterVM critter in critters)
            {
                critter.CatchableMonths = _critterAccessor.SelectCatchMonthsByCritterId(critter.CritterId);
                critter.CatchableHours = _critterAccessor.SelectCatchHoursByCritterId(critter.CritterId);

                critter.CatchableMonthString = getCatchableMonthString(critter);
                critter.CatchableHourString = getCatchableHourString(critter);
            }
        }

        public void setUserCaughtBy(List<CritterVM> critters)
        {
            foreach(CritterVM critter in critters)
            {
                critter.UserCaughtDate = _critterAccessor.SelectUserAndCaughtByDateByCritterID(critter.CritterId);
                String userCaugthDateString = "";
                foreach(int villagerID in critter.UserCaughtDate.Keys)
                {
                    User user = _userAccessor.SelectUserByVillagerID(villagerID);
                    userCaugthDateString += "Caught by " + user.CharacterName + " on " + critter.UserCaughtDate[villagerID]+"\n";
                }
                critter.UserCaughtDateString = userCaugthDateString;
            }
        }

        public void setCritterCaughtByCurrentUser(List<CritterVM> critters, int villagerID)
        {
            foreach(CritterVM critter in critters)
            {
                if (critter.UserCaughtDate.ContainsKey(villagerID))
                {
                    critter.CaughtByCurrentUser = true;
                }
                else
                {
                    critter.CaughtByCurrentUser = false;
                }
            }
        }

        public bool AddCritter(Critter critter)
        {
            bool result = false;

            try
            {
                result = 1 == _critterAccessor.InsertCritter(critter);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public bool AddCatchableMonth(CritterVM critter)
        {
            bool result = false;

            try
            {
                result = 1 == _critterAccessor.InsertCatchableMonth(critter);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public bool AddCatchableHour(CritterVM critter)
        {
            bool result = false;

            try
            {
                result = 1 == _critterAccessor.InsertCatchableHour(critter);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public bool RemoveCritter(Critter critter)
        {
            bool result = false;

            try
            {
                result = 1 == _critterAccessor.DeleteCritter(critter);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public bool RemoveMonthsByCritterID(string critterID)
        {
            bool result = false;

            try
            {
                result = 1 == _critterAccessor.DeleteMonthsByCritterID(critterID);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public bool RemoveHoursByCritterID(string critterID)
        {
            bool result = false;

            try
            {
                result = 1 == _critterAccessor.DeleteHoursByCritterID(critterID);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public bool RemoveCaughtByByCritterID(string critterID)
        {
            bool result = false;

            try
            {
                result = 1 == _critterAccessor.DeleteCaughtByByCritterId(critterID);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public bool AddCaughtBy(int villagerID, string critterID, DateTime caughtDate)
        {
            try
            {
                return 1 == _critterAccessor.InsertCaughtBy(villagerID, critterID, caughtDate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool putCritterInMuseum(string critterID, string loginName)
        {
            try
            {
                return 1 == _critterAccessor.PutCritterInMuseum(critterID, loginName);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool removeCritterFromMuseum(string critterID)
        {
            try
            {
                return 1 == _critterAccessor.RemoveCritterFromMuseum(critterID);
            }
            catch (Exception ex)
            {
                throw ex;
            };
        }
    }
}
