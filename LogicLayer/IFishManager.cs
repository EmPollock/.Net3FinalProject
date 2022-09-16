using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace LogicLayer
{
    public interface IFishManager
    {
        FishVM RetrieveFishByCritterID(string critterID);
        List<String> RetrieveAllLocations();
        List<String> RetrieveAllShadowSizes();
        bool AddFish(Fish fish);
        bool RemoveFish(Fish fish);
    }
}
