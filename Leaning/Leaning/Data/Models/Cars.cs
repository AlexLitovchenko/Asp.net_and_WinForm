using System;
namespace Leaning.Data.Models
{
    public class Cars
    {
        public int id { get; set; }
        public string name { get; set; }
        public string shortDesc { get; set; }
        public string longDesc { get; set; }
        public string img { get; set; }
        public ushort price { get; set; }
        public bool isFavore { get; set; }
        public bool available { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

    }
}
