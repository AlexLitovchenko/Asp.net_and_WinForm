using System;
using System.Collections.Generic;
using Leaning.Data.Models;
using Leaning.Data.Interface;
using System.Linq;

namespace Leaning.Data.Mocks
{
    public class MockAllCars: IAllCars
    {
        private readonly ICarCategory _carsCategory = new MockCategory();
        public IEnumerable<Cars> cars
        {
            get
            {
                return new List<Cars> {
                    new Cars { name = "tesla", longDesc = "", shortDesc = "1st", price = 4500, img = "/img/tesla.jpg", isFavore = true, available = true, Category = _carsCategory.AllCategories.First() },
                    new Cars { name = "BMW", longDesc = "", shortDesc = "2nd", price = 2500, img = "/img/bmw.jpg", isFavore = true, available = true, Category = _carsCategory.AllCategories.First() },
                    new Cars { name = "Ford", longDesc = "", shortDesc = "3rd", price = 1500, img = "/img/ford.jpg", isFavore = true, available = true, Category = _carsCategory.AllCategories.First() },
                    new Cars { name = "Ferrari", longDesc = "", shortDesc = "4th", price = 4000, img = "/img/ferrari.jpeg", isFavore = true, available = true, Category = _carsCategory.AllCategories.First() },
                    new Cars { name = "Mersedes", longDesc = "", shortDesc = "5th", price = 5000, img = "/img/mers.jpg", isFavore = true, available = true, Category = _carsCategory.AllCategories.First() },
                };
            }
        }

        public IEnumerable<Cars> GetFavCars { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Cars GetObjectCar(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
