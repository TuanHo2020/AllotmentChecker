using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PriceChecker.Modules
{
    public class XPathLoader
    {
        
        public static Objects.AllotmentXpathObject GetAllotmentXPath()
        {
            var elbo = new BO.ElementLabelBO();
            var px = new Objects.AllotmentXpathObject();
            var elmAllotment = elbo.GetLabel(45);
            var elmDate = elbo.GetLabel(43);
            var elmCloseOut = elbo.GetLabel(46);
            var elmRoomName = elbo.GetLabel(44);
            var elmRowXPath = elbo.GetLabel(42);
            px.Allotment = new Objects.XPathItem { AttributeName = "value", XPath = elmAllotment.XPath };
            px.CloseOut = new Objects.XPathItem { AttributeName = "checked", XPath = elmCloseOut.XPath };
            px.DateXPath = new Objects.XPathItem { AttributeName = "value", XPath = elmDate.XPath };
            px.RoomName = new Objects.XPathItem { AttributeName = "value", XPath = elmRoomName.XPath };
            px.RowXPath = new Objects.XPathItem { AttributeName = null, XPath = elmRowXPath.XPath };
            return px;
           
        }
        static Objects.XPathItem LoadXPathItem(XDocument doc, string tagName)
        {
            var nd = doc.Root.Element(tagName);
            var item = new Objects.XPathItem();
            item.XPath = nd.Value;
            if(nd.Attribute("attribute")!=null)
            {
                item.AttributeName = nd.Attribute("attribute").Value;
            }
            return item;
        }
    }
}
