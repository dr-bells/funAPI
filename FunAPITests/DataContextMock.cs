using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using funAPI.Data;
using funAPI.DTOs.Name;
using funAPI.Models;
using FunAPICore.Data;
using Microsoft.EntityFrameworkCore;

namespace FunAPITests
{
    public class DataContextMock : DbContext
    {
        public DataContextMock(DbContextOptions<DataContextMock> options) : base(options) { }
        public DbSet<Names> MockedNames { get; set; }
    }
}