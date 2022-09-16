using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace LogicLayer
{
    public interface ISeaCreatureManager
    {
        SeaCreature RetrieveSeaCreatureByCritterID(string critterID);
        List<String> RetrieveAllMovements();
        bool AddSeaCreature(SeaCreature seaCreature);
        bool RemoveSeaCreature(SeaCreature seaCreature);
    }
}
