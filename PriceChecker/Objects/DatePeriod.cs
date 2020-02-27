using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceChecker.Objects
{
    /// <summary>
    /// Represent a date period with start and end time
    /// </summary>
    public class DatePeriod
    {
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public DatePeriod()
        {

        }
    }
}
