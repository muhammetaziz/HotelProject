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
    public class HomeManager : IHomeService
    {
        private readonly IHomeDal _homeDal;

        public HomeManager(IHomeDal homeDal)
        {
            _homeDal = homeDal;
        }

        public void TDelete(Home entity)
        {
            _homeDal.Delete(entity);
        }

        public Home TGetById(int id)
        {
            return _homeDal.GetById(id);
        }

        public List<Home> TGetListAll()
        {
            return _homeDal.GetListAll();
        }

        public void TInsert(Home entity)
        {
            _homeDal.Insert(entity);
        }

        public void TUpdate(Home entity)
        {
            _homeDal.Update(entity);
        }
    }
}
