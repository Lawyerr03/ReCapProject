using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //BrandTest();
            //ColorTest();

            Customer customer = new Customer { CustomerId= 1,UserId=1,CompanyName="Trendyol"};
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(customer);
            foreach (var item in customerManager.GetAll().Data)
            {
                Console.WriteLine();
            }





        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            
            var result = colorManager.GetAll(); 

            if (result.Success== true)
            {
                foreach (var color in result.Data)
                {
                    Console.WriteLine(color.ColorName);
                }
            }            
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.GetAll();
            if (result.Success== true) 
            {
                foreach(var brand in result.Data)
            {
                    Console.WriteLine(brand.BrandName);
                }
            }
            
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();
            if (result.Success== true) 
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("Marka : " + car.BrandName + " " + car.Model);
                    Console.WriteLine("Renk : " + car.ColorName);
                    Console.WriteLine("Günlük Fiyat : " + car.DailyPrice);
                    Console.WriteLine("Açıklama : " + car.Description + "\n");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            
        }
    }
}