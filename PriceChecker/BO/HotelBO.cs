using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceChecker.BO
{
    public class HotelBO
    {
        Models.HotelRepository hrep;
        public HotelBO()
        {
            hrep = new Models.HotelRepository();
        }
        public HotelBO(Models.PriceCheckerEntities entities)
        {
            hrep = new Models.HotelRepository(entities);
        }
        public void Save()
        {
            hrep.Save();
        }
        protected IQueryable<Models.Hotel> GetQueryable()
        {
            return hrep.GetQueryable();
        }
        public IQueryable<Models.Hotel> GetQueryable(bool? isDuplicated)
        {
            if (isDuplicated == null)
            {
                return GetQueryable();
            }
            else
            {
                return GetQueryable().Where(h => (bool)h.IsDuplicated);
            }
        }
        public Models.Hotel GetHotel(string hotelName)
        {
            return GetQueryable().SingleOrDefault(h => h.HotelName == hotelName);
        }
      
        public Models.Hotel GetHotel(int id)
        {
            return GetQueryable().SingleOrDefault(h => h.HotelId == id);
        }
        public void Delete(Models.Hotel h)
        {
            hrep.Delete(h);
            Save();
        }
        public void Add(Models.Hotel h)
        {
            hrep.Add(h);
            Save();
        }
    }
}
