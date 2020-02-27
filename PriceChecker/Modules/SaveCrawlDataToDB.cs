using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceChecker.Modules
{
    public class SaveCrawlDataToDB
    {
       
        public static void SaveAllotmentRecordsToDb(List<Objects.AllotmentRecord> records, int hotelId)
        {
            var rtbo = new BO.AllotmentRoomTypeBO();
            var arbo = new BO.AllotmentRecordBO();
            var rts = rtbo.GetQueryable(hotelId).ToList();
            /* What happen is there will be more than one line of the same record
             * due to different package plans (package rate and room rate), but 
             * allotment should be apply for both. So we group and select max */
            var grouped = records.GroupBy(r => new { r.RoomName, r.Date });
            var refined = grouped.Select(g => new { g.Key.RoomName, g.Key.Date, g.OrderByDescending(t=>t.Allotment).FirstOrDefault().Allotment }); 
            foreach(var x in refined)
            {
                var rt = rts.FirstOrDefault(r =>r.HotelId == hotelId && r.RoomName.Equals(x.RoomName, StringComparison.OrdinalIgnoreCase));
                if(rt == null)
                {
                    rt = new Models.AllotmentRoomType()
                    {
                        HotelId = hotelId,                     
                        DefaultAllotment = 1,
                        RoomName = x.RoomName
                    };
                    //all zero mean no allotment
                    rt.IgnoreThisRoomType = refined.Any(m => m.RoomName == x.RoomName && m.Allotment > 0);
                    if(rt.IgnoreThisRoomType)
                    {
                        rt.DefaultAllotment = 0;
                    }
                    rtbo.Add(rt);
                    rts = rtbo.GetQueryable(hotelId).ToList();
                }
                if(rt.IgnoreThisRoomType)
                {
                    continue;
                }
                if (x.Allotment < rt.DefaultAllotment)
                {
                    var dbRecord = arbo.GetQueryable().FirstOrDefault(t => t.AllotmentRoomTypeId == rt.RecordId
                         && t.AllotmentDate == x.Date);
                    if (dbRecord == null)
                    {
                        dbRecord = new Models.AllotmentRecord()
                        {
                            AllotmentDate = x.Date,
                            AllotmentRoomTypeId = rt.RecordId,
                            CurrentAllotment = x.Allotment,
                            Acknowledged = false
                        };
                        arbo.Add(dbRecord);
                    }
                    else
                    {
                        if(x.Allotment>dbRecord.CurrentAllotment)
                        {
                            dbRecord.CurrentAllotment = x.Allotment;
                            dbRecord.Acknowledged = false;
                            arbo.Save();
                        }
                    }
                }
            }
        }
    }
}
