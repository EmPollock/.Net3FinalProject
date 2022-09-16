using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace DataAccessInterfaces
{
    public interface ICritterAccessor
    {
        List<CritterVM> SelectActiveCritters();
        List<String> SelectCatchMonthsByCritterId(String critterId);
        List<int> SelectCatchHoursByCritterId(String critterId);
        List<CritterVM> SelectAllCritters();
        List<CritterVM> SelectAllCrittersCaughtByVillagerID(int villagerID);
        Dictionary<int, DateTime> SelectUserAndCaughtByDateByCritterID(string critterId);
        int InsertCritter(Critter critter);
        int InsertCatchableMonth(CritterVM critter);
        int InsertCatchableHour(CritterVM critter);
        int DeleteCritter(Critter critter);
        int DeleteMonthsByCritterID(String critter_id);
        int DeleteHoursByCritterID(String critter_id);
        int DeleteCaughtByByCritterId(String critter_id);
        CritterVM SelectCritterByCritterID(string critterID);
        int InsertCaughtBy(int villagerID, String critterID, DateTime caughtDate);
        int PutCritterInMuseum(String critterID, String loginName);
        int RemoveCritterFromMuseum(string critterID);
    }
}
