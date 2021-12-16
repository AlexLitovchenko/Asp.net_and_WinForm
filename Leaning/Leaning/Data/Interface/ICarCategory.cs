using System;
using System.Collections.Generic;
using Leaning.Data.Models;
namespace Leaning.Data.Interface
{
    public interface ICarCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
