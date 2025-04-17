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
    public class RoomTypeManager : IRoomTypeService
    {
        private readonly IRoomTypeDal _roomTypeDal;

        public RoomTypeManager(IRoomTypeDal roomTypeDal)
        {
            _roomTypeDal = roomTypeDal;
        }

        public void TDelete(RoomType entity)
        {
            _roomTypeDal.Delete(entity);
        }

        public RoomType TGetById(int id)
        {
            return _roomTypeDal.GetById(id);
        }

        public List<RoomType> TGetListAll()
        {
            return _roomTypeDal.GetListAll();
        }

        public void TInsert(RoomType entity)
        {
            _roomTypeDal.Insert(entity);
        }

        public void TUpdate(RoomType entity)
        {
            _roomTypeDal.Update(entity);
        }
    }
}
