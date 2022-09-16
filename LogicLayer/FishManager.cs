using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessInterfaces;
using DataAccessLayer;

namespace LogicLayer
{
    public class FishManager : IFishManager
    {
        IFishAccessor _fishAccessor;
        public FishManager()
        {
            _fishAccessor = new FishAccessor();
        }

        public FishManager(IFishAccessor fishAccessor)
        {
            _fishAccessor = fishAccessor;
        }

        public bool AddFish(Fish fish)
        {
            bool result = false;

            try
            {
                result = 1 == _fishAccessor.InsertFish(fish);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public bool RemoveFish(Fish fish)
        {
            bool result = false;

            try
            {
                result = 1 == _fishAccessor.DeleteFish(fish);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public List<string> RetrieveAllLocations()
        {
            List<string> locations = new List<string>();

            try
            {
                locations = _fishAccessor.SelectAllLocations();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return locations;
        }

        public List<string> RetrieveAllShadowSizes()
        {
            List<string> shadowSizes = new List<string>();

            try
            {
                shadowSizes = _fishAccessor.SelectAllShadowSizes();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return shadowSizes;
        }

        public FishVM RetrieveFishByCritterID(string critterID)
        {
            FishVM result = null;

            try
            {
                result = _fishAccessor.SelectFishByCritterID(critterID);
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return result;
        }
    }
}
