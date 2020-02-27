using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceChecker.Models
{
    class ContractRoomRepository
    {
        PriceCheckerEntities entities;
        public ContractRoomRepository()
        {
            entities = new Models.PriceCheckerEntities();
        }
        public ContractRoomRepository(PriceCheckerEntities entities)
        {
            this.entities = entities;
        }
        public IQueryable<ContractRoom> GetQueryable()
        {
            return entities.ContractRooms;
        }
        public void Add(ContractRoom r)
        {
            entities.ContractRooms.Add(r);
        }
        public void Delete(ContractRoom r)
        {
            entities.ContractRooms.Remove(r);
        }
        public void Save()
        {
            entities.SaveChanges();
        }
    }
}
