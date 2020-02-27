using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceChecker.BO
{
    public class ActionBO
    {
        Models.ActionRepository arep;
        public ActionBO()
        {
            arep = new Models.ActionRepository();
        }
        public ActionBO(Models.PriceCheckerEntities entities)
        {
            arep = new Models.ActionRepository(entities);
        }
        public IQueryable<Models.WebAction> GetQueryable()
        {
            return arep.GetQueryable();
        }
      
        public Models.WebAction GetAction(int Id)
        {
            return GetQueryable().SingleOrDefault(a => a.ActionId == Id);
        }
      
        public void Save()
        {
            arep.Save();
        }
        public void Add(Models.WebAction a)
        {
            arep.Add(a);
            Save();
        }
        public void Delete(Models.WebAction a)
        {
            arep.Delete(a);
            Save();
        }
    }
}
