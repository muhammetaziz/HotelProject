﻿using HotelEntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDataAccessLayer.Abstract
{
    public interface IReservationDal:IGenericDal<Reservation>
    {
         List<Reservation> GetListReservationWithDetails();
    }
}
