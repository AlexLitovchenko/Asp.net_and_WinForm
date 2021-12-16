using System;
using Microsoft.AspNetCore.Mvc;
using Leaning.Data.Interface;
using Leaning.ViewModels;
namespace Leaning.Controllers
{
    
        public class CarController : Controller
        {
            private readonly IAllCars _allCars;
            private readonly ICarCategory _carsCategory;

            public CarController(IAllCars _IAllCars, ICarCategory _ICarsCategory)
            {
                _allCars = _IAllCars;
                _carsCategory = _ICarsCategory;
            }

            public ViewResult List()
            {
                ViewBag.Title = "Page with Avto";
                CarsListViewModel carsListViewModel = new CarsListViewModel();
                carsListViewModel.getAllCars = _allCars.cars;
                carsListViewModel.currCategory = "Avto";
                return View(carsListViewModel);
            }

        
    }
    
}
