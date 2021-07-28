using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace funAPI.Models
{
    public class Names
    {
        public int Id { get; set; }

        [Required]
        [Column("Name")]
        [MaxLength(50)]
        public string Name { get; set; }
        public DateTime DateGenerated { get; set; } = DateTime.UtcNow;
        public DateTime DateBooked { get; set; } = DateTime.UtcNow;
        public bool IsBooked { get; set; } = false;
    }
}