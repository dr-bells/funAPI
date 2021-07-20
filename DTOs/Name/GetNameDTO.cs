using System;

namespace funAPI.DTOs.Name
{
    public class GetNameDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Anorld";
        public DateTime DateGenerated { get; set; } = DateTime.UtcNow;
        public bool IsBooked { get; set; } = false;
    }
}