using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace funAPI.Models
{
    public class Name
    {
        public int Id { get; set; }

        [Required]
        [Column("Name")]
        [MaxLength(50)]
        public string BookedName { get; set; }
        public DateTime DateGenerated { get; set; } = DateTime.UtcNow;
        public DateTime DateBooked { get; set; } = DateTime.UtcNow;
        public bool IsBooked { get; set; } = false;
    }
}