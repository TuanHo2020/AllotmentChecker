using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceChecker.BO
{
    public class AllotmentRoomTypeBO
    {
        Models.AllotmentRoomTypeRepository brep;
        public AllotmentRoomTypeBO()
        {
            brep = new Models.AllotmentRoomTypeRepository();
        }
        public AllotmentRoomTypeBO(Models.PriceCheckerEntities entities)
        {
            brep = new Models.AllotmentRoomTypeRepository(entities);
        }
        public void Save()
        {
            brep.Save();
        }
        public IQueryable<Models.AllotmentRoomType> GetQueryable()
        {
            return brep.GetQueryable();
        }
        public IQueryable<Models.AllotmentRoomType> GetQueryable(int hotelId)
        {
            return GetQueryable().Where(x => x.HotelId == hotelId);
        }
        public void Add(Models.AllotmentRoomType bt)
        {
            brep.Add(bt);
            Save();
        }
        public void Delete(Models.AllotmentRoomType bt)
        {
            brep.Delete(bt);
            Save();
        }
        public Models.AllotmentRoomType GetRecord(int recordId)
        {
            return GetQueryable().SingleOrDefault(x => x.RecordId == recordId);
        }
        public Models.AllotmentRoomType GetRecord(int hotelId, string roomName)
        {
            return GetQueryable().SingleOrDefault(x =>x.HotelId == hotelId & x.RoomName == roomName);
        }
    }
}
