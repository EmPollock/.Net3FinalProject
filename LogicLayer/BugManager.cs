using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using DataAccessInterfaces;
using DataAccessFakes;
using DataAccessLayer;

namespace LogicLayer
{
    public class BugManager : IBugManager
    {
        IBugAccessor _bugAccessor;
        public BugManager()
        {
            _bugAccessor = new BugAccessor();
        }

        public BugManager(IBugAccessor bugAccessor)
        {
            _bugAccessor = bugAccessor;
        }

        public bool AddBug(Bug bug)
        {
            bool result = false;

            try
            {
                result = 1 == _bugAccessor.InsertBug(bug);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public bool RemoveBug(Bug bug)
        {
            bool result = false;

            try
            {
                result = 1 == _bugAccessor.DeleteBug(bug);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public List<string> RetrieveAllBugFindingSpots()
        {
            List<string> spots = new List<string>();

            try
            {
                spots = _bugAccessor.SelectAllSpots();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return spots;
        }
        
        public BugVM RetrieveBugByCritterID(string critterID)
        {
            BugVM result = null;

            try
            {
                result = _bugAccessor.SelectBugByCritter(critterID);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
    }
}
