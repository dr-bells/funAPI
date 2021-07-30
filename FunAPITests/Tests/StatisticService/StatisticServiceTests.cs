using System;
using System.Linq;
using AutoMapper;
using funAPI.Data;
using funAPI.DTOs.Name;
using funAPI.Models;
using funAPI.Services.StatisticsService;
using FunAPITests.Tests;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace funAPI.FunAPI.Tests
{
    public class StatisticServiceTests
    {
        private readonly StatisticsService _sut;
        private readonly IMapper _mapper = GetNameMapperHelper.GetMapper();
        private readonly DataContext _inMemoryDataContext = new DataContext(
            new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: "Test")
            .Options);

        public StatisticServiceTests()
        {
            _sut = new StatisticsService(_mapper, _inMemoryDataContext);
        }

        [Fact]
        public async void AverageNameLength_ShouldReturnNull_IfEmpty()
        {
            //Arrange
            double namesFromDBAverage = 0;

            //Act
            double namesAverage = (await _sut.AverageNameLength()).Data;

            //Assert
            Assert.Equal(namesAverage, namesFromDBAverage);
        }

        [Fact]
        public async void AverageNameLength_ShouldReturnAverage_IfNotEmpty()
        {
            //Arrange
            double totalLengthOfGeneratedNames = 0;

            Names firstName = new Names
            {
                Name = "Anorld",
                DateGenerated = DateTime.UtcNow,
                IsBooked = true
            };
            _inMemoryDataContext.Add(firstName);

            Names secondName = new Names
            {
                Name = "Panashe",
                DateGenerated = DateTime.UtcNow,
                IsBooked = false
            };
            _inMemoryDataContext.Add(secondName);

            _inMemoryDataContext.SaveChanges();
            double namesFromDBCount = _inMemoryDataContext.Names.Count();

            //Act
            double averageNameLength = (await _sut.AverageNameLength()).Data;
            foreach (var name in _inMemoryDataContext.Names)
            {
                totalLengthOfGeneratedNames += name.Name.Length;
            }
            double namesFromDBAverageLength = (totalLengthOfGeneratedNames) / namesFromDBCount;

            //Assert
            Assert.Equal(averageNameLength, namesFromDBAverageLength);
        }

        [Fact]
        public async void DailyGeneratedNames_ShouldReturnNull_IfEmpty()
        {
            //Arrange
            var dbNames = await _inMemoryDataContext.Names
            .Where(n => n.DateGenerated.Date == DateTime.UtcNow.Date)
            .ToListAsync();

            //Act
            int namesCount = (await _sut.DailyGeneratedNames()).Data;
            int namesFromDBcount = dbNames.Count();
            //Assert
            Assert.Equal(namesCount, namesFromDBcount);
        }

        [Fact]
        public async void DailyGeneratedNames_ShouldReturnNull_IfNoNamesWhereGeneratedToday()
        {
            //Arrange
            Names firstName = new Names
            {
                Name = "Anorld",
                DateGenerated = DateTime.UtcNow.AddDays(-1),
                IsBooked = true
            };
            _inMemoryDataContext.Add(firstName);

            Names secondName = new Names
            {
                Name = "Panashe",
                DateGenerated = DateTime.UtcNow.AddDays(-10),
                IsBooked = false
            };
            _inMemoryDataContext.Add(secondName);
            _inMemoryDataContext.SaveChanges();

            //Act
            int namesGeneratedToday = (await _sut.DailyGeneratedNames()).Data;
            var namesFromDb = _inMemoryDataContext.Names
            .Where(n => n.DateGenerated.Date == DateTime.UtcNow.Date);
            int namesFromDbGeneratedToday = namesFromDb.Count();

            //Assert
            Assert.Equal(namesGeneratedToday, namesFromDbGeneratedToday);
        }

        [Fact]
        public async void DailyGeneratedNames_ShouldReturnNumber_IfNamesWhereGeneratedToday()
        {
            //Arrange
            Names firstName = new Names
            {
                Name = "Anorld",
                DateGenerated = DateTime.UtcNow,
                IsBooked = true
            };
            _inMemoryDataContext.Add(firstName);

            Names secondName = new Names
            {
                Name = "Panashe",
                DateGenerated = DateTime.UtcNow.AddDays(-10),
                IsBooked = false
            };
            _inMemoryDataContext.Add(secondName);
            _inMemoryDataContext.SaveChanges();

            //Act
            int namesGeneratedToday = (await _sut.DailyGeneratedNames()).Data;
            var namesFromDb = _inMemoryDataContext.Names
            .Where(n => n.DateGenerated.Date == DateTime.UtcNow.Date);
            int namesFromDbGeneratedToday = namesFromDb.Count();

            //Assert
            Assert.Equal(namesGeneratedToday, namesFromDbGeneratedToday);
        }

        [Fact]
        public async void GetLongestGeneratedName_ShouldReturnNull_IfEmpty()
        {
            //Arrange
            var dbNames = await _inMemoryDataContext.Names.ToListAsync();

            //Act
            string namesLongest = (await _sut.GetLongestGeneratedName()).Data;
            string namesFromDbLongest = null;

            foreach (var name in dbNames)
            {
                if (namesFromDbLongest.Length < name.Name.Length)
                {
                    namesFromDbLongest = name.Name;
                }
            }

            //Assert
            Assert.StrictEqual(namesLongest, namesFromDbLongest);
        }

        [Fact]
        public async void GetLongestGeneratedName_ShouldReturnName_IfNotEmpty()
        {
            //Arrange
            Names firstName = new Names
            {
                Name = "Anorld",
                DateGenerated = DateTime.UtcNow,
                IsBooked = true
            };
            _inMemoryDataContext.Add(firstName);

            Names secondName = new Names
            {
                Name = "Panashe",
                DateGenerated = DateTime.UtcNow.AddDays(-10),
                IsBooked = false
            };
            _inMemoryDataContext.Add(secondName);
            _inMemoryDataContext.SaveChanges();

            var dbNames = await _inMemoryDataContext.Names.ToListAsync();

            //Act
            string namesLongest = (await _sut.GetLongestGeneratedName()).Data;
            string namesFromDbLongest = "";

            foreach (var name in dbNames)
            {
                if (namesFromDbLongest.Length < name.Name.Length)
                {
                    namesFromDbLongest = name.Name;
                }
            }

            //Assert
            Assert.Matches(namesLongest, namesFromDbLongest);
        }

        [Fact]
        public async void GetShortestGeneratedName_ShouldReturnNull_IfEmpty()
        {
            //Arrange
            var dbNames = await _inMemoryDataContext.Names.ToListAsync();

            //Act
            string namesLongest = (await _sut.GetShortestGeneratedName()).Data;
            string namesFromDbLongest = null;

            foreach (var name in dbNames)
            {
                if (namesFromDbLongest.Length < name.Name.Length)
                {
                    namesFromDbLongest = name.Name;
                }
            }

            //Assert
            Assert.StrictEqual(namesLongest, namesFromDbLongest);
        }

        [Fact]
        public async void GetShortestGeneratedName_ShouldReturnName_IfNotEmpty()
        {
            //Arrange
            Names firstName = new Names
            {
                Name = "Anorld",
                DateGenerated = DateTime.UtcNow,
                IsBooked = true
            };
            _inMemoryDataContext.Add(firstName);

            Names secondName = new Names
            {
                Name = "Panashe",
                DateGenerated = DateTime.UtcNow.AddDays(-10),
                IsBooked = false
            };
            _inMemoryDataContext.Add(secondName);
            _inMemoryDataContext.SaveChanges();

            var dbNames = await _inMemoryDataContext.Names.ToListAsync();

            //Act
            string namesShortest = (await _sut.GetShortestGeneratedName()).Data;
            string namesFromDbShortest = "";

            foreach (var name in dbNames)
            {
                if (namesFromDbShortest.Length > name.Name.Length & namesFromDbShortest.Length > 0)
                {
                    namesFromDbShortest = name.Name;
                }
            }

            //Assert
            Assert.Matches(namesShortest, namesFromDbShortest);
        }
    }
}