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
        private readonly IRoomTypeDal _roomTypeDal;

        public RoomAvailabilityManager(IRoomAvailabilityDal roomAvailabilityDal, IRoomTypeDal roomTypeDal)
        {
            _roomAvailabilityDal = roomAvailabilityDal;
            _roomTypeDal = roomTypeDal;
        }

        public bool Exists(int roomTypeId, DateTime date)
        {
            var all = _roomAvailabilityDal.GetListAll();
            return all.Any(x => x.RoomTypeId == roomTypeId && x.Date.Date == date.Date);
        }

        public List<RoomType> GetAllRoomTypes()
        {
            return _roomTypeDal.GetListAll();
        }

        public List<RoomType> GetAvailableRoomTypes(DateTime checkIn, DateTime checkOut, int personCount)
        {
            return _roomAvailabilityDal.GetAvailableRoomTypes(checkIn, checkOut, personCount);
        }

        public List<RoomAvailability> GetByDateRange(DateTime startDate, DateTime endDate)
        {

            return _roomAvailabilityDal.GetByDateRange(startDate, endDate);

        }

        public RoomAvailability GetByRoomTypeAndDate(int roomTypeId, DateTime date)
        {
            //return _roomAvailabilityDal.GetListAll().FirstOrDefault(x=>x.RoomTypeId== roomTypeId && x.Date.Date == date.Date);
            return _roomAvailabilityDal.GetByRoomTypeAndDate(roomTypeId, date);
        }

        public List<RoomAvailability> GetByRoomTypeAndDateRange(int roomTypeId, DateTime startDate, DateTime endDate)
        {
            return _roomAvailabilityDal.GetByRoomTypeAndDateRange(roomTypeId, startDate, endDate);
        }

        public void TDelete(RoomAvailability entity)
        {
            _roomAvailabilityDal.Delete(entity);
        }

        public List<RoomAvailability> TGetAvailabilityBetweenDates(int roomTypeId, DateTime startDate, DateTime endDate)
        {
            return _roomAvailabilityDal.GetAvailabilityBetweenDates(roomTypeId, startDate, endDate);
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
