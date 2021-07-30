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
    public class Book_NameServiceTests
    {
        private readonly NameService _sut;
        private readonly IMapper _mapper = BookNameGetNameMapperHelper.GetMapper();
        private readonly DataContext _inMemoryDataContext = new DataContext(
            new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: "Test")
            .Options);

        public Book_NameServiceTests()
        {
            _sut = new NameService(_mapper, _inMemoryDataContext);
        }

        [Fact]
        public async void GetBookedList_ShouldReturnNull_IfEmpty()
        {
            //Arrange
            _inMemoryDataContext.Names.RemoveRange(_inMemoryDataContext.Names);
            var namesFromDB = _inMemoryDataContext.Names
            .Where(n => n.IsBooked)
            .Select(c => _mapper.Map<GetBookedNamesDTO>(c)).ToList();

            //Act
            var names = (await _sut.GetBookedList("admin")).Data;
            //Assert
            Assert.Equal(names, namesFromDB);
        }

        [Fact]
        public async void GetBookedList_ShouldReturnNull_IfUserIsNotAdmin()
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
            .Where(n => n.IsBooked)
            .Select(c => _mapper.Map<GetBookedNamesDTO>(c)).ToList();

            //Act
            var names = (await _sut.GetBookedList("admin")).Data;
            //Assert
            Assert.NotEqual(names, namesFromDB);
        }

        [Fact]
        public async void GetBookedList_ShouldReturnNull_IfThereAreNoBookedNames()
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
            .Where(n => n.IsBooked)
            .Select(c => _mapper.Map<GetBookedNamesDTO>(c)).ToList();

            //Act
            var names = (await _sut.GetBookedList("ad")).Data;
            //Assert
            Assert.Equal(names, namesFromDB);
        }

        [Fact]
        public async void GetBookedList_ShouldReturnListOfBookedNames_IfNotEmpty()
        {
            //Arrange
            Names newName = new Names
            {
                Name = "Elizabeth",
                DateGenerated = DateTime.UtcNow,
                IsBooked = true
            };
            _inMemoryDataContext.Add(newName);
            _inMemoryDataContext.SaveChanges();

            var namesFromDB = _inMemoryDataContext.Names
            .Where(n => n.IsBooked)
            .Select(c => _mapper.Map<GetBookedNamesDTO>(c)).ToList();

            //Act
            var names = (await _sut.GetBookedList("Admin")).Data;

            //Assert
            Assert.Equal(names.Count, namesFromDB.Count);
        }

        [Fact]
        public async void BookAName_ShouldReturnNull_IfNameIsBooked()
        {
            //Arrange
            int nameId = 1;
            Names newName = new Names
            {
                Id = 1,
                Name = "Elizabeth",
                DateGenerated = DateTime.UtcNow,
                IsBooked = true
            };
            _inMemoryDataContext.Add(newName);
            _inMemoryDataContext.SaveChanges();

            //Act
            var names = (await _sut.BookAName(nameId)).Data;

            var namesFromDB = _inMemoryDataContext.Names
           .Where(n => n.Id == nameId)
           .Select(c => _mapper.Map<GetBookedNamesDTO>(c)).ToList();

            //Assert
            Assert.NotStrictEqual(names, namesFromDB);
        }

        [Fact]
        public async void BookAName_ShouldReturnNull_IfNameIdDoesNotExist()
        {
            //Arrange
            int nameId = 2;
            Names newName = new Names
            {
                Id = 1,
                Name = "Elizabeth",
                DateGenerated = DateTime.UtcNow,
                IsBooked = true
            };
            _inMemoryDataContext.Add(newName);
            _inMemoryDataContext.SaveChanges();

            //Act
            var names = (await _sut.BookAName(nameId)).Data;

            var namesFromDB = _inMemoryDataContext.Names
           .Where(n => n.Id == nameId)
           .Select(c => _mapper.Map<GetBookedNamesDTO>(c)).ToList();

            //Assert
            Assert.NotStrictEqual(names, namesFromDB);
        }
    }
}