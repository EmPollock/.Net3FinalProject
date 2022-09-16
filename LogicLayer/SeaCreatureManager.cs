using DataAccessInterfaces;
using DataAccessLayer;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class SeaCreatureManager : ISeaCreatureManager
    {
        ISeaCreatureAccessor _seaCreatureAccessor;
        public SeaCreatureManager()
        {
            _seaCreatureAccessor = new SeaCreatureAccessor();
        }

        public SeaCreatureManager(ISeaCreatureAccessor seaCreatureAccessor)
        {
            _seaCreatureAccessor = seaCreatureAccessor;
        }

        public bool AddSeaCreature(SeaCreature seaCreature)
        {
            bool result = false;

            try
            {
                result = 1 == _seaCreatureAccessor.InsertSeaCreature(seaCreature);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public bool RemoveSeaCreature(SeaCreature seaCreature)
        {
            bool result = false;

            try
            {
                result = 1 == _seaCreatureAccessor.DeleteSeaCreature(seaCreature);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public List<string> RetrieveAllMovements()
        {
            List<string> movements = new List<string>();

            try
            {
                movements = _seaCreatureAccessor.SelectAllMovements();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return movements;
        }

        public SeaCreature RetrieveSeaCreatureByCritterID(string critterID)
        {
            SeaCreature result = null;

            try
            {
                result = _seaCreatureAccessor.SelectSeaCreatureByCritterID(critterID);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
    }
}
