using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceChecker.Models
{
    public class AllotmentRecordRepository
    {
        PriceCheckerEntities entities;
        public AllotmentRecordRepository()
        {
            entities = new Models.PriceCheckerEntities();
        }
        public AllotmentRecordRepository(PriceCheckerEntities ent)
        {
            entities = ent;
        }
        public IQueryable<AllotmentRecord> GetQueryable()
        {
            return entities.AllotmentRecords;
        }
        public void Save()
        {
            entities.SaveChanges();
        }
        public void Add(Models.AllotmentRecord r)
        {
            entities.AllotmentRecords.Add(r);
        }
        public void Delete(Models.AllotmentRecord r)
        {
            entities.AllotmentRecords.Remove(r);
        }
        public void ExecuteSql(string cmdText, object[] prms)
        {
            entities.Database.ExecuteSqlCommand(cmdText, prms);
        }
    }
}
