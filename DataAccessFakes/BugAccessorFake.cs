using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using DataAccessInterfaces;

namespace DataAccessFakes
{
    public class BugAccessorFake : IBugAccessor
    {
        private List<BugVM> fakeBugs = new List<BugVM>();
        private UserAccessorFake userAccessor = new UserAccessorFake();
        private Dictionary<String, List<String>> critterMonths = new Dictionary<String, List<String>>();
        private Dictionary<String, List<int>> critterHours = new Dictionary<string, List<int>>();

        public BugAccessorFake()
        {
            fakeBugs.Add(new BugVM()
            {
                CritterId = "French Fly",
                RainNeeded = false,
                InMuseum = true,
                Price = 2000,
                CritterTypeId = "bug",
                Active = true,
                CatchDescription = "Fight it with a net",
                UserCaughtDate = new Dictionary<int, DateTime>(),
                SpotId = "Blue Flowers",
                SpotDescription = "On any type of flowers that are blue.",
                CatchableMonths = new List<string>() { "June", "July", "Aug" },
                CatchableHours = new List<int>() { 12, 13, 14, 15, 16, 17, 18 }
            });
        }

        public int DeleteBug(Bug bug)
        {
            int result = 0;
            foreach (BugVM fakeBug in fakeBugs)
            {
                if (fakeBug.CritterId == bug.CritterId)
                {
                    fakeBugs.Remove(fakeBug);
                    result = 1;
                }
            }

            return result;
        }

        public int InsertBug(Bug bug)
        {
            fakeBugs.Add(new BugVM() { CritterId = bug.CritterId }
                );
            return 1;
        }

        public List<string> SelectAllSpots()
        {
            return new List<string>() { "Blue Flowers" };
        }

        public BugVM SelectBugByCritter(string critterID)
        {
            BugVM result = null;
            foreach(BugVM bug in fakeBugs)
            {
                if(bug.CritterId == critterID)
                {
                    result = bug;
                }
            }
            if (result == null)
            {
                throw new ArgumentException("Bug with given critter id not found.");
            }
            return result;
        }
    }
}
