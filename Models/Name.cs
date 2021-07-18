using System;

namespace funAPI.Models
{
    public class Name
    {
        public int Id { get; set; }
        public string BookedName { get; set; } = "Anorld";
        public string DateModified { get; set; } = DateTime.Now.ToShortDateString();
    }
}