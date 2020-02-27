using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceChecker.Models
{
    public class AllotmentRoomTypeRepository
    {
        PriceCheckerEntities entities;
        public AllotmentRoomTypeRepository()
        {
            entities = new Models.PriceCheckerEntities();
        }
        public AllotmentRoomTypeRepository(Models.PriceCheckerEntities entities)
        {
            this.entities = entities;
        }
        public void Save()
        {
            this.entities.SaveChanges();
        }
        public void Delete(Models.AllotmentRoomType bt)
        {
            entities.AllotmentRoomTypes.Remove(bt);
        }
        public void Add(AllotmentRoomType bt)
        {
            entities.AllotmentRoomTypes.Add(bt);
        }
        public IQueryable<Models.AllotmentRoomType> GetQueryable()
        {
            return entities.AllotmentRoomTypes;
        }
    }
}
