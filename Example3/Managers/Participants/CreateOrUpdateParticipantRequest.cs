using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ООP_Laba4.Managers.Participants
{
    public class CreateOrUpdateParticipantRequest
    {
        public string SurName { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime MyDay { get; private set; }
        public string Birthday
        {
            get
            {
                return MyDay.ToShortDateString();
            }
            set
            {
                MyDay = DateTime.Parse(value);
            }
        }
    }
}
