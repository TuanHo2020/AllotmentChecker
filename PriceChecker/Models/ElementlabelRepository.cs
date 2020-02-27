using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceChecker.Models
{    
    public class ElementlabelRepository
    {
        public PriceCheckerEntities entities { get; set; }
        public ElementlabelRepository()
        {
            entities = new Models.PriceCheckerEntities();
        }
        public ElementlabelRepository(PriceCheckerEntities ent)
        {
            entities = ent;
        }
        public void Save()
        {
            entities.SaveChanges();
        }
        public IQueryable<ElementLabel> GetQueryable()
        {
            return entities.ElementLabels;
        }
        public void Add(ElementLabel lbl)
        {
            entities.ElementLabels.Add(lbl);
        }
        public void Delete(ElementLabel lbl)
        {
            entities.ElementLabels.Remove(lbl);
        }
    }
}
