using HotelBusinessLayer.Abstract;
using HotelDataAccessLayer.Abstract;
using HotelEntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBusinessLayer.Concrete
{
    public class RoomAvailabilityManager : IRoomAvailabilityService
    {
        private readonly IRoomAvailabilityDal _roomAvailabilityDal;

        public RoomAvailabilityManager(IRoomAvailabilityDal roomAvailabilityDal)
        {
            _roomAvailabilityDal = roomAvailabilityDal;
        }
        public List<RoomAvailability> GetByDateRange(DateTime startDate, DateTime endDate)
        {

            return _roomAvailabilityDal.GetByDateRange(startDate, endDate);

        }

        public RoomAvailability GetByRoomTypeAndDate(int roomTypeId, DateTime date)
        {
            return _roomAvailabilityDal.GetByRoomTypeAndDate(roomTypeId, date);
        }

        public void TDelete(RoomAvailability entity)
        {
            _roomAvailabilityDal.Delete(entity);
        }

        public RoomAvailability TGetById(int id)
        {
            return _roomAvailabilityDal.GetById(id);
        }

        public List<RoomAvailability> TGetListAll()
        {
            return _roomAvailabilityDal.GetListAll();
        }

        public void TInsert(RoomAvailability entity)
        {
            _roomAvailabilityDal.Insert(entity);
        }

        public void TUpdate(RoomAvailability entity)
        {
            _roomAvailabilityDal.Update(entity);
        }
    }
}
