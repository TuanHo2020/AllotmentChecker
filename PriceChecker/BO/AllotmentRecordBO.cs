using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceChecker.BO
{
    public class AllotmentRecordBO
    {
        Models.AllotmentRecordRepository rrep;
        public AllotmentRecordBO()
        {
            rrep = new Models.AllotmentRecordRepository();
        }
        public AllotmentRecordBO(Models.PriceCheckerEntities entities)
        {
            rrep = new Models.AllotmentRecordRepository(entities);
        }
        public void Save()
        {
            rrep.Save();
        }
        public IQueryable<Models.AllotmentRecord> GetQueryable()
        {
            return rrep.GetQueryable();
        }
        public IQueryable<Models.AllotmentRecord> GetQueryable(int roomTypeId, bool? acknowledged)
        {
            var qq = GetQueryable().Where(r => r.AllotmentRoomTypeId == roomTypeId);
            if(acknowledged!=null)
            {
                qq = qq.Where(r => r.Acknowledged == acknowledged);
            }
            return qq;
        }
        public Models.AllotmentRecord GetRecord(DateTime dt, int roomTypeId)
        {
            return GetQueryable().FirstOrDefault(x => x.AllotmentDate == dt
            && x.AllotmentRoomTypeId == roomTypeId);
        }
        public void Add(Models.AllotmentRecord r)
        {
            rrep.Add(r);
            Save();
        }
        public void Delete(Models.AllotmentRecord r)
        {
            rrep.Delete(r);
            Save();
        }
        public void ExecuteSql(string cmdText, object[] prms)
        {
            rrep.ExecuteSql(cmdText, prms);
        }
        public Models.AllotmentRecord GetRecord(int id)
        {
            return GetQueryable().SingleOrDefault(r => r.RecordId == id);
        }
    }
}
