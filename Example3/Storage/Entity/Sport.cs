using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ООP_Laba4.Storage.Entity
{
    [Table("Sport")]
    public class Sport
    {
        [Key]
        [Required]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("kind")]
        public string Kind { get; set; }

        [Required]
        [Column("EventId")]
        public Guid EventId { get; set; }
        [ForeignKey(nameof(EventId))]
        public Event Event { get; set; }


        public List<Participant> Participants { get; set; }

    }
}
