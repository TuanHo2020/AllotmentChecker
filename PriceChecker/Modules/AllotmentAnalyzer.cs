using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace PriceChecker.Modules
{
    public class AllotmentAnalyzer
    {
        Objects.AllotmentXpathObject objXpath = null;
        bool _resetXpathOnload = false;
        public AllotmentAnalyzer(bool resetXpathOnload)
        {
            _resetXpathOnload = resetXpathOnload;
        }
        public List<Objects.AllotmentRecord> AnalyzeData(string html)
        {
            if (objXpath == null || _resetXpathOnload)
            {
                objXpath = Modules.XPathLoader.GetAllotmentXPath();
            }
           
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);
            var nn = doc.DocumentNode.SelectNodes(objXpath.RowXPath.XPath);
            if (nn == null)
            {
                return null;
            }
       
           // Console.WriteLine("xpath: " + objXpath.CloseOut.XPath);
            var nodes = nn.ToList();
            var arecords = new List<Objects.AllotmentRecord>();
            foreach (var r in nodes)
            {
                var arecord = new Objects.AllotmentRecord();
                arecord.AllotmentString = GetNodeInnerTextOrAttributeValue(r, objXpath.Allotment);
                arecord.CloseoutString = GetNodeInnerTextOrAttributeValue(r, objXpath.CloseOut);                
                arecord.DateString = GetNodeInnerTextOrAttributeValue(r, objXpath.DateXPath);
                arecord.RoomName = GetNodeInnerTextOrAttributeValue(r, objXpath.RoomName);
                arecords.Add(arecord);
            }
            return arecords;
        }
        string GetNodeInnerTextOrAttributeValue(HtmlNode parentNode, Objects.XPathItem item)
        {
            var nd = parentNode.SelectSingleNode(item.XPath);
            if (!string.IsNullOrEmpty(item.AttributeName))
            {
                if (!nd.Attributes.Any(x => x.Name.Equals(item.AttributeName, StringComparison.OrdinalIgnoreCase)))
                {
                    return null;
                }
                return nd.Attributes[item.AttributeName].Value;
            }
            else
            {
                return nd.InnerText;
            }
        }
    }
}
