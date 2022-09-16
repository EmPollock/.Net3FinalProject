using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace LogicLayer
{
    public interface IBugManager
    {
        List<String> RetrieveAllBugFindingSpots();
        bool AddBug(Bug bug);
        bool RemoveBug(Bug bug);
        BugVM RetrieveBugByCritterID(string CritterID);
    }
}
