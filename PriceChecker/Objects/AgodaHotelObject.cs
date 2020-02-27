using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceChecker.Objects
{
    public class AgodaHotelObject
    {
        public string HotelName { get; set; }
        public string Url { get; set; }
        public decimal StarRating { get; set; }
        public decimal ReviewScore { get; set; }
        public int Price { get; set; }
        public bool FreeCancellation { get; set; }
        public bool Breakfast { get; set; }
    }
}
