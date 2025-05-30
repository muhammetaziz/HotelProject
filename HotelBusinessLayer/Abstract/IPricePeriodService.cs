using HotelBusinessLayer.Abstract;
using HotelEntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBusinessLayer.Abstract
{
    public interface IPricePeriodService:IGenericService<RoomTypePricePeriod>
    {
        List<RoomTypePricePeriod> TGetSpecialPriceListWithRoomType();
        Task<bool> IsOverlappingAsync(int roomTypeId, DateTime startDate, DateTime endDate);
        


    }
}


