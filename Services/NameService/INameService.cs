using System.Collections.Generic;
using funAPI.Models;

namespace funAPI.Services.NameService
{
    public interface INameService
    {
        List<Name> GetList();
        List<Name> BookAName(Name newName);
    }
}