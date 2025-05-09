using HotelDataAccessLayer.Abstract;
using HotelDataAccessLayer.Concrate;
using HotelDataAccessLayer.Repositories;
using HotelEntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDataAccessLayer.EntityFramework
{
    public class EfReservationDal : GenericRepository<Reservation>, IReservationDal
    {
        public EfReservationDal(HotelContext context) : base(context)
        {
        }

        public List<Reservation> GetListReservationWithDetails()
        {
            using (var  c = new HotelContext())
            {
                return c.Reservations.Include(x => x.ReservationDetails).ThenInclude(x => x.RoomType).ToList();
            }
        }
    }
}
