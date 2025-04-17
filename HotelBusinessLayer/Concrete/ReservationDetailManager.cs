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
    public class ReservationDetailManager : IReservationDetailService
    {
        private readonly IReservationDetailDal _reservationDetailDal;

        public ReservationDetailManager(IReservationDetailDal reservationDetailDal)
        {
            _reservationDetailDal = reservationDetailDal;
        }

        public void TDelete(ReservationDetail entity)
        {
            _reservationDetailDal.Delete(entity);
        }

        public ReservationDetail TGetById(int id)
        {
            return _reservationDetailDal.GetById(id);
        }

        public List<ReservationDetail> TGetListAll()
        {
            return _reservationDetailDal.GetListAll();
        }

        public void TInsert(ReservationDetail entity)
        {
            _reservationDetailDal.Insert(entity);
        }

        public void TUpdate(ReservationDetail entity)
        {
            _reservationDetailDal.Update(entity);
        }
    }
}
