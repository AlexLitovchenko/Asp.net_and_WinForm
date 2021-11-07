using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ООP_Laba4.Storage.Entity
{
    [Table("Participant")]
    public class Participant
    {
        [Key]
        [Required]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("SurName")]
        public string SurName { get; set; }

        [Required]
        [Column("Name")]
        public string Name { get; set; }

        [Required]
        [Column("LastName")]
        public string LastName { get; set; }

        [Required]
        [Column("Birthday", TypeName = "date")]
        public DateTime Birthday { get; set; }

        [Required]
        [Column("SportId")]
        public Guid SportId { get; set; }
    }
}
