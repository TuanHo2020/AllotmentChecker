using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceChecker.BO
{
    public class CityBO
    {
        Models.CityRepository crep;
        public CityBO()
        {
            crep = new Models.CityRepository();
        }
        public CityBO(Models.PriceCheckerEntities entities)
        {
            crep = new Models.CityRepository(entities);
        }
        public IQueryable<Models.City> GetQueryable()
        {
            return crep.GetQueryable();
        }
        public void Save()
        {
            crep.Save();
        }
        public void Delete(Models.City c)
        {
            crep.Delete(c);
            Save();
        }
        public void Add(Models.City c)
        {
            crep.Add(c);
            Save();
        }
        public Models.City GetCity(int id)
        {
            return GetQueryable().SingleOrDefault(c => c.CityId == id);
        }
        public Models.City GetCity(string cityCode)
        {
            return GetQueryable().FirstOrDefault(c => c.CityCode == cityCode);
        }
    }
}
