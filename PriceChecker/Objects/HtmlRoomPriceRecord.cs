using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace PriceChecker.Objects
{
    public class HtmlRoomPriceRecord
    {
        public string RoomName { get; set; }
        public string BoardType { get; set; }
        public string PriceText { get; set; }
        public string OriginalSupplierCode { get; set; }
        protected static Regex rgNotNumber { get; set; }
        public string GetTrueSupplierCode()
        {
            var cc = OriginalSupplierCode.ToCharArray();
            var bld = new StringBuilder();
            foreach(var c in cc)
            {
                if(!Char.IsDigit(c))
                {
                    bld.Append(c);
                }
                else
                {
                    break;
                }
            }
            return bld.ToString();
        }
        public int GetAdditionalPrice()
        {
            var txt = rgNotNumber.Replace(PriceText, "");
            return int.Parse(txt);
        }
        public HtmlRoomPriceRecord()
        {
            if (rgNotNumber == null)
            {
                rgNotNumber = new Regex("[^0-9]", RegexOptions.IgnoreCase);
            }

        }
    }
}
