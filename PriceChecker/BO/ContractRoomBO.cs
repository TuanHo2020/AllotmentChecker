using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceChecker.BO
{
    public class ContractRoomBO
    {
        Models.ContractRoomRepository rrep;
        public ContractRoomBO()
        {
            rrep = new Models.ContractRoomRepository();
        }
        public ContractRoomBO(Models.PriceCheckerEntities entities)
        {
            rrep = new Models.ContractRoomRepository(entities);
        }
        public void Save()
        {
            rrep.Save();
        }
        public void Add(Models.ContractRoom r)
        {
            rrep.Add(r);
            Save();
        }
        public void Delete(Models.ContractRoom r)
        {  
            rrep.Delete(r);
            Save();
        }
        public IQueryable<Models.ContractRoom> GetQueryable()
        {
            return rrep.GetQueryable();
        }
        public IQueryable<Models.ContractRoom> GetQueryable(int hotelId)
        {
            return rrep.GetQueryable().Where(r=>r.HotelId==hotelId);
        }
        public Models.ContractRoom GetRoom(int id)
        {
            return GetQueryable().SingleOrDefault(r => r.RoomId == id);
        }
    }
}
