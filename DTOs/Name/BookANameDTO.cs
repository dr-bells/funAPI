using System;

namespace funAPI.DTOs.Name
{
    public class BookANameDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateBooked { get; set; }
        public bool IsBooked { get; set; } = false;

    }
}