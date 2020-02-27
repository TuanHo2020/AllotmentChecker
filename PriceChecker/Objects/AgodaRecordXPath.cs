using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceChecker.Objects
{
    public class AgodaRecordXPath
    {
        public XPathItem HotelItemXpath { get; set; }
        public XPathItem PriceXpath { get; set; }
        public XPathItem NameXpath { get; set; }
        public XPathItem UrlXpath { get; set; }
        public XPathItem StarRating { get; set; }
        public XPathItem ReviewScore { get; set; }
        public XPathItem FreeCancellation { get; set; }
        public XPathItem Breakfast { get; set; }
    }
}
