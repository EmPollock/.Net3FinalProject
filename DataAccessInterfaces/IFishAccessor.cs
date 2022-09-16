using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace DataAccessInterfaces
{
    public interface IFishAccessor
    {
        FishVM SelectFishByCritterID(string critterID);
        List<String> SelectAllLocations();
        List<String> SelectAllShadowSizes();
        int InsertFish(Fish fish);
        int DeleteFish(Fish fish);
    }
}
