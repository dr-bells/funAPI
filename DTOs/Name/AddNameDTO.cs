using System;

namespace funAPI.DTOs.Name
{
    public class AddNameDTO
    {
        public string BookedName { get; set; } = "Anorld";
        public DateTime DateModified { get; set; } = DateTime.UtcNow;
    }
}