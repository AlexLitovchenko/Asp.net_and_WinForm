using System;
using System.Collections.Generic;
using Leaning.Data.Models;
using Leaning.Data.Interface;
namespace Leaning.Data.Mocks
{
    public class MockCategory: ICarCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>
                {
                    new Category{CategoryName="Cars",desc="Ground"},
                    new Category{CategoryName="AirPlains", desc="Air" },
                    new Category{CategoryName="Water", desc="Water"}
                };
            }
        }
    }
}
