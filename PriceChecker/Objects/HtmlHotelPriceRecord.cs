using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace PriceChecker.Objects
{
    public class HtmlHotelPriceRecord
    {
        public string _HotelName { get; set; }
        public string _BasePrice { get; set; }
        public string _Address { get; set; }
        public string _RatingText { get; set; }
        public decimal GetRating()
        {
            var dcm = decimal.Parse(_RatingText);      
            return dcm;
        }
        protected static Regex rgNotNumber { get; set; }
        public int GetBasePrice()
        {
            if(string.IsNullOrEmpty(_BasePrice))
            {
                return 0;
            }
            var txt = rgNotNumber.Replace(_BasePrice, "");
            return int.Parse(txt);
        }
        public List<Objects.HtmlRoomPriceRecord> _PriceRecords {get;set;}
        public HtmlHotelPriceRecord()
        {
            _PriceRecords = new List<Objects.HtmlRoomPriceRecord>();
            if(rgNotNumber==null)
            {
                rgNotNumber = new Regex("[^0-9]", RegexOptions.IgnoreCase);
            }
        }
    }
}
