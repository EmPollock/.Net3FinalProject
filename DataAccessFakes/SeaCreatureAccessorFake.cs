using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessInterfaces;
using DataObjects;

namespace DataAccessFakes
{
    public class SeaCreatureAccessorFake : ISeaCreatureAccessor
    {
        private List<SeaCreature> fakeSeaCreatures = new List<SeaCreature>();
        private UserAccessorFake userAccessor = new UserAccessorFake();
        private Dictionary<String, List<String>> critterMonths = new Dictionary<String, List<String>>();
        private Dictionary<String, List<int>> critterHours = new Dictionary<string, List<int>>();

        public SeaCreatureAccessorFake()
        {
            fakeSeaCreatures.Add(new SeaCreature()
            {
                CritterId = "Kelp",
                RainNeeded = false,
                InMuseum = true,
                Price = 1000,
                CritterTypeId = "sea creature",
                Active = false,
                CatchDescription = "Go for a swim and find it.",
                UserCaughtDate = new Dictionary<int, DateTime>(),
                movementId = "Fast",
                ShadowSizeId = "Medium"
            });
            critterMonths.Add("Kelp", new List<string>() { "May", "June", "July", "Oct", "Nov" });
            critterHours.Add("Kelp", new List<int>() { 12, 13, 14, 15, 16, 17, 22, 23, 24 });
        }

        public int DeleteSeaCreature(SeaCreature seaCreature)
        {
            int result = 0;
            foreach (SeaCreature fakeSeaCreature in fakeSeaCreatures)
            {
                if (fakeSeaCreature.CritterId == seaCreature.CritterId)
                {
                    fakeSeaCreatures.Remove(fakeSeaCreature);
                    result = 1;
                }
            }

            return result;
        }

        public int InsertSeaCreature(SeaCreature seaCreature)
        {
            fakeSeaCreatures.Add(new SeaCreature() { CritterId = seaCreature.CritterId }
                );
            return 1;
        }

        public List<string> SelectAllMovements()
        {
            return new List<string>() { "Fast" };
        }

        public SeaCreature SelectSeaCreatureByCritterID(string critterID)
        {
            SeaCreature result = null;
            foreach (SeaCreature seaCreature in fakeSeaCreatures)
            {
                if (seaCreature.CritterId == critterID)
                {
                    result = seaCreature;
                }
            }
            if (result == null)
            {
                throw new ArgumentException("Sea Creature with given critter id not found.");
            }
            return result;
        }
    }
}
