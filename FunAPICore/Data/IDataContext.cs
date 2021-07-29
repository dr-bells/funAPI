using System;
using System.Threading.Tasks;
using funAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FunAPICore.Data
{
    public interface IDataContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbSet<Names> Names { get; set; }
        Task<int> SaveChangesAsync();

    }

}