using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessInterfaces;
using DataObjects;

namespace DataAccessFakes
{
    public class FishAccessorFake : IFishAccessor
    {
        private List<FishVM> fakeFish = new List<FishVM>();
        private UserAccessorFake userAccessor = new UserAccessorFake();
        private Dictionary<String, List<String>> critterMonths = new Dictionary<String, List<String>>();
        private Dictionary<String, List<int>> critterHours = new Dictionary<string, List<int>>();

        public FishAccessorFake()
        {
            Dictionary<String, DateTime> tessCaught = new Dictionary<string, DateTime>();
            fakeFish.Add(new FishVM()
            {
                CritterId = "Big-Mouthed Bass",
                RainNeeded = false,
                InMuseum = true,
                Price = 500,
                CritterTypeId = "fish",
                Active = true,
                MuseumBy = "tessdata",
                CatchDescription = "Use a fishing rod or something idk",
                UserCaughtDate = new Dictionary<int, DateTime>(),
                LocationId = "River",
                LocationDescription = "The long water.",
                ShadowSizeId = "Large"
            });
            critterMonths.Add("Big-Mouthed Bass", new List<string>() { "Jan", "Feb", "Mar", "Nov", "Dec" });
            critterHours.Add("Big-Mouthed Bass", new List<int>() { 9, 10, 11, 12, 13, 14, 15, 16 });

            fakeFish.Add(new FishVM()
            {
                CritterId = "Guppy",
                RainNeeded = true,
                InMuseum = false,
                Price = 200,
                CritterTypeId = "fish",
                Active = true,
                CatchDescription = "Use a fishing rod or something idk",
                UserCaughtDate = new Dictionary<int, DateTime>(),
                LocationId = "Pond",
                LocationDescription = "The small water.",
                ShadowSizeId = "Tiny"
            });
            critterMonths.Add("Guppy", new List<string>() { "May", "June", "July", "Oct", "Nov" });
            critterHours.Add("Guppy", new List<int>() { 12, 13, 14, 15, 16, 17, 22, 23, 24 });
        }

        public int DeleteFish(Fish fish)
        {
            int result = 0;
            foreach (FishVM fishFake in fakeFish)
            {
                if (fishFake.CritterId == fish.CritterId)
                {
                    fakeFish.Remove(fishFake);
                    result = 1;
                }
            }

            return result;
        }

        public int InsertFish(Fish fish)
        {
            fakeFish.Add(new FishVM() { CritterId = fish.CritterId }
                );
            return 1;
        }

        public List<string> SelectAllLocations()
        {
            return new List<string>() { "River", "Pond" };
        }

        public List<string> SelectAllShadowSizes()
        {
            return new List<string>() { "Large", "Tiny" };
        }

        public FishVM SelectFishByCritterID(string critterID)
        {
            FishVM result = null;
            foreach(FishVM fish in fakeFish){
                if(fish.CritterId.Equals(critterID))
                {
                    result = fish;
                }
            }
            if(result == null)
            {
                throw new ArgumentException("Fish with given critter id not found.");
            }
            return result;
        }
    }
}
