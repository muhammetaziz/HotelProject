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
    public class HotelServManager : IHotelServService
    {
        private readonly IHotelServ _hotelServ;

        public HotelServManager(IHotelServ hotelServ)
        {
            _hotelServ = hotelServ;
        }

        public void TDelete(HotelServ entity)
        {
            _hotelServ.Delete(entity);
        }

        public HotelServ TGetById(int id)
        {
            return _hotelServ.GetById(id);
        }

        public List<HotelServ> TGetListAll()
        {
            return _hotelServ.GetListAll();
        }

        public void TInsert(HotelServ entity)
        {
            _hotelServ.Insert(entity);
        }

        public void TUpdate(HotelServ entity)
        {
            _hotelServ.Update(entity);
        }
    }
}
