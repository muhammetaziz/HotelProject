using HotelDataAccessLayer.Repositories;
using HotelEntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDataAccessLayer.Abstract
{
    public interface IPricePeriodDal:IGenericDal<RoomTypePricePeriod>
    {
        List<RoomTypePricePeriod> GetSpecialPriceListWithRoomType();
        Task<bool> IsOverlappingAsync(int roomTypeId, DateTime startDate, DateTime endDate);

        Task InsertAsync(RoomTypePricePeriod entity);
    }
}
