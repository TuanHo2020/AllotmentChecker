using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceChecker.Models
{
    public class HotelRepository
    {
        PriceCheckerEntities entities;
        public HotelRepository()
        {
            entities = new Models.PriceCheckerEntities();
        }
        public HotelRepository(PriceCheckerEntities entities)
        {
            this.entities = entities;
        }
        public void Save()
        {
            this.entities.SaveChanges();
        }
        public IQueryable<Models.Hotel> GetQueryable()
        {
            return this.entities.Hotels;
        }
        public void Add(Models.Hotel h)
        {
            entities.Hotels.Add(h);
        }
        public void Delete(Models.Hotel h)
        {
            entities.Hotels.Remove(h);
        }
    }
}
