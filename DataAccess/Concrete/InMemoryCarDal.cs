﻿using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>() {
                new Car {CarId =1,BrandId=1,ColorId="Siyah",DailyPrice=100,Description="OPEL",ModelYear=2020},
                new Car {CarId =2,BrandId=1,ColorId="Mavi",DailyPrice=100,Description="OPEL",ModelYear=2021},
                new Car {CarId =3,BrandId=2,ColorId="Beyaz",DailyPrice=100,Description="DACİA",ModelYear=2022},
                new Car {CarId =4,BrandId=2,ColorId="Eflatun",DailyPrice=100,Description="DACİA",ModelYear=2022},
                new Car {CarId =5,BrandId=3,ColorId="Siyah",DailyPrice=100,Description="CHEVROLET",ModelYear=2023}

            };

        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carDelete = _cars.SingleOrDefault(c=>c.CarId==c.CarId);
            _cars.Remove(carDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }
     
        public List<Car> GetAllById(int brandId)
        {
            return _cars.Where(c=> c.BrandId==brandId).ToList();
        }
     

        public void Uptade(Car car)
        {
            Car carUptade = _cars.SingleOrDefault(c => c.CarId == c.CarId);
            carUptade.CarId = car.CarId;
            carUptade.BrandId = car.BrandId;
            carUptade.ColorId = car.ColorId;
            carUptade.DailyPrice = car.DailyPrice;  
            carUptade.Description = car.Description;    
            carUptade.ModelYear = car.ModelYear;
        }
    }
}