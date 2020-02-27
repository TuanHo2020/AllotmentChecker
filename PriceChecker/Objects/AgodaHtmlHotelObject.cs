using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceChecker.Objects
{
    public class AgodaHtmlHotelObject
    {
        public string PriceText { get; set; }
        public string HotelName { get; set; }
        public string Url { get; set; }
        public string StarRating { get; set; }
        public string ReviewScore { get; set; }
        public bool HasFreeCancellation { get; set; }
        public bool Breakfast { get; set; }
    }
}
