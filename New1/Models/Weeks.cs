using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace New1.Models
{
    public class Weeks
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public string Name { get; set; }
        public  int Week { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}