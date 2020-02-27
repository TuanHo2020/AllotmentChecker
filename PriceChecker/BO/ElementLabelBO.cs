using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceChecker.BO
{
    public class ElementLabelBO
    {
        Models.ElementlabelRepository elmrep;
        public ElementLabelBO()
        {
            elmrep = new Models.ElementlabelRepository();
        }
        public ElementLabelBO (Models.PriceCheckerEntities ent)
        {
            elmrep = new Models.ElementlabelRepository(ent);
        }
        public void Save()
        {
            elmrep.Save();
        }
        public IQueryable<Models.ElementLabel> GetQueryable()
        {
            return elmrep.GetQueryable();
        }
        public IQueryable<Models.ElementLabel> GetQueryable(int actionId)
        {
            return elmrep.GetQueryable().Where(l=>l.ActionId == actionId);
        }
        public Models.ElementLabel GetLabel(int id)
        {
            return GetQueryable().FirstOrDefault(l => l.LabelId == id);
        }
        public Models.ElementLabel GetLabelByOrder(int actionId, int order)
        {
            return GetQueryable().FirstOrDefault(l => l.ActionId == actionId && l.LabelOrder == order);
        }
        void SwapOrder(Models.ElementLabel lbl1, Models.ElementLabel lbl2)
        {
            int order1 = lbl1.LabelOrder;
            int order2 = lbl2.LabelOrder;
            lbl2.LabelOrder = order1;
            lbl1.LabelOrder = order2;
            Console.WriteLine(lbl1.LabelOrder +", " + lbl2.LabelOrder);
            
            Save();
        }
        public void MoveUp(Models.ElementLabel lbl)
        {
            var order = lbl.LabelOrder;
            if(order>0)
            {
                var upperOrder = order - 1;
                var upperLabel = GetLabelByOrder(lbl.ActionId, upperOrder);
                Console.WriteLine(upperLabel.LabelName);
                SwapOrder(lbl, upperLabel);
            }
        }
        public void MoveDown(Models.ElementLabel lbl)
        {
            var order = lbl.LabelOrder;
            var lowerOrder = order + 1;
            var lowerLabel = GetLabelByOrder(lbl.ActionId, lowerOrder);
            if (lowerLabel!=null)
            {
                SwapOrder(lbl, lowerLabel);
            }
        }
        public void Delete(Models.ElementLabel lbl)
        {            
            string cmdText = @"UPDATE ElementLabels SET LabelOrder=LabelOrder-1 WHERE ActionId={0}
AND LabelOrder>{1}";
            elmrep.entities.Database.ExecuteSqlCommand(cmdText, new object[] { lbl.ActionId, lbl.LabelOrder });
            elmrep.Delete(lbl);
            Save();
        }
        public void Add(Models.ElementLabel lbl)
        {
            int count = GetQueryable(lbl.ActionId).Count();
            lbl.LabelOrder = count;
            elmrep.Add(lbl);
            Save();
        }
    }
}
