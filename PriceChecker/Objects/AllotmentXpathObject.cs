using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceChecker.Objects
{
    public class AllotmentXpathObject
    {
        public XPathItem RowXPath { get; set; }
        public XPathItem DateXPath { get; set; }
        public XPathItem RoomName { get; set; }
        public XPathItem Allotment { get; set; }
        public XPathItem CloseOut { get; set; }
    }
}
