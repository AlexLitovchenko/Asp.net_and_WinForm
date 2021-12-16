using System;
using System.Collections.Generic;
namespace Leaning.Data.Models
{
    public class Category
    {
        public int id { get; set; }
        public string CategoryName { get; set; }
        public string desc { get; set; }
        public List<Cars> cars { get; set; }

    }
}
