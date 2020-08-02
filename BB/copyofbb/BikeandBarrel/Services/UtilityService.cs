using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeandBarrel.Services
{
    public class UtilityService
    {
        public DateTime StringTODateTime(string date,string time)
        {
            return Convert.ToDateTime(date + " " + time);
        }
    }
}