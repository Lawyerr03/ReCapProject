using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityReporsitoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands 
                             on c.BrandId equals b.BrandId
                             join o in context.Colors
                             on c.ColorId equals o.ColorId
                             select new CarDetailDto { CarId = c.CarId, CarName = c.CarName, BrandName = b.BrandName, DailyPrice = c.DailyPrice, Description = c.Description, ModelYear = c.ModelYear,ColorName=o.ColorName };
            return result.ToList();
            }
        }
    }
}
