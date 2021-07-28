using System;
using System.Collections.Generic;
using AutoMapper;
using funAPI.Data;
using funAPI.Models;
using funAPI.Services.NameService;
using Moq;
using Xunit;

namespace funAPI.FunAPI.Tests
{
    public class NameServiceTests
    {
        private readonly NameService _sut;
        private readonly Mock<IMapper> _iMapperMock = new Mock<IMapper>();
        private readonly Mock<DataContext> _dataContextMock = new Mock<DataContext>();
        public NameServiceTests()
        {
            _sut = new NameService(_iMapperMock.Object, _dataContextMock.Object);
        }

        [Fact]
        public async void BookAName_ShouldReturnAListOfBookedNames_IfTheNamesExistsAndNotBooked()
        {
            //Arrange

            //Act

            //Assert
        }
    }
}