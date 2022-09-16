using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace DataAccessInterfaces
{
    public interface IBugAccessor
    {
        BugVM SelectBugByCritter(string critterID);
        List<String> SelectAllSpots();
        int InsertBug(Bug bug);
        int DeleteBug(Bug bug);
    }
}
