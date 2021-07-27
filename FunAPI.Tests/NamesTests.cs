using System;
using System.Collections.Generic;
using funAPI.Models;
using funAPI.Services.NameService;
using Moq;
using Xunit;

namespace funAPI.FunAPI.Tests
{
    public class NamesTests
    {
        public Mock<INameService> mock = new Mock<INameService>();

        [Fact]
        public void GetAllNames()
        {

        }

    }
}