using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace LogicLayer
{
    public interface ICritterManager
    {
        List<CritterVM> RetrieveAll();
        List<CritterVM> RetrieveActive();
        List<CritterVM> RetrieveCatchable();
        List<CritterVM> RetrieveInMuseum();
        String getCatchableMonthString(CritterVM critter);
        String getCatchableHourString(CritterVM critter);
        List<CritterVM> RetrieveCaughtByUser(int villagerID);
        void setCritterMonthsAndHours(List<CritterVM> critters);
        void setUserCaughtBy(List<CritterVM> critters);
        void setCritterCaughtByCurrentUser(List<CritterVM> critters, int villagerID);
        bool AddCritter(Critter critter);
        bool AddCatchableMonth(CritterVM critter);
        bool AddCatchableHour(CritterVM critter);
        bool RemoveCritter(Critter critter);
        bool RemoveMonthsByCritterID(string critterID);
        bool RemoveHoursByCritterID(string critterID);
        bool RemoveCaughtByByCritterID(string critterID);
        bool AddCaughtBy(int villagerID, string critterID, DateTime caughtDate);
        bool putCritterInMuseum(string critterID, string loginName);
        bool removeCritterFromMuseum(string critterID);
    }
}
