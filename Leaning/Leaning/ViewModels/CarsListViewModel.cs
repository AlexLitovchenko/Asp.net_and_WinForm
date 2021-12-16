using System;
using System.Collections.Generic;
using Leaning.Data.Models;
namespace Leaning.ViewModels
{
    public class CarsListViewModel
    {
        
            public IEnumerable<Cars> getAllCars { get; set; }
            public string currCategory { get; set; }
        
    }
}
