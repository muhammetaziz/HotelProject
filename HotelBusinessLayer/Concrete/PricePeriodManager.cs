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
    public class PricePeriodManager : IPricePeriodService
    {
        private readonly IPricePeriodDal _pricePeriodDal;

        public PricePeriodManager(IPricePeriodDal pricePeriodDal)
        {
            _pricePeriodDal = pricePeriodDal;
        }

        public List<RoomTypePricePeriod> TGetSpecialPriceListWithRoomType()
        {
            return _pricePeriodDal.GetSpecialPriceListWithRoomType();
        }

        public void TDelete(RoomTypePricePeriod entity)
        {
            _pricePeriodDal.Delete(entity);

        }

        public RoomTypePricePeriod TGetById(int id)
        {
            return _pricePeriodDal.GetById(id);
        }

        public List<RoomTypePricePeriod> TGetListAll()
        {
            return _pricePeriodDal.GetListAll();
        }

        public void TInsert(RoomTypePricePeriod entity)
        {
             _pricePeriodDal.Insert(entity);
        }

        public void TUpdate(RoomTypePricePeriod entity)
        {
            _pricePeriodDal.Update(entity);
        }

        public async Task<bool> IsOverlappingAsync(int roomTypeId, DateTime startDate, DateTime endDate)
        {
            return await _pricePeriodDal.IsOverlappingAsync(roomTypeId, startDate, endDate);
        }
        

    }
}
