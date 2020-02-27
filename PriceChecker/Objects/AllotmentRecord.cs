using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceChecker.Objects
{
    public class AllotmentRecord
    {
        public string RoomName { get; set; }
        public string DateString { get; set; }
        public string AllotmentString { get; set; }
        public string CloseoutString { get; set; }
       
        public DateTime Date
        {
            get
            {
                return DateTime.ParseExact(DateString, new string[] { "MM/dd/yyyy", "M/dd/yyyy","MM/d/yyyy","M/d/yyyy" }, 
                    System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None);
            }
        }
        public int Allotment
        {     
            get
            {
                if(!string.IsNullOrEmpty(CloseoutString) && CloseoutString.Equals("checked",StringComparison.OrdinalIgnoreCase))
                {
                    return 0;
                }               
                return int.Parse(AllotmentString);
            }
        }
    }
}
