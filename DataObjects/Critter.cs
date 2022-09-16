using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DataObjects
{
    public class Critter
    {
        [DisplayName("Critter Name")]
        public string CritterId { get; set; }
        [DisplayName("Needs Rain")]
        public bool RainNeeded { get; set; }
        [DisplayName("In Museum")]
        public bool InMuseum { get; set; }     
        public int Price { get; set; }
        [DisplayName("Critter Type")]
        public String CritterTypeId { get; set; }
        public bool Active { get; set; }
        [DisplayName("Put into the museum by")]
        public String MuseumBy { get; set; }
    }

    public class CritterVM : Critter
    {
        public List<String> CatchableMonths { get; set; }
        public List<int> CatchableHours { get; set; }
        [DisplayName("Catch Description")]
        public String CatchDescription { get; set; }
        [DisplayName("Seasonality")]
        public String CatchableMonthString { get; set; }
        [DisplayName("Active Hours")]
        public String CatchableHourString { get; set; }
        public Dictionary<int, DateTime> UserCaughtDate { get; set; }
        [DisplayName("Caught Dates")]
        public String UserCaughtDateString { get; set; }        
        public bool CaughtByCurrentUser { get; set; }
        public void UserCaughtDateAdd(int villagerID, DateTime caughtDate)
        {
            UserCaughtDate.Add(villagerID, caughtDate);
        }
    }
}
