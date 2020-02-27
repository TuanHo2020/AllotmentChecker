using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceChecker.Models
{
    public class CityRepository
    {
        PriceCheckerEntities entities;
        public CityRepository(PriceCheckerEntities entities)
        {
            this.entities = entities;
        }
        public CityRepository()
        {
            entities = new Models.PriceCheckerEntities();
        }
        public void Add(Models.City c)
        {
            entities.Cities.Add(c);
        }
        public void Save()
        {
            entities.SaveChanges();
        }
        public void Delete(Models.City c)
        {
            entities.Cities.Remove(c);
        }
        public IQueryable<Models.City> GetQueryable()
        {
            return entities.Cities;
        }
    }
}
