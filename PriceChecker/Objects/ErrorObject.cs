using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PriceChecker.Objects
{
    public class ErrorObject
    {
        public string ActionName { get; set; }
        public Models.ElementLabel Label { get; set; }
        protected DateTime _timeofOccur;
        public DateTime TimeofOccur { get { return _timeofOccur; } }
        public ErrorObject()
        {
            _timeofOccur = DateTime.UtcNow;
        }
    }
}
