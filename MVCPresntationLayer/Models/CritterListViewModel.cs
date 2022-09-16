using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPresntationLayer.Models
{
    public class CritterListViewModel
    {
        public IEnumerable<CritterVM> Critters { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public bool NotCaughtByUser { get; set; } = false;
        public bool NotInMuseum { get; set; } = false;
    }
}