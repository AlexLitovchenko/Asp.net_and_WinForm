using System;
using Leaning.Data.Models;
using System.Collections.Generic;

namespace Leaning.Data.Interface
{
    public interface IAllCars
    {
        IEnumerable<Cars> cars { get; }
        IEnumerable<Cars> GetFavCars { get; set; }
        Cars GetObjectCar(int carId);
    }
}
