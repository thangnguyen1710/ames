using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace New1.Models
{
    public class CreateWeek
    {
        public int CityId { get; set; }
        public  int Week { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
     
    }
}