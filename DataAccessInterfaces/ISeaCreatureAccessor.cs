using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace DataAccessInterfaces
{
    public interface ISeaCreatureAccessor
    {
        SeaCreature SelectSeaCreatureByCritterID(string critterID);
        List<String> SelectAllMovements();
        int InsertSeaCreature(SeaCreature seaCreature);
        int DeleteSeaCreature(SeaCreature seaCreature);
    }
}
