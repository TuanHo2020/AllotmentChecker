using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceChecker.Models
{
    public class ActionRepository
    {
        Models.PriceCheckerEntities entities;
        public ActionRepository()
        {
            entities = new Models.PriceCheckerEntities();
        }
        public ActionRepository(Models.PriceCheckerEntities entities)
        {
            this.entities = entities;
        }
        public void Save()
        {
            this.entities.SaveChanges();
        }
        public IQueryable<Models.WebAction> GetQueryable()
        {
            return this.entities.WebActions;
        }
        public void Add(Models.WebAction a)
        {
            this.entities.WebActions.Add(a);
        }
        public void Delete(Models.WebAction a)
        {
            this.entities.WebActions.Remove(a);
        }
    }
}
