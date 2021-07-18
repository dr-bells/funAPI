using System;

namespace funAPI.Models
{
    public class Name
    {
        public int Id { get; set; }
        public string BookedName { get; set; } = "Anorld";
        public DateTime DateModified { get; set; } = DateTime.UtcNow;
    }
}