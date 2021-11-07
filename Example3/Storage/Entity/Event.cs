using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ООP_Laba4.Storage.Entity
{
    [Table("Event")]
    public class Event
    {
        [Key]
        [Required]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("Date", TypeName = "date")]
        public DateTime Date { get; set; }

        [Required]
        [Column("Name")]
        public string Name { get; set; }

        public List<Sport> Sports { get; set; }
    }
}
