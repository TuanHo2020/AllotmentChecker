using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceChecker.Models
{
    public class RoomTypeRepository
    {
        PriceCheckerEntities entities;
        public RoomTypeRepository()
        {
            entities = new Models.PriceCheckerEntities();
        }
        public RoomTypeRepository(PriceCheckerEntities entities)
        {
            this.entities = entities;
        }
        public IQueryable<Models.RoomType> GetQueryable()
        {
            return this.entities.RoomTypes;
        }
        public void Add(Models.RoomType r)
        {
            this.entities.RoomTypes.Add(r);
        }
        public void Delete(Models.RoomType r)
        {
            this.entities.RoomTypes.Remove(r);
        }
        public void Save()
        {
            this.entities.SaveChanges();
        }
    }
}
