using System.Collections.Generic;
using funAPI.Models;

namespace funAPI.Services.NameService
{
    public class NameService : INameService
    {
        private static List<Name> names = new List<Name>
        {
            new Name(),
            new Name {Id = 1, BookedName = "Tsitsi"}
                };
        public List<Name> BookAName(Name newName)
        {
            names.Add(newName);
            return (names);
        }

        public List<Name> GetList()
        {
            return names;
        }
    }
}