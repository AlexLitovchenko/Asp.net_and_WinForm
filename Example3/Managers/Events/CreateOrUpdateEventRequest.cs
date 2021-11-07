using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ООP_Laba4.Managers.Events
{
    public class CreateOrUpdateEventRequest
    {
        public DateTime date { get; private set; }
        public string Date
        {
            get
            {
                return date.ToShortDateString();
            }
            set
            {
                date = DateTime.Parse(value);
            }
        }
        public string Name { get; set; }
    }
}
