using System;

namespace funAPI.DTOs.Name
{
    public class GetNameDTO
    {
        public int Id { get; set; }
        public string BookedName { get; set; } = "Anorld";
        public DateTime DateModified { get; set; } = DateTime.UtcNow;
    }
}