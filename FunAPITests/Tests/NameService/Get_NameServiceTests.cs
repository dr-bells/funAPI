using System;
using System.Linq;
using AutoMapper;
using funAPI.Data;
using funAPI.DTOs.Name;
using funAPI.Models;
using funAPI.Services.NameService;
using FunAPITests.Tests;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace funAPI.FunAPI.Tests
{
    public class Get_NameServiceTests
    {
        private readonly NameService _sut;
        private readonly IMapper _mapper = GetNameMapperHelper.GetMapper();
        private readonly DataContext _inMemoryDataContext = new DataContext(
            new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: "Test")
            .Options);

        public Get_NameServiceTests()
        {
            _sut = new NameService(_mapper, _inMemoryDataContext);
        }

        [Fact]
        public async void GetList_ShouldReturnNull_IfEmpty()
        {
            //Arrange

            var namesFromDB = _inMemoryDataContext.Names
            .Select(c => _mapper.Map<GetNameDTO>(c)).ToList();

            //Act
            var names = (await _sut.GetAll()).Data;
            //Assert
            Assert.Equal(names, namesFromDB);
        }

        [Fact]
        public async void GetListForToday_ShouldReturnNull_IfEmpty()
        {
            //Arrange
            _inMemoryDataContext.Names.RemoveRange(_inMemoryDataContext.Names);

            var namesFromDB = _inMemoryDataContext.Names
            .Where(n => n.DateGenerated.Date == DateTime.UtcNow.Date)
            .Select(c => _mapper.Map<GetNameDTO>(c)).ToList();

            //Act
            var names = (await _sut.GetListForToday()).Data;
            //Assert
            Assert.Equal(names, namesFromDB);
        }

        [Fact]
        public async void GetList_ShouldReturnListOfNames_IfNotEmpty()
        {
            //Arrange
            _inMemoryDataContext.Names.RemoveRange(_inMemoryDataContext.Names);

            Names newName = new Names
            {
                Name = "Elizabeth",
                DateGenerated = DateTime.UtcNow,
                IsBooked = false
            };
            _inMemoryDataContext.Add(newName);
            _inMemoryDataContext.SaveChanges();

            var namesFromDB = _inMemoryDataContext.Names
            .Select(c => _mapper.Map<GetNameDTO>(c)).ToList();

            //Act
            var names = (await _sut.GetAll()).Data;

            //Assert
            Assert.Equal(names.Count, namesFromDB.Count);
        }

        [Fact]
        public async void GetListForToday_ShouldReturnListOfNames_IfNotEmpty()
        {
            //Arrange
            _inMemoryDataContext.Names.RemoveRange(_inMemoryDataContext.Names);

            Names newName = new Names
            {
                Name = "Elizabeth",
                DateGenerated = DateTime.UtcNow,
                IsBooked = true
            };
            _inMemoryDataContext.Add(newName);
            _inMemoryDataContext.SaveChanges();

            var namesFromDB = _inMemoryDataContext.Names
            .Where(n => n.DateGenerated.Date == DateTime.UtcNow.Date)
            .Select(c => _mapper.Map<GetNameDTO>(c)).ToList();

            //Act
            var names = (await _sut.GetListForToday()).Data;

            //Assert
            Assert.Equal(names.Count, namesFromDB.Count);
        }
    }
}